using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TavernApi.Databases;
using TavernApi.Models;

namespace TavernApi.Controllers
{
  [ApiController]
  [Route("api/comments")]
  public class CommentController : Controller
  {
    private readonly TavernContext _context;

    public CommentController(TavernContext context)
    {
      _context = context;
    }

    [HttpGet]
    [Route("{projectId}")]
    public async Task<ActionResult<IEnumerable<CommentDTO>>> GetMainComments(long projectId, long depth = 5)
    {
      var comments = await _context.Comments.Where(c => c.ProjectId == projectId && c.Parent == null).ToArrayAsync();

      return await Task.FromResult(new OkObjectResult(comments.Select(c => new CommentDTO(c, depth))));
    }

    [HttpGet]
    [Route("id/{id}")]
    public async Task<ActionResult<CommentDTO>> GetComment(long id, long depth = 5)
    {
      var comment = await _context.Comments.FindAsync(id);
      if (comment == null)
        return await Task.FromResult(new BadRequestResult());

      return await Task.FromResult(new OkObjectResult(new CommentDTO(comment, depth)));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateComment([FromBody]NewComment model)
    {
     var userIdStr = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
      if (userIdStr == null)
        return await Task.FromResult(new BadRequestResult());

      if(long.TryParse(userIdStr, out var userId))
      {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        if(user == null)
          return await Task.FromResult(new BadRequestResult());


          var comment = new Comment
          {
            Content = model.Content
          };

        _ = DateTime.Now;

        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return await Task.FromResult(new OkObjectResult(comment));
      }
      return await Task.FromResult(new BadRequestResult());
    }
  }
}
