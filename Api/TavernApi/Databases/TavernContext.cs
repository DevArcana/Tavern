using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TavernApi.Models.Identity;
using TavernApi.Models;

namespace TavernApi.Databases
{
  public class TavernContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<Category> Categories { get; set; }
    //public DbSet<Comment> Comments { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectRole> ProjectRoles { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlite("Data Source=tavern.db");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<UserRole>(entity =>
      {
        entity.ToTable("UserRole");
        entity.HasKey(e => new { e.UserId, e.RoleId });

        entity.HasOne(e => e.User).WithMany(u => u.Roles)
        .HasForeignKey(e => e.UserId);
        entity.HasOne(e => e.Role).WithMany(r => r.Users)
        .HasForeignKey(e => e.RoleId);
      });
    }
  }
}
