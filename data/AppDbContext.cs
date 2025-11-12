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


            // ✅ EDITORIALES (10 registros)
            // modelBuilder.Entity<Editorial>().HasData(
            //     new Editorial { Id = 1, Nombre = "Sudamericana" },
            //     new Editorial { Id = 2, Nombre = "Planeta" },
            //     new Editorial { Id = 3, Nombre = "Alfaguara" },
            //     new Editorial { Id = 4, Nombre = "Seix Barral" },
            //     new Editorial { Id = 5, Nombre = "Minotauro" },
            //     new Editorial { Id = 6, Nombre = "Losada" },
            //     new Editorial { Id = 7, Nombre = "Fondo de Cultura Económica" },
            //     new Editorial { Id = 8, Nombre = "Debolsillo" },
            //     new Editorial { Id = 9, Nombre = "Salamandra" },
            //     new Editorial { Id = 10, Nombre = "Grijalbo" }
            // );

            // modelBuilder.Entity<Categoria>().HasData(
            //     new Categoria { Id = 1, Nombre = "Ficción", Descripcion = "Novelas y cuentos de ficción" },
            //     new Categoria { Id = 2, Nombre = "No Ficción", Descripcion = "Ensayos, biografías y documentales" },
            //     new Categoria { Id = 3, Nombre = "Poesía", Descripcion = "Libros de poemas y literatura lírica" },
            //     new Categoria { Id = 4, Nombre = "Teatro", Descripcion = "Obras teatrales y dramáticas" },
            //     new Categoria { Id = 5, Nombre = "Ciencia", Descripcion = "Libros científicos y técnicos" },
            //     new Categoria { Id = 6, Nombre = "Historia", Descripcion = "Libros de historia y acontecimientos" },
            //     new Categoria { Id = 7, Nombre = "Filosofía", Descripcion = "Obras filosóficas y pensamiento" },
            //     new Categoria { Id = 8, Nombre = "Arte", Descripcion = "Libros sobre arte y cultura visual" },
            //     new Categoria { Id = 9, Nombre = "Infantil", Descripcion = "Literatura para niños y jóvenes" },
            //     new Categoria { Id = 10, Nombre = "Autoayuda", Descripcion = "Libros de desarrollo personal" }
            // );

            // ✅ 4. AUTORES (17 registros) - Reducir de 30 a 17
            // modelBuilder.Entity<Autor>().HasData(
            //     new Autor { Id = 1, Nombre = "Gabriel", Apellido = "García Márquez", Edad = 87 },
            //     new Autor { Id = 2, Nombre = "Isabel", Apellido = "Allende", Edad = 80 },
            //     new Autor { Id = 3, Nombre = "Mario", Apellido = "Vargas Llosa", Edad = 87 },
            //     new Autor { Id = 4, Nombre = "Julio", Apellido = "Cortázar", Edad = 70 },
            //     new Autor { Id = 5, Nombre = "Jorge Luis", Apellido = "Borges", Edad = 86 },
            //     new Autor { Id = 6, Nombre = "Laura", Apellido = "Restrepo", Edad = 71 },
            //     new Autor { Id = 7, Nombre = "Carlos", Apellido = "Fuentes", Edad = 83 },
            //     new Autor { Id = 8, Nombre = "Juan", Apellido = "Rulfo", Edad = 68 },
            //     new Autor { Id = 9, Nombre = "Octavio", Apellido = "Paz", Edad = 84 },
            //     new Autor { Id = 10, Nombre = "Pablo", Apellido = "Neruda", Edad = 69 },
            //     new Autor { Id = 11, Nombre = "Federico", Apellido = "García Lorca", Edad = 38 },
            //     new Autor { Id = 12, Nombre = "Miguel", Apellido = "de Cervantes", Edad = 68 },
            //     new Autor { Id = 13, Nombre = "Elena", Apellido = "Poniatowska", Edad = 91 },
            //     new Autor { Id = 14, Nombre = "Gioconda", Apellido = "Belli", Edad = 75 },
            //     new Autor { Id = 15, Nombre = "Antonio", Apellido = "Skármeta", Edad = 82 },
            //     new Autor { Id = 16, Nombre = "Claribel", Apellido = "Alegría", Edad = 89 },
            //     new Autor { Id = 17, Nombre = "Eduardo", Apellido = "Galeano", Edad = 74 }
            // );

            // ✅ 5. LIBROS (50 registros) - EditorialId ahora FK entero (1..10)
            // Se asigna EditorialId en rotación para garantizar integridad con las 10 editoriales sembradas
            // modelBuilder.Entity<Libro>().HasData(
            //     new Libro { Id = 1, Titulo = "Cien años de soledad", AutorId = 1, CategoriaId = 1, EditorialId = 1, AnioPublicacion = 1967 },
            //     new Libro { Id = 2, Titulo = "El amor en los tiempos del cólera", AutorId = 1, CategoriaId = 1, EditorialId = 2, AnioPublicacion = 1985 },
            //     new Libro { Id = 3, Titulo = "Crónica de una muerte anunciada", AutorId = 1, CategoriaId = 1, EditorialId = 3, AnioPublicacion = 1981 },
            //     new Libro { Id = 4, Titulo = "La casa de los espíritus", AutorId = 2, CategoriaId = 1, EditorialId = 4, AnioPublicacion = 1982 },
            //     new Libro { Id = 5, Titulo = "De amor y de sombra", AutorId = 2, CategoriaId = 1, EditorialId = 5, AnioPublicacion = 1984 },
            //     new Libro { Id = 6, Titulo = "Eva Luna", AutorId = 2, CategoriaId = 1, EditorialId = 6, AnioPublicacion = 1987 },
            //     new Libro { Id = 7, Titulo = "La ciudad y los perros", AutorId = 3, CategoriaId = 1, EditorialId = 7, AnioPublicacion = 1963 },
            //     new Libro { Id = 8, Titulo = "Conversación en La Catedral", AutorId = 3, CategoriaId = 1, EditorialId = 8, AnioPublicacion = 1969 },
            //     new Libro { Id = 9, Titulo = "La fiesta del chivo", AutorId = 3, CategoriaId = 1, EditorialId = 9, AnioPublicacion = 2000 },
            //     new Libro { Id = 10, Titulo = "Rayuela", AutorId = 4, CategoriaId = 1, EditorialId = 10, AnioPublicacion = 1963 },
            //     new Libro { Id = 11, Titulo = "Historias de cronopios y de famas", AutorId = 4, CategoriaId = 1, EditorialId = 1, AnioPublicacion = 1962 },
            //     new Libro { Id = 12, Titulo = "El Aleph", AutorId = 5, CategoriaId = 1, EditorialId = 2, AnioPublicacion = 1949 },
            //     new Libro { Id = 13, Titulo = "Ficciones", AutorId = 5, CategoriaId = 1, EditorialId = 3, AnioPublicacion = 1944 },
            //     new Libro { Id = 14, Titulo = "El laberinto de la soledad", AutorId = 5, CategoriaId = 1, EditorialId = 4, AnioPublicacion = 1950 },
            //     new Libro { Id = 15, Titulo = "Delirio", AutorId = 6, CategoriaId = 1, EditorialId = 5, AnioPublicacion = 2004 },
            //     new Libro { Id = 16, Titulo = "La muerte de Artemio Cruz", AutorId = 7, CategoriaId = 1, EditorialId = 6, AnioPublicacion = 1962 },
            //     new Libro { Id = 17, Titulo = "Pedro Páramo", AutorId = 8, CategoriaId = 1, EditorialId = 7, AnioPublicacion = 1955 },
            //     new Libro { Id = 18, Titulo = "El llano en llamas", AutorId = 8, CategoriaId = 1, EditorialId = 8, AnioPublicacion = 1953 },
            //     new Libro { Id = 19, Titulo = "Libertad bajo palabra", AutorId = 9, CategoriaId = 3, EditorialId = 9, AnioPublicacion = 1949 },
            //     new Libro { Id = 20, Titulo = "Veinte poemas de amor y una canción desesperada", AutorId = 10, CategoriaId = 3, EditorialId = 10, AnioPublicacion = 1924 },
            //     new Libro { Id = 21, Titulo = "Canto general", AutorId = 10, CategoriaId = 3, EditorialId = 1, AnioPublicacion = 1950 },
            //     new Libro { Id = 22, Titulo = "Romancero gitano", AutorId = 11, CategoriaId = 3, EditorialId = 2, AnioPublicacion = 1928 },
            //     new Libro { Id = 23, Titulo = "Bodas de sangre", AutorId = 11, CategoriaId = 4, EditorialId = 3, AnioPublicacion = 1933 },
            //     new Libro { Id = 24, Titulo = "Don Quijote de la Mancha", AutorId = 12, CategoriaId = 1, EditorialId = 4, AnioPublicacion = 1605 },
            //     new Libro { Id = 25, Titulo = "La noche de Tlatelolco", AutorId = 13, CategoriaId = 2, EditorialId = 5, AnioPublicacion = 1971 },
            //     new Libro { Id = 26, Titulo = "Hasta no verte Jesús mío", AutorId = 13, CategoriaId = 1, EditorialId = 6, AnioPublicacion = 1969 },
            //     new Libro { Id = 27, Titulo = "El país bajo mi piel", AutorId = 14, CategoriaId = 2, EditorialId = 7, AnioPublicacion = 2001 },
            //     new Libro { Id = 28, Titulo = "La mujer habitada", AutorId = 14, CategoriaId = 1, EditorialId = 8, AnioPublicacion = 1988 },
            //     new Libro { Id = 29, Titulo = "Ardiente paciencia", AutorId = 15, CategoriaId = 1, EditorialId = 9, AnioPublicacion = 1985 },
            //     new Libro { Id = 30, Titulo = "No pasó nada", AutorId = 15, CategoriaId = 1, EditorialId = 10, AnioPublicacion = 1980 },
            //     new Libro { Id = 31, Titulo = "Flores del volcán", AutorId = 16, CategoriaId = 3, EditorialId = 1, AnioPublicacion = 1982 },
            //     new Libro { Id = 32, Titulo = "Las venas abiertas de América Latina", AutorId = 17, CategoriaId = 2, EditorialId = 2, AnioPublicacion = 1971 },
            //     new Libro { Id = 33, Titulo = "Memoria del fuego I", AutorId = 17, CategoriaId = 6, EditorialId = 3, AnioPublicacion = 1982 },
            //     new Libro { Id = 34, Titulo = "El libro de los abrazos", AutorId = 17, CategoriaId = 1, EditorialId = 4, AnioPublicacion = 1989 },
            //     new Libro { Id = 35, Titulo = "Historia de la filosofía", AutorId = 1, CategoriaId = 7, EditorialId = 5, AnioPublicacion = 2010 },
            //     new Libro { Id = 36, Titulo = "El arte de la guerra", AutorId = 2, CategoriaId = 7, EditorialId = 6, AnioPublicacion = 2011 },
            //     new Libro { Id = 37, Titulo = "Breve historia del tiempo", AutorId = 3, CategoriaId = 5, EditorialId = 7, AnioPublicacion = 2012 },
            //     new Libro { Id = 38, Titulo = "El origen de las especies", AutorId = 4, CategoriaId = 5, EditorialId = 8, AnioPublicacion = 2013 },
            //     new Libro { Id = 39, Titulo = "Historia del arte", AutorId = 5, CategoriaId = 8, EditorialId = 9, AnioPublicacion = 2014 },
            //     new Libro { Id = 40, Titulo = "El principito", AutorId = 6, CategoriaId = 9, EditorialId = 10, AnioPublicacion = 2015 },
            //     new Libro { Id = 41, Titulo = "Matilda", AutorId = 7, CategoriaId = 9, EditorialId = 1, AnioPublicacion = 2016 },
            //     new Libro { Id = 42, Titulo = "Los hábitos de la gente altamente efectiva", AutorId = 8, CategoriaId = 10, EditorialId = 2, AnioPublicacion = 2017 },
            //     new Libro { Id = 43, Titulo = "Padre rico, padre pobre", AutorId = 9, CategoriaId = 10, EditorialId = 3, AnioPublicacion = 2018 },
            //     new Libro { Id = 44, Titulo = "El monje que vendió su Ferrari", AutorId = 10, CategoriaId = 10, EditorialId = 4, AnioPublicacion = 2019 },
            //     new Libro { Id = 45, Titulo = "La historia interminable", AutorId = 11, CategoriaId = 9, EditorialId = 5, AnioPublicacion = 2020 },
            //     new Libro { Id = 46, Titulo = "El nombre de la rosa", AutorId = 12, CategoriaId = 1, EditorialId = 6, AnioPublicacion = 2021 },
            //     new Libro { Id = 47, Titulo = "Crónicas marcianas", AutorId = 13, CategoriaId = 1, EditorialId = 7, AnioPublicacion = 2022 },
            //     new Libro { Id = 48, Titulo = "1984", AutorId = 14, CategoriaId = 1, EditorialId = 8, AnioPublicacion = 2023 },
            //     new Libro { Id = 49, Titulo = "Rebelión en la granja", AutorId = 15, CategoriaId = 1, EditorialId = 9, AnioPublicacion = 2024 },
            //     new Libro { Id = 50, Titulo = "Un mundo feliz", AutorId = 16, CategoriaId = 1, EditorialId = 10, AnioPublicacion = 2025 }
            // );

            // modelBuilder.Entity<Prestamo>().HasData(
            //     new Prestamo { Id = 1, ClienteId = 3, EmpleadoId = 2, LibroId = 1, Estado = Prestamo.EstadoPrestamo.Activo, InicPrestamo = new DateTime(2025, 1, 10), FinPrestamo = new DateTime(2025, 1, 20), Multa = 0 },
            //     new Prestamo { Id = 2, ClienteId = 4, EmpleadoId = 2, LibroId = 2, Estado = Prestamo.EstadoPrestamo.Pendiente, InicPrestamo = new DateTime(2025, 2, 5), FinPrestamo = new DateTime(2025, 2, 15), Multa = 0 },
            //     new Prestamo { Id = 3, ClienteId = 5, EmpleadoId = 2, LibroId = 3, Estado = Prestamo.EstadoPrestamo.Devuelto, InicPrestamo = new DateTime(2025, 3, 1), FinPrestamo = new DateTime(2025, 3, 10), Multa = 0 },
            //     new Prestamo { Id = 4, ClienteId = 3, EmpleadoId = 2, LibroId = 4, Estado = Prestamo.EstadoPrestamo.Retrasado, InicPrestamo = new DateTime(2025, 4, 12), FinPrestamo = new DateTime(2025, 4, 22), Multa = 5000 },
            //     new Prestamo { Id = 5, ClienteId = 4, EmpleadoId = 2, LibroId = 5, Estado = Prestamo.EstadoPrestamo.Activo, InicPrestamo = new DateTime(2025, 5, 8), FinPrestamo = new DateTime(2025, 5, 18), Multa = 0 },
            //     new Prestamo { Id = 6, ClienteId = 3, EmpleadoId = 2, LibroId = 6, Estado = Prestamo.EstadoPrestamo.Activo, InicPrestamo = new DateTime(2025, 6, 1), FinPrestamo = new DateTime(2025, 6, 11), Multa = 0 },
            //     new Prestamo { Id = 7, ClienteId = 4, EmpleadoId = 2, LibroId = 7, Estado = Prestamo.EstadoPrestamo.Pendiente, InicPrestamo = new DateTime(2025, 6, 15), FinPrestamo = new DateTime(2025, 6, 25), Multa = 0 },
            //     new Prestamo { Id = 8, ClienteId = 5, EmpleadoId = 2, LibroId = 8, Estado = Prestamo.EstadoPrestamo.Devuelto, InicPrestamo = new DateTime(2025, 7, 1), FinPrestamo = new DateTime(2025, 7, 10), Multa = 0 },
            //     new Prestamo { Id = 9, ClienteId = 3, EmpleadoId = 2, LibroId = 9, Estado = Prestamo.EstadoPrestamo.Retrasado, InicPrestamo = new DateTime(2025, 7, 12), FinPrestamo = new DateTime(2025, 7, 22), Multa = 3000 },
            //     new Prestamo { Id = 10, ClienteId = 4, EmpleadoId = 2, LibroId = 10, Estado = Prestamo.EstadoPrestamo.Activo, InicPrestamo = new DateTime(2025, 8, 5), FinPrestamo = new DateTime(2025, 8, 15), Multa = 0 },
            //     new Prestamo { Id = 11, ClienteId = 5, EmpleadoId = 2, LibroId = 11, Estado = Prestamo.EstadoPrestamo.Pendiente, InicPrestamo = new DateTime(2025, 8, 20), FinPrestamo = new DateTime(2025, 8, 30), Multa = 0 },
            //     new Prestamo { Id = 12, ClienteId = 3, EmpleadoId = 2, LibroId = 12, Estado = Prestamo.EstadoPrestamo.Devuelto, InicPrestamo = new DateTime(2025, 9, 1), FinPrestamo = new DateTime(2025, 9, 10), Multa = 0 },
            //     new Prestamo { Id = 13, ClienteId = 4, EmpleadoId = 2, LibroId = 13, Estado = Prestamo.EstadoPrestamo.Activo, InicPrestamo = new DateTime(2025, 9, 12), FinPrestamo = new DateTime(2025, 9, 22), Multa = 0 },
            //     new Prestamo { Id = 14, ClienteId = 5, EmpleadoId = 2, LibroId = 14, Estado = Prestamo.EstadoPrestamo.Retrasado, InicPrestamo = new DateTime(2025, 10, 1), FinPrestamo = new DateTime(2025, 10, 11), Multa = 2000 },
            //     new Prestamo { Id = 15, ClienteId = 3, EmpleadoId = 2, LibroId = 15, Estado = Prestamo.EstadoPrestamo.Devuelto, InicPrestamo = new DateTime(2025, 10, 15), FinPrestamo = new DateTime(2025, 10, 25), Multa = 0 }
            // );
            
            // modelBuilder.Entity<Existencia>().HasData(
            //     new Existencia { Id = 1,  LibroId = 1,  Cantidad = 5 },
            //     new Existencia { Id = 2,  LibroId = 2,  Cantidad = 4 },
            //     new Existencia { Id = 3,  LibroId = 3,  Cantidad = 6 },
            //     new Existencia { Id = 4,  LibroId = 4,  Cantidad = 3 },
            //     new Existencia { Id = 5,  LibroId = 5,  Cantidad = 8 },
            //     new Existencia { Id = 6,  LibroId = 6,  Cantidad = 7 },
            //     new Existencia { Id = 7,  LibroId = 7,  Cantidad = 2 },
            //     new Existencia { Id = 8,  LibroId = 8,  Cantidad = 9 },
            //     new Existencia { Id = 9,  LibroId = 9,  Cantidad = 5 },
            //     new Existencia { Id = 10, LibroId = 10, Cantidad = 10 },
            //     new Existencia { Id = 11, LibroId = 11, Cantidad = 5 },
            //     new Existencia { Id = 12, LibroId = 12, Cantidad = 4 },
            //     new Existencia { Id = 13, LibroId = 13, Cantidad = 6 },
            //     new Existencia { Id = 14, LibroId = 14, Cantidad = 3 },
            //     new Existencia { Id = 15, LibroId = 15, Cantidad = 8 },
            //     new Existencia { Id = 16, LibroId = 16, Cantidad = 7 },
            //     new Existencia { Id = 17, LibroId = 17, Cantidad = 2 },
            //     new Existencia { Id = 18, LibroId = 18, Cantidad = 9 },
            //     new Existencia { Id = 19, LibroId = 19, Cantidad = 5 },
            //     new Existencia { Id = 20, LibroId = 20, Cantidad = 10 },
            //     new Existencia { Id = 21, LibroId = 21, Cantidad = 5 },
            //     new Existencia { Id = 22, LibroId = 22, Cantidad = 4 },
            //     new Existencia { Id = 23, LibroId = 23, Cantidad = 6 },
            //     new Existencia { Id = 24, LibroId = 24, Cantidad = 3 },
            //     new Existencia { Id = 25, LibroId = 25, Cantidad = 8 },
            //     new Existencia { Id = 26, LibroId = 26, Cantidad = 7 },
            //     new Existencia { Id = 27, LibroId = 27, Cantidad = 2 },
            //     new Existencia { Id = 28, LibroId = 28, Cantidad = 9 },
            //     new Existencia { Id = 29, LibroId = 29, Cantidad = 5 },
            //     new Existencia { Id = 30, LibroId = 30, Cantidad = 10 },
            //     new Existencia { Id = 31, LibroId = 31, Cantidad = 5 },
            //     new Existencia { Id = 32, LibroId = 32, Cantidad = 4 },
            //     new Existencia { Id = 33, LibroId = 33, Cantidad = 6 },
            //     new Existencia { Id = 34, LibroId = 34, Cantidad = 3 },
            //     new Existencia { Id = 35, LibroId = 35, Cantidad = 8 },
            //     new Existencia { Id = 36, LibroId = 36, Cantidad = 7 },
            //     new Existencia { Id = 37, LibroId = 37, Cantidad = 2 },
            //     new Existencia { Id = 38, LibroId = 38, Cantidad = 9 },
            //     new Existencia { Id = 39, LibroId = 39, Cantidad = 5 },
            //     new Existencia { Id = 40, LibroId = 40, Cantidad = 10 },
            //     new Existencia { Id = 41, LibroId = 41, Cantidad = 5 },
            //     new Existencia { Id = 42, LibroId = 42, Cantidad = 4 },
            //     new Existencia { Id = 43, LibroId = 43, Cantidad = 6 },
            //     new Existencia { Id = 44, LibroId = 44, Cantidad = 3 },
            //     new Existencia { Id = 45, LibroId = 45, Cantidad = 8 },
            //     new Existencia { Id = 46, LibroId = 46, Cantidad = 7 },
            //     new Existencia { Id = 47, LibroId = 47, Cantidad = 2 },
            //     new Existencia { Id = 48, LibroId = 48, Cantidad = 9 },
            //     new Existencia { Id = 49, LibroId = 49, Cantidad = 5 },
            //     new Existencia { Id = 50, LibroId = 50, Cantidad = 10 }
            // );
        }
    }
}