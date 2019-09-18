using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TavernApi.Models.Identity;

namespace TavernApi.Models
{
  public class Comment
  {
    public long Id { get; set; }
    public string Content { get; set; }
    public User Author { get; set; }
    public DateTime CreationTimeStamp { get; set; }
    public long ProjectId { get; set; }
    public CommentNode Parent { get; set; }
    public IEnumerable<CommentNode> Children { get; set; }
  }

  public class CommentNode
  {
    public long ParentId { get; set; }
    public Comment Parent { get; set; }
    public long ChildId { get; set; }
    public Comment Child { get; set; }
  }
}
