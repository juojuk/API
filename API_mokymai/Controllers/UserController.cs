using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_mokymai.Models.Dto;
using API_mokymai.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mime;

namespace API_mokymai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest model)
        {
            var loginResponse = await _userRepo.LoginAsync(model);

            if (loginResponse.Person == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(loginResponse);

        }

        [HttpPost("register")]
        //[Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RegistrationRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]

        public async Task<IActionResult> RegisterAsync([FromBody] RegistrationRequest model)
        {
            var isUserNameUnique = await _userRepo.IsUniqueUserAsync(model.Email);

            if (!isUserNameUnique)
            {
                return BadRequest(new { message = "Username already exists" });
            }

            var user = await _userRepo.RegisterAsync(model);

            if (user == null)
            {
                return BadRequest(new { message = "Error while registering" });
            }

            return Ok();
        }
    }
}
