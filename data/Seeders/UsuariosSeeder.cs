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
            ("admin2@email.com", "admin2@email.com", "Admin123!", "Admin"),
            ("cliente1@email.com", "cliente1@email.com", "Cliente123!", "Cliente"),
            ("cliente2@email.com", "cliente2@email.com", "Cliente123!", "Cliente"),
            ("cliente3@email.com", "cliente3@email.com", "Cliente123!", "Cliente"),
            ("cliente4@email.com", "cliente4@email.com", "Cliente123!", "Cliente"),
            ("cliente5@email.com", "cliente5@email.com", "Cliente123!", "Cliente"),
            ("cliente6@email.com", "cliente6@email.com", "Cliente123!", "Cliente"),
            ("bibliotecario1@email.com", "bibliotecario1@email.com", "Biblio123!", "Empleado"),
            ("bibliotecario2@email.com", "bibliotecario2@email.com", "Biblio123!", "Empleado"),
            ("bibliotecario3@email.com", "bibliotecario3@email.com", "Biblio123!", "Empleado")
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
