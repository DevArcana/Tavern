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
  public class CommentController : TavernController
  {
    public CommentController(TavernContext context) : base(context)
    { }

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
    public async Task<IActionResult> CreateComment([FromBody]CommentDCO model)
    {
      var user = await GetLoggedUser();
      if (user == null)
        return await Task.FromResult(new BadRequestResult());

      var parent = (model.ParentId != null) ? await _context.Comments.FindAsync(model.ParentId) : null;
      if (model.ParentId != null && parent == null)
        return await Task.FromResult(new BadRequestResult());

      var node = (parent != null) ? new CommentNode
      {
        Parent = parent,
        ParentId = parent.Id
      } : null;

      var comment = new Comment
      {
        Content = model.Content,
        ProjectId = model.ProjectId,
        CreationTimeStamp = DateTime.Now,
        Creator = user,
        Parent = node
      };

      await _context.Comments.AddAsync(comment);
      await _context.SaveChangesAsync();
      return await Task.FromResult(new OkObjectResult(new CommentDTO(comment, 0)));
    }
  }
}
