using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavernApi.Models.Identity
{
  public class Role
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public virtual IEnumerable<UserRole> Users { get; set; }
  }
}
