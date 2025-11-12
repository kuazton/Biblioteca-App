using CRUD.Models;
using CRUD.Data;

public static class CategoriasSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!context.Categorias.Any())
        {
            var categorias = new List<Categoria>
            {
                new Categoria { Nombre = "Ficción", Descripcion = "Libros de narrativa imaginaria" },
                new Categoria { Nombre = "No ficción", Descripcion = "Libros basados en hechos reales" },
                new Categoria { Nombre = "Ciencia", Descripcion = "Libros de divulgación y estudio científico" },
                new Categoria { Nombre = "Historia", Descripcion = "Libros sobre hechos históricos" },
                new Categoria { Nombre = "Infantil", Descripcion = "Libros para niños" }
            };
            context.Categorias.AddRange(categorias);
            await context.SaveChangesAsync();
        }
    }
}
