using CRUD.Models;
using CRUD.Data;

public static class ExistenciasSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!context.Existencias.Any())
        {
            var existencias = new List<Existencia>
            {
                new Existencia { LibroId = 1, Cantidad = 10 },
                new Existencia { LibroId = 2, Cantidad = 8 },
                new Existencia { LibroId = 3, Cantidad = 5 },
                new Existencia { LibroId = 4, Cantidad = 7 },
                new Existencia { LibroId = 5, Cantidad = 6 }
            };
            context.Existencias.AddRange(existencias);
            await context.SaveChangesAsync();
        }
    }
}
