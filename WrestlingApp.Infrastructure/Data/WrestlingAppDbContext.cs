using Microsoft.EntityFrameworkCore;
using WrestlingApp.Domain.Entities;

namespace WrestlingApp.Infrastructure.Data
{
    public class WrestlingAppDbContext : DbContext
    {
        public WrestlingAppDbContext(DbContextOptions<WrestlingAppDbContext> options) : base(options) { }

        public DbSet<Club> Clubs { get; set; }  
        public DbSet<Wrestler> Wrestlers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Club>()
                .HasMany(c => c.Wrestlers)
                .WithOne(w => w.Club)
                .HasForeignKey(w => w.ClubId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
