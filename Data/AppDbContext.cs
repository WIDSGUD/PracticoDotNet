using Microsoft.EntityFrameworkCore;
using PracticoDotNet.Models;

namespace PracticoDotNet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Pais> Paises { get; set; }

        public DbSet<PracticoDotNet.Models.Deporte> Deporte { get; set; }

        public DbSet<PracticoDotNet.Models.Confederacion> Confederacion { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>().HasData(
                new Pais { id = 1, nombre = "Uruguay" }
                );

            modelBuilder.Entity<Deporte>().HasData(
                new Deporte { Id = 1, Nombre = "Futbol" }
                );

            modelBuilder.Entity<Confederacion>().HasData(
               new Confederacion { Id = 1, Nombre = "AUF" }
               );
        }       
    }
}
