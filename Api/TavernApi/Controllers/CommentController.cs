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
  }
}
