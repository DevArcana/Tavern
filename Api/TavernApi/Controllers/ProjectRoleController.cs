using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TavernApi.Databases;
using TavernApi.Models;

namespace TavernApi.Controllers
{
  [Route("api/roles")]
  [ApiController]
  public class ProjectRoleController : Controller
  {
    private readonly TavernContext _context;

    public ProjectRoleController(TavernContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectRoleDTO>>> GetRoles()
    {
      return await _context.ProjectRoles
        .Select(c => new ProjectRoleDTO(c)).ToArrayAsync();
    }

    [HttpPost]
    public async Task<IActionResult> CreatePorjectRole([FromBody]ProjectRoleDTO model)
    {
      var exist = await _context.ProjectRoles.AnyAsync(c => c.Name == model.Name);
      if (exist)
      {
        return await Task.FromResult(new BadRequestResult());
      }

      var role = new ProjectRole
      {
        Name = model.Name
      };

      await _context.ProjectRoles.AddAsync(role);
      await _context.SaveChangesAsync();

      return await Task.FromResult(new OkObjectResult(role));

    }
   }
 }
