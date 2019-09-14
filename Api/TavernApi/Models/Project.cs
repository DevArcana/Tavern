using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavernApi.Models
{
  public class Project
  {
    public long Id { get; set; }
    public string Title { get; set; }
    public virtual Category Category { get; set; }
    public virtual IEnumerable<ProjectRole> Roles { get; set; }
    public string Description { get; set; }
    //public virtual IEnumerable<Comment> Comments { get; set; }
    public DateTime Date {get; set;}
       
  }
}
