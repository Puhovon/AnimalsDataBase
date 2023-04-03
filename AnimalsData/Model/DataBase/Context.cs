using AnimalsData.Model.AnimalModels;
using Microsoft.EntityFrameworkCore;

namespace AnimalsData.Model.DataBase
{
    internal class Context : DbContext
    {
        public DbSet<Amphibia> Amphibias{ get; set; }
        public DbSet<Mammal> Mammals{ get; set; }
        public DbSet<Bird> Birds{ get; set; }
        public DbSet<Undefined> Undefindes{ get; set; }


        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=postgres;username=postgres;password=123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amphibia>();
            modelBuilder.Entity<Mammal>();
            modelBuilder.Entity<Bird>();
            modelBuilder.Entity<Undefined>();
        }
    }
}
