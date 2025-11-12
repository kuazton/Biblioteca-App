using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CRUD.Data;
using Microsoft.AspNetCore.Identity;
using CRUD.Models;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider, IWebHostEnvironment env)
    {
        using var scope = serviceProvider.CreateScope();
        var scopedProvider = scope.ServiceProvider;
        var dbContext = scopedProvider.GetRequiredService<AppDbContext>();
        // Seed roles y usuarios en todos los entornos
        await RoleSeeder.SeedAsync(scopedProvider);
        await UserSeeder.SeedAsync(scopedProvider);

        // Solo seeders de datos de ejemplo en desarrollo
        if (env.IsDevelopment())
        {
            await EditorialesSeeder.SeedAsync(dbContext);
            await CategoriasSeeder.SeedAsync(dbContext);
            await AutoresSeeder.SeedAsync(dbContext);
            await LibrosSeeder.SeedAsync(dbContext);
            await ExistenciasSeeder.SeedAsync(dbContext);
            await PrestamosSeeder.SeedAsync(dbContext);
        }
    }
}