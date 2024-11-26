using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions): base(dbContextOptions)
        {
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed difficulties data to the database
            var difficulties = new List<Difficulty>
            {
                new Difficulty
                {
                    Id = Guid.Parse("c8ae3eb1-2b48-404e-8730-4c30ec12f56a"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("6892b538-ee17-4ef4-9351-6ce56facc9c8"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("7a72a3b8-cbc8-40b6-8cbc-3742c74b0645"),
                    Name = "Hard"
                }
            };
            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);
        }
    }
}