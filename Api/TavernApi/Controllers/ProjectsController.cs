using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TavernApi.Databases;
using TavernApi.Helpers;
using TavernApi.Models;

namespace TavernApi.Controllers
{
  [ApiController]
  [Route("api/projects")]
  public class ProjectsController : Controller
  {
    private readonly TavernContext _context;

    public ProjectsController(TavernContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects(int pageSize, int page = 1)
    {
      var projects = _context.Projects.GetPaged(page, pageSize);

      return await Task.FromResult(new OkObjectResult(projects.Select(p => new ProjectDTO(p))));
    }

  }
}
