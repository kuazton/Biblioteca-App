using CRUD.Models;
using CRUD.Data;

public static class ExistenciasSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!context.Existencias.Any())
        {
            var existencias = new List<Existencia>();
            for (int i = 1; i <= 15; i++)
            {
                existencias.Add(new Existencia { LibroId = i, Cantidad = 5 + (i % 7) });
            }
            context.Existencias.AddRange(existencias);
            await context.SaveChangesAsync();
        }
    }
}
