using CarApiAiskinimas.Models;
using CarApiAiskinimas.Repositories;
using CarApiAiskinimas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CarApiAiskinimas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public UserController(IUserRepository userRepository,
            IUserService userService,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _userService = userService;
            _jwtService = jwtService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            var isOk = _userRepository.TryLogin(model.UserName, model.Password, out var user);
            if (!isOk)
                return Unauthorized("Bad username or password");

            var token = _jwtService.GetJwtToken(user.Id, user.Role);


            return Ok(new LoginResponse { UserName = model.UserName, Token = token });
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserRequest model)
        {
            if (_userRepository.Exist(model.UserName))
                return BadRequest("User already exists");

            _userService.CreatePasswordHash(model.Password, out var passwordHash, out var passwordSalt);
            var user = new LocalUser
            {
                UserName = model.UserName,
                Role = model.Role,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            var id = _userRepository.Register(user);

            return Created(nameof(Login), new { id = id });
        }



    }

    public class RegisterUserRequest
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Role { get; set; }

    }

    public class LoginRequest
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
    }
    public class LoginResponse
    {
        public string? UserName { get; set; }
        public string? Token { get; set; }
    }
}