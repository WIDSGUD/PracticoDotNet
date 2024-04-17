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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>().HasData(
                new Pais { id = 1, nombre = "Uruguay" },
                new Pais { id = 2, nombre = "Argentina" },
                new Pais { id = 3, nombre = "Brasil" },
                new Pais { id = 4, nombre = "Venezuela" },
                new Pais { id = 5, nombre = "Paraguay" }
                );
        }
    }
}
