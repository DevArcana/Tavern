using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TavernApi.Models.Identity;

namespace TavernApi.Models
{
  public class Project
  {
    public long Id { get; set; }
    public string Title { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public IEnumerable<Function> Functions { get; set; }
    public DateTime CreationTimeStamp { get; set; }
    public User Creator { get; set; }
  }
}
