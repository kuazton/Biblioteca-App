using Microsoft.AspNetCore.Identity;
using CRUD.Models;

public static class UserSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        var usuarios = new List<(string UserName, string Email, string Password, string Rol)>
        {
            ("admin@library.com", "admin@library.com", "Admin123*", "Admin"),
            ("admin2", "admin2@email.com", "Admin123!", "Admin"),
            ("cliente1", "cliente1@email.com", "Cliente123!", "Cliente"),
            ("cliente2", "cliente2@email.com", "Cliente123!", "Cliente"),
            ("cliente3", "cliente3@email.com", "Cliente123!", "Cliente"),
            ("cliente4", "cliente4@email.com", "Cliente123!", "Cliente"),
            ("cliente5", "cliente5@email.com", "Cliente123!", "Cliente"),
            ("cliente6", "cliente6@email.com", "Cliente123!", "Cliente"),
            ("bibliotecario1", "bibliotecario1@email.com", "Biblio123!", "Empleado"),
            ("bibliotecario2", "bibliotecario2@email.com", "Biblio123!", "Empleado"),
            ("bibliotecario3", "bibliotecario3@email.com", "Biblio123!", "Empleado")
        };

        foreach (var (userName, email, password, rol) in usuarios)
        {
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser { UserName = userName, Email = email, EmailConfirmed = true };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, rol);
                }
            }
        }
    }
}
