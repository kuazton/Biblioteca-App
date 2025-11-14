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
                new Libro { Titulo = "Delirio", AutorId = 5, EditorialId = 5, CategoriaId = 1, AnioPublicacion = 2004 },
                new Libro { Titulo = "Pedro Páramo", AutorId = 1, EditorialId = 1, CategoriaId = 2, AnioPublicacion = 1955 },
                new Libro { Titulo = "El Aleph", AutorId = 2, EditorialId = 2, CategoriaId = 2, AnioPublicacion = 1949 },
                new Libro { Titulo = "Aura", AutorId = 3, EditorialId = 3, CategoriaId = 2, AnioPublicacion = 1962 },
                new Libro { Titulo = "La loca de la casa", AutorId = 4, EditorialId = 4, CategoriaId = 3, AnioPublicacion = 2003 },
                new Libro { Titulo = "Las venas abiertas de América Latina", AutorId = 5, EditorialId = 5, CategoriaId = 4, AnioPublicacion = 1971 },
                new Libro { Titulo = "La noche de Tlatelolco", AutorId = 1, EditorialId = 1, CategoriaId = 4, AnioPublicacion = 1971 },
                new Libro { Titulo = "Margarita, está linda la mar", AutorId = 2, EditorialId = 2, CategoriaId = 1, AnioPublicacion = 1998 },
                new Libro { Titulo = "Arráncame la vida", AutorId = 3, EditorialId = 3, CategoriaId = 3, AnioPublicacion = 1985 },
                new Libro { Titulo = "La ley del amor", AutorId = 4, EditorialId = 4, CategoriaId = 3, AnioPublicacion = 1995 },
                new Libro { Titulo = "El niño que enloqueció de amor", AutorId = 5, EditorialId = 5, CategoriaId = 2, AnioPublicacion = 1915 },
                new Libro { Titulo = "El huésped", AutorId = 1, EditorialId = 1, CategoriaId = 2, AnioPublicacion = 2006 },
                new Libro { Titulo = "Abril rojo", AutorId = 2, EditorialId = 2, CategoriaId = 1, AnioPublicacion = 2006 },
                new Libro { Titulo = "Distancia de rescate", AutorId = 3, EditorialId = 3, CategoriaId = 2, AnioPublicacion = 2015 },
                new Libro { Titulo = "Los ingrávidos", AutorId = 4, EditorialId = 4, CategoriaId = 3, AnioPublicacion = 2011 },
                new Libro { Titulo = "Corazón tan blanco", AutorId = 5, EditorialId = 5, CategoriaId = 1, AnioPublicacion = 1992 },
                new Libro { Titulo = "Los pacientes del doctor García", AutorId = 1, EditorialId = 1, CategoriaId = 1, AnioPublicacion = 2017 },
                new Libro { Titulo = "El ruido de las cosas al caer", AutorId = 2, EditorialId = 2, CategoriaId = 1, AnioPublicacion = 2011 },
                new Libro { Titulo = "El talento de Mr. Ripley", AutorId = 3, EditorialId = 3, CategoriaId = 5, AnioPublicacion = 1955 },
                new Libro { Titulo = "Blanco nocturno", AutorId = 4, EditorialId = 4, CategoriaId = 5, AnioPublicacion = 2010 },
                new Libro { Titulo = "El túnel", AutorId = 5, EditorialId = 5, CategoriaId = 2, AnioPublicacion = 1948 }
            };
            context.Libros.AddRange(libros);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar libros en el seeder:");
                Console.WriteLine(ex.ToString());
                if (ex.InnerException != null)
                {
                    Console.WriteLine("InnerException:");
                    Console.WriteLine(ex.InnerException.ToString());
                }
                throw;
            }
        }
    }
}
