using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Loldle.Models;

namespace Loldle.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Loldle.Models.Champions> Champions { get; set; } = default!;
        public DbSet<Loldle.Models.Info> Info { get; set; } = default!;
        public DbSet<Loldle.Models.Questions> Questions { get; set; } = default!;
    }
}
