using CRUD.Models;
using CRUD.Data;
using System;
using Microsoft.EntityFrameworkCore;

public static class PrestamosSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!context.Prestamos.Any())
        {
            var cliente1 = await context.Users.FirstOrDefaultAsync(u => u.UserName == "cliente.galeano");
            var cliente2 = await context.Users.FirstOrDefaultAsync(u => u.UserName == "cliente.storni");
            var cliente3 = await context.Users.FirstOrDefaultAsync(u => u.UserName == "cliente.paz");
            var bibliotecario1 = await context.Users.FirstOrDefaultAsync(u => u.UserName == "empleado.borges");
            var bibliotecario2 = await context.Users.FirstOrDefaultAsync(u => u.UserName == "empleado.fuentes");
            var bibliotecario3 = await context.Users.FirstOrDefaultAsync(u => u.UserName == "empleado.rulfo");

            if (cliente1 != null && cliente2 != null && cliente3 != null && bibliotecario1 != null && bibliotecario2 != null && bibliotecario3 != null)
            {
                var prestamos = new List<Prestamo>
                {
                    new Prestamo { Estado = Prestamo.EstadoPrestamo.Activo, InicPrestamo = DateTime.Now.AddDays(-10), FinPrestamo = DateTime.Now.AddDays(10), Multa = 0, ClienteId = cliente1.Id, EmpleadoId = bibliotecario1.Id, LibroId = 1 },
                    new Prestamo { Estado = Prestamo.EstadoPrestamo.Devuelto, InicPrestamo = DateTime.Now.AddDays(-20), FinPrestamo = DateTime.Now.AddDays(-5), Multa = 0, ClienteId = cliente2.Id, EmpleadoId = bibliotecario2.Id, LibroId = 2 },
                    new Prestamo { Estado = Prestamo.EstadoPrestamo.Retrasado, InicPrestamo = DateTime.Now.AddDays(-15), FinPrestamo = DateTime.Now.AddDays(-1), Multa = 50, ClienteId = cliente3.Id, EmpleadoId = bibliotecario3.Id, LibroId = 3 },                    new Prestamo { Estado = Prestamo.EstadoPrestamo.Activo, InicPrestamo = DateTime.Now.AddDays(-5), FinPrestamo = DateTime.Now.AddDays(5), Multa = 0, ClienteId = cliente1.Id, EmpleadoId = bibliotecario2.Id, LibroId = 2 },
                    new Prestamo { Estado = Prestamo.EstadoPrestamo.Devuelto, InicPrestamo = DateTime.Now.AddDays(-30), FinPrestamo = DateTime.Now.AddDays(-20), Multa = 0, ClienteId = cliente2.Id, EmpleadoId = bibliotecario3.Id, LibroId = 3 },
                    new Prestamo { Estado = Prestamo.EstadoPrestamo.Retrasado, InicPrestamo = DateTime.Now.AddDays(-25), FinPrestamo = DateTime.Now.AddDays(-10), Multa = 20, ClienteId = cliente3.Id, EmpleadoId = bibliotecario1.Id, LibroId = 1 },
                    new Prestamo { Estado = Prestamo.EstadoPrestamo.Activo, InicPrestamo = DateTime.Now.AddDays(-3), FinPrestamo = DateTime.Now.AddDays(7), Multa = 0, ClienteId = cliente1.Id, EmpleadoId = bibliotecario3.Id, LibroId = 3 },
                    new Prestamo { Estado = Prestamo.EstadoPrestamo.Devuelto, InicPrestamo = DateTime.Now.AddDays(-40), FinPrestamo = DateTime.Now.AddDays(-30), Multa = 0, ClienteId = cliente2.Id, EmpleadoId = bibliotecario1.Id, LibroId = 1 },
                    new Prestamo { Estado = Prestamo.EstadoPrestamo.Retrasado, InicPrestamo = DateTime.Now.AddDays(-35), FinPrestamo = DateTime.Now.AddDays(-15), Multa = 30, ClienteId = cliente3.Id, EmpleadoId = bibliotecario2.Id, LibroId = 2 },
                    new Prestamo { Estado = Prestamo.EstadoPrestamo.Activo, InicPrestamo = DateTime.Now.AddDays(-2), FinPrestamo = DateTime.Now.AddDays(8), Multa = 0, ClienteId = cliente1.Id, EmpleadoId = bibliotecario1.Id, LibroId = 2 },
                    new Prestamo { Estado = Prestamo.EstadoPrestamo.Devuelto, InicPrestamo = DateTime.Now.AddDays(-50), FinPrestamo = DateTime.Now.AddDays(-40), Multa = 0, ClienteId = cliente2.Id, EmpleadoId = bibliotecario2.Id, LibroId = 3 },
                    new Prestamo { Estado = Prestamo.EstadoPrestamo.Retrasado, InicPrestamo = DateTime.Now.AddDays(-45), FinPrestamo = DateTime.Now.AddDays(-25), Multa = 40, ClienteId = cliente3.Id, EmpleadoId = bibliotecario3.Id, LibroId = 1 },
                    new Prestamo { Estado = Prestamo.EstadoPrestamo.Activo, InicPrestamo = DateTime.Now.AddDays(-1), FinPrestamo = DateTime.Now.AddDays(9), Multa = 0, ClienteId = cliente1.Id, EmpleadoId = bibliotecario2.Id, LibroId = 3 }
                };
                context.Prestamos.AddRange(prestamos);
                await context.SaveChangesAsync();
            }
        }
    }
}
