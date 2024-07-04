using Microsoft.EntityFrameworkCore;
using WebApplication5.Modelos;

namespace WebApplication5.Data
{
    public class LibreriaConext : DbContext
    {

        public LibreriaConext(DbContextOptions options) : base(options) { }


        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Autor>()
                .HasKey(a => a.IdAutor);

            modelBuilder.Entity<Genero>()
                .HasKey(g => g.IdGenero);

            modelBuilder.Entity<Libro>()
                .HasKey(l => l.Isbn);

            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Autor)
                .WithMany(a => a.Libros)
                .HasForeignKey(l => l.AutorId)
                .OnDelete(DeleteBehavior.Restrict); // Restringe la eliminación en cascada si es necesario

            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Genero)
                .WithMany(g => g.Libros)
                .HasForeignKey(l => l.GeneroId)
                .OnDelete(DeleteBehavior.Restrict); // Restringe la eliminación en cascada si es necesario

        }
    }
}
