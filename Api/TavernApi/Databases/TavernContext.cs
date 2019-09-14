using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TavernApi.Models;

namespace TavernApi.Databases
{
  public class TavernContext : IdentityDbContext
  {
    public DbSet<Category> Categories { get; set; }
    //public DbSet<Comment> Comments { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectRole> ProjectRoles { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlite("Data Source=tavern.db");
    }
  }
}
