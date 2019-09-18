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
  [Route("api/functions")]
  [ApiController]
  public class FunctionsController : TavernController
  {
    public FunctionsController(TavernContext context) : base(context)
    {}

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FunctionDTO>>> GetFunctions()
    {
      return await _context.Functions
        .Select(f => new FunctionDTO(f)).ToArrayAsync();
    }

    [HttpPost]
    public async Task<IActionResult> CreateFunction([FromBody]FunctionDTO model)
    {
      var exist = await _context.Functions.AnyAsync(f => f.Name == model.Name);
      if (exist)
      {
        return await Task.FromResult(new BadRequestResult());
      }

      var function = new Function
      {
        Name = model.Name
      };

      await _context.Functions.AddAsync(function);
      await _context.SaveChangesAsync();

      return await Task.FromResult(new OkObjectResult(function));

    }
   }
 }
