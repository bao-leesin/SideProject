using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet for ACCOUNT entity
        public DbSet<ACCOUNT> ACCOUNTs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the ACCOUNT entity
            modelBuilder.Entity<ACCOUNT>(entity =>
            {
                entity.HasKey(e => e.USERNAME);
                entity.Property(e => e.USERNAME).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PASSWORD).IsRequired().HasMaxLength(50);
            });
        }
    }
}
