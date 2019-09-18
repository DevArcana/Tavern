﻿using System;
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
    public string PasswordHash { get; set; }
    public IEnumerable<UserRole> Roles { get; set; }
  }
}
