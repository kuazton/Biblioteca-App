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
                new Editorial { Nombre = "Random House" }
            };
            context.Editoriales.AddRange(editoriales);
            await context.SaveChangesAsync();
        }
    }
}
