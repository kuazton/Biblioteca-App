using CRUD.Models;
using CRUD.Data;

public static class AutoresSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!context.Autores.Any())
        {
            var autores = new List<Autor>
            {
                new Autor { Nombre = "Gabriel", Apellido = "García Márquez", Edad = 87 },
                new Autor { Nombre = "Isabel", Apellido = "Allende", Edad = 81 },
                new Autor { Nombre = "Julio", Apellido = "Cortázar", Edad = 69 },
                new Autor { Nombre = "Mario", Apellido = "Vargas Llosa", Edad = 89 },
                new Autor { Nombre = "Laura", Apellido = "Restrepo", Edad = 73 },
                new Autor { Nombre = "Jorge Luis", Apellido = "Borges", Edad = 86 },
                new Autor { Nombre = "Carlos", Apellido = "Fuentes", Edad = 83 },
                new Autor { Nombre = "Juan", Apellido = "Rulfo", Edad = 67 },
                new Autor { Nombre = "Rosa", Apellido = "Montero", Edad = 70 },
                new Autor { Nombre = "Elena", Apellido = "Poniatowska", Edad = 91 },
                new Autor { Nombre = "Eduardo", Apellido = "Galeano", Edad = 74 },
                new Autor { Nombre = "Alfonsina", Apellido = "Storni", Edad = 46 },
                new Autor { Nombre = "Octavio", Apellido = "Paz", Edad = 84 },
                new Autor { Nombre = "Clarice", Apellido = "Lispector", Edad = 56 },
                new Autor { Nombre = "Ricardo", Apellido = "Piglia", Edad = 75 }
            };
            context.Autores.AddRange(autores);
            await context.SaveChangesAsync();
        }
    }
}
