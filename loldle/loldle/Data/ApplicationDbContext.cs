using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using loldle.Models;

namespace loldle.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<loldle.Models.Champion> Champion { get; set; } = default!;
        public DbSet<loldle.Models.Quote> Quote { get; set; } = default!;
    }
}
