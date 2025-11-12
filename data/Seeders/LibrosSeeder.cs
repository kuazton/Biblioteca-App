using CRUD.Models;
using CRUD.Data;

public static class LibrosSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!context.Libros.Any())
        {
            var libros = new List<Libro>
            {
                new Libro { Titulo = "Cien años de soledad", AutorId = 1, EditorialId = 1, CategoriaId = 1, AnioPublicacion = 1967 },
                new Libro { Titulo = "La casa de los espíritus", AutorId = 2, EditorialId = 2, CategoriaId = 1, AnioPublicacion = 1982 },
                new Libro { Titulo = "Rayuela", AutorId = 3, EditorialId = 3, CategoriaId = 1, AnioPublicacion = 1963 },
                new Libro { Titulo = "La ciudad y los perros", AutorId = 4, EditorialId = 4, CategoriaId = 1, AnioPublicacion = 1962 },
                new Libro { Titulo = "Delirio", AutorId = 5, EditorialId = 5, CategoriaId = 1, AnioPublicacion = 2004 }
            };
            context.Libros.AddRange(libros);
            await context.SaveChangesAsync();
        }
    }
}
