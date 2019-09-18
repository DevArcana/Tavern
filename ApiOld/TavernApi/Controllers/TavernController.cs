using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TavernApi.Databases;
using TavernApi.Models.Identity;

namespace TavernApi.Controllers
{
  [ApiController]
  public abstract class TavernController : Controller
  {
    protected readonly TavernContext _context;

    public TavernController(TavernContext context)
    {
      _context = context;
    }

    protected async Task<User> GetLoggedUser()
    {
      var userIdStr = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
      if (userIdStr == null)
        return null;

      if (long.TryParse(userIdStr, out var userId))
      {
        var user = await _context.Users.FindAsync(userId);
        return await Task.FromResult(user);
      }

      return null;
    }

  }
}
