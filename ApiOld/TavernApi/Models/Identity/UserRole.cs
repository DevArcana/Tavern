using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavernApi.Models.Identity
{
  public class UserRole
  {
    public long UserId { get; set; }
    public virtual User User { get; set; }
    public long RoleId { get; set; }
    public virtual Role Role { get; set; }
  }
}
