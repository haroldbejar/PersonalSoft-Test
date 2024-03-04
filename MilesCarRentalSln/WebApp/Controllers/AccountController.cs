using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Services;
using System.Security.Cryptography;
using System.Text;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAppUserService _userService;
        private readonly ITokenService _tokenService;

        public AccountController(IAppUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerUser)
        {
            var existingUser = await _userService.ValidateAppUserExist(registerUser.UserName);
            if (existingUser) return BadRequest("El usuario ya existe!");

            await _userService.Register(registerUser);

            var user = new LogedUserDto
            {
                UserName = registerUser.UserName,
                Token = _tokenService.CreateToken(registerUser)
            };

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(RegisterDto registerUser)
        {
            var existingUser = await _userService.GetUserByUserName(registerUser.UserName);
            if (registerUser == null) return Unauthorized();

            using var hmac = new HMACSHA512(existingUser.PasswordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUser.PassWord));

            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != existingUser.PasswordHash[i]) return Unauthorized();
            }

            var user = new LogedUserDto
            {   
                Id = existingUser.Id,
                UserName = existingUser.UserName,
                Token = _tokenService.CreateToken(registerUser)
            };

            return Ok(user);
        }
    }
}
