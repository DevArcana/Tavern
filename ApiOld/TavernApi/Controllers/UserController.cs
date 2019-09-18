using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TavernApi.Databases;
using TavernApi.Identity;
using TavernApi.Models;
using TavernApi.Models.Identity;

namespace TavernApi.Controllers
{
  [ApiController]
  [Route("api")]
  public class AccountController : TavernController
  {
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public AccountController(SignInManager<User> signInManager,
      UserManager<User> userManager, IConfiguration configuration, TavernContext context) : base(context)
    {
      _signInManager = signInManager;
      _userManager = userManager;
      _configuration = configuration;
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<string>> Login([FromBody]LoginDTO login)
    {
      var result = await _signInManager.PasswordSignInAsync(login.Username, login.Password, false, false);

      if (result.Succeeded)
      {
        var appUser = _userManager.Users.SingleOrDefault(u => u.Username == login.Username);
        return GenerateJwtToken(appUser.Email, appUser);
      }

      return new BadRequestResult();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody]RegisterDTO model)
    {
      var user = new User
      {
        Username = model.Username,
        Email = model.Email
      };
      var result = await _userManager.CreateAsync(user, model.Password);

      if (result.Succeeded)
      {
        return new OkResult();
      }

      return new BadRequestResult();
    }

    [HttpGet]
    [Route("me")]
    [Authorize]
    public async Task<ActionResult<UserDTO>> GetUserInfo()
    {
      var user = await GetLoggedUser();

      if (user == null)
        return await Task.FromResult(new BadRequestResult());
      else
        return await Task.FromResult(new OkObjectResult(new UserDTO(user)));
    }

    private string GenerateJwtToken(string email, User user)
    {
      var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

      var token = new JwtSecurityToken(
          _configuration["JwtIssuer"],
          _configuration["JwtIssuer"],
          claims,
          expires: expires,
          signingCredentials: creds
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
