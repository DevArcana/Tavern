using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TavernApi.Helpers;
using TavernApi.Models.Identity;
using TavernApi.Services;

namespace TavernApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/auth")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;

        public UsersController(IUserService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] UserDTO userDTO)
        {
            var user = _userService.AuthenticateWithEmail(userDTO.Email, userDTO.Password);

            if (user == null)
                return BadRequest(new {message = "Username or password is incorrect"});

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {new Claim(ClaimTypes.Name, user.Id.ToString())}),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                user.Id,
                user.Username,
                user.Email,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDTO userDTO)
        {
            var user = new User(userDTO);

            try
            {
                _userService.Create(user, userDTO.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpGet("me")]
        public IActionResult GetPersonalInfo()
        {
            var userId = User.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.Name);
            if (userId == null)
                return BadRequest();

            if (long.TryParse(userId.Value, out long id))
            {
                var user = _userService.GetById(id);
                return Ok(new
                {
                    user.Id,
                    user.Username,
                    user.Email
                });
            }
            
            return BadRequest();
        }
    }
}