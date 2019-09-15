using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TavernApi.Models.Identity;

namespace TavernApi.Models
{
  public class ApplicationRequest
  {
    public long Id { get; set; }
    public virtual Project Project { get; set; }
    public virtual User User { get; set; }
    public virtual Function Role { get; set; }
    public bool Accepted { get; set; }

  }
}
