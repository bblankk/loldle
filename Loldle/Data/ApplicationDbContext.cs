using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test.Models;

namespace Loldle.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<test.Models.Champions> Champions { get; set; } = default!;
        public DbSet<test.Models.Classic> Classic { get; set; } = default!;
        public DbSet<test.Models.Questions> Questions { get; set; } = default!;
    }
}
