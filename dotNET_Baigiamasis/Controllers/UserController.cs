using dotNET_Baigiamasis.Data;
using dotNET_Baigiamasis.Models.Dto;
using dotNET_Baigiamasis.Repository.IRepository;
using dotNET_Baigiamasis.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace dotNET_Baigiamasis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IModelAdapter _modelAdapter;
        private readonly IPasswordService _passwordService;

        public UserController(IUserRepo userRepo, IHttpContextAccessor httpContextAccessor, IModelAdapter modelAdapter, IPasswordService passwordService)
        {
            _userRepo = userRepo;
            _httpContextAccessor = httpContextAccessor;
            _modelAdapter = modelAdapter;
            _passwordService = passwordService;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]

        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest model)
        {
            var loginResponse = await _userRepo.LoginAsync(model);

            if (loginResponse.UserId == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                return BadRequest(new { message = "Invalid request" });
            }

            return Ok(loginResponse);

        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RegistrationRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]

        public async Task<IActionResult> RegisterAsync([FromBody] RegistrationRequest model)
        {
            var isUserNameUnique = await _userRepo.IsUniqueUserAsync(model.Email);

            if (!isUserNameUnique)
            {
                return BadRequest(new { message = "User already exists" });
            }

            var user = await _userRepo.RegisterAsync(model);

            if (user == null)
            {
                return BadRequest(new { message = "Error while registering" });
            }

            return Ok();
        }

        [HttpPatch("update")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(RegistrationUpdate))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]

        public async Task<IActionResult> RegistrationResetAsync(JsonPatchDocument<RegistrationUpdate> request)
        {
            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
            var user = await _userRepo.GetAsync(p => p.Id == currentUserId);
            var registration = _modelAdapter.BindPersonWithRegistrationUpdate(user);

            request.ApplyTo(registration, ModelState);

            user = _modelAdapter.BindPersonWithRegistrationUpdate(user, registration);

            await _userRepo.UpdateAsync(user);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }


    }
}
