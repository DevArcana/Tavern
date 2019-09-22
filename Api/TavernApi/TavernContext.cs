using Microsoft.EntityFrameworkCore;
using TavernApi.Models.Identity;

namespace TavernApi
{
    public class TavernContext : DbContext
    {
        public TavernContext(DbContextOptions<TavernContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
    }
}