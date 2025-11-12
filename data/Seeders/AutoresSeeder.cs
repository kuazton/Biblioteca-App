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
                new Autor { Nombre = "Laura", Apellido = "Restrepo", Edad = 73 }
            };
            context.Autores.AddRange(autores);
            await context.SaveChangesAsync();
        }
    }
}
