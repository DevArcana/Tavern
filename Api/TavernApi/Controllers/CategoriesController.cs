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
  [Route("api/categories")]
  [ApiController]
  public class CategoryController : TavernController
  {
    public CategoryController(TavernContext context) : base(context)
    {}

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
    {
      return await _context.Categories
        .Select(c => new CategoryDTO(c)).ToArrayAsync();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody]CategoryDTO model)
    {
      var exist = await _context.Categories.AnyAsync(c => c.Name == model.Name);
      if (exist)
      {
        return await Task.FromResult(new BadRequestResult());
      }
      
      var category = new Category
      {
        Name = model.Name
      };

      await _context.Categories.AddAsync(category);
      await _context.SaveChangesAsync();

      return await Task.FromResult(new OkObjectResult(category));
    }
  }
}
