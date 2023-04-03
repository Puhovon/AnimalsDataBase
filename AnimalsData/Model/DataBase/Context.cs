using AnimalsData.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace AnimalsData.Model.DataBase
{
    internal class Context : DbContext
    {
        public DbSet<IAnimal> Animals{ get; set; }


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
            modelBuilder.Entity<IAnimal>();
        }
    }
}
