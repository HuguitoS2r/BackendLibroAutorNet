using Microsoft.EntityFrameworkCore;
using PruebaLibreria.Entities;

namespace PruebaLibreria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Autor)               
                .WithMany(a => a.Libros)            
                .HasForeignKey(l => l.AutorRut)      
                .HasPrincipalKey(a => a.Rut);       

            base.OnModelCreating(modelBuilder);
        }
    }
}
