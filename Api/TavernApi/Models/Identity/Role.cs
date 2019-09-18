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
    public IEnumerable<UserRole> Users { get; set; }
  }

  public class UserRole
  {
    public long UserId { get; set; }
    public User User { get; set; }
    public long RoleId { get; set; }
    public Role Role { get; set; }
  }
}
