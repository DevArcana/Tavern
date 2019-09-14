using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TavernApi.Models.Identity
{
  public class User
  {
    public long Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public virtual IEnumerable<UserRole> Roles { get; set; }
  }

  public class UserDTO
  {
    public long Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    public UserDTO(User user)
    {
      Id = user.Id;
      Username = user.Username;
      Email = user.Email;
    }
  }
}
