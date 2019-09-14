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
  }
}
