using CRUD.Models;
using CRUD.Data;

public static class EditorialesSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!context.Editoriales.Any())
        {
            var editoriales = new List<Editorial>
            {
                new Editorial { Nombre = "Planeta" },
                new Editorial { Nombre = "Alfaguara" },
                new Editorial { Nombre = "Santillana" },
                new Editorial { Nombre = "Norma" },
                new Editorial { Nombre = "Random House" },
                new Editorial { Nombre = "Anagrama" },
                new Editorial { Nombre = "Siruela" },
                new Editorial { Nombre = "Tusquets" },
                new Editorial { Nombre = "Seix Barral" },
                new Editorial { Nombre = "Edhasa" },
                new Editorial { Nombre = "Salamandra" },
                new Editorial { Nombre = "Acantilado" },
                new Editorial { Nombre = "Debolsillo" },
                new Editorial { Nombre = "Lumen" },
                new Editorial { Nombre = "Alianza" }
            };
            context.Editoriales.AddRange(editoriales);
            await context.SaveChangesAsync();
        }
    }
}
