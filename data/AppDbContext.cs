using Microsoft.EntityFrameworkCore;
using CRUD.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CRUD.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Existencia> Existencias { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Existencia>()
                .HasOne(e => e.Libro)
                .WithMany(l => l.Existencias)
                .HasForeignKey(e => e.LibroId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Cliente)
                .WithMany(u => u.PrestamosCliente)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Empleado)
                .WithMany(u => u.PrestamosEmpleado)
                .HasForeignKey(p => p.EmpleadoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Libro)
                .WithMany(l => l.Prestamos)
                .HasForeignKey(p => p.LibroId)
                .OnDelete(DeleteBehavior.Restrict);
        
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Autor)
                .WithMany(a => a.Libros)
                .HasForeignKey(l => l.AutorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Editorial)
                .WithMany(e => e.Libros)
                .HasForeignKey(l => l.EditorialId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Categoria)
                .WithMany(c => c.Libros)
                .HasForeignKey(l => l.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Categoria>()
                .HasIndex(c => c.Nombre)
                .IsUnique();

            modelBuilder.Entity<Editorial>()
                .HasIndex(e => e.Nombre)
                .IsUnique();

            base.OnModelCreating(modelBuilder); // <-- Esta línea es obligatoria
        }
    }
}