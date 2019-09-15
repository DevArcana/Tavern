using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavernApi.Models
{
  public class NewComment
  {
    public long ProjectId { get; set; }
    public long ParentId { get; set; }
    public string Content { get; set; }
  }
}
