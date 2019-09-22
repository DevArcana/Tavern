using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavernApi.Models.Identity
{
  public class User
  {
    public long Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    
    public User() {}

    public User(UserDTO dto)
    {
      Id = dto.Id;
      Username = dto.Username;
      Email = dto.Email;
    }
  }

  public class UserDTO
  {
    public long Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public UserDTO () {}

    public UserDTO(User user)
    {
      Id = user.Id;
      Username = user.Username;
      Email = user.Email;
    }
  }
}
