using Microsoft.EntityFrameworkCore;
using CRUD.Models;
using CRUD.Models.ViewModels;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using CRUD.Data;

namespace CRUD.Services.Implementations
{
    public class PrestamoService : IPrestamoService
    {
        private readonly AppDbContext _context;
        private readonly IPaginacion<Prestamo> _paginacion;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public PrestamoService(AppDbContext context,
            IPaginacion<Prestamo> paginacion,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _paginacion = paginacion;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<PaginacionResultado<Prestamo>> GetAllAsync(int page, string? filter = null)
        {
            // Obtener IDs de empleados
            // Obtener IDs de empleados y clientes usando UserManager y RoleManager
            var empleadosIds = (await _roleManager.FindByNameAsync("Empleado")) != null
                ? (await _userManager.GetUsersInRoleAsync("Empleado")).Select(u => u.Id).ToList()
                : new List<string>();

            if ((await _roleManager.FindByNameAsync("Admin")) != null)
            {
                empleadosIds.AddRange((await _userManager.GetUsersInRoleAsync("Admin")).Select(u => u.Id));
            }

            var clientesIds = (await _roleManager.FindByNameAsync("Cliente")) != null
                ? (await _userManager.GetUsersInRoleAsync("Cliente")).Select(u => u.Id).ToList()
                : new List<string>();

            var prestamos = _context.Prestamos
                .Include(p => p.Cliente)
                .Include(p => p.Empleado)
                .Include(p => p.Libro)
                .Where(p => 
                    p.ClienteId != null && clientesIds.Contains(p.ClienteId) &&
                    p.EmpleadoId != null && empleadosIds.Contains(p.EmpleadoId));

            if (!string.IsNullOrWhiteSpace(filter))
            {
                var filterLower = filter.ToLower();
                prestamos = prestamos.Where(p =>
                    (p.Cliente != null && (p.Cliente.UserName ?? string.Empty).ToLower().Contains(filterLower)) ||
                    (p.Empleado != null && (p.Empleado.UserName ?? string.Empty).ToLower().Contains(filterLower)) ||
                    (p.Libro != null && (p.Libro.Titulo ?? string.Empty).ToLower().Contains(filterLower))
                );
            }

            var PrestamosPaginados = await _paginacion.PaginarAsync(prestamos, page);
            return PrestamosPaginados;
        }
        public async Task<Prestamo?> GetByIdAsync(int id)
        {
            var Prestamo = await _context.Prestamos
            .Include(p => p.Cliente)
            .Include(p => p.Empleado)
            .Include(p => p.Libro)
            .FirstOrDefaultAsync(p => p.Id == id);
            return Prestamo;
        }
        public async Task<Prestamo> CreateAsync(Prestamo prestamo)
        {
            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();
            return prestamo;
        }
        public async Task<Prestamo> UpdateAsync(Prestamo prestamo){
            _context.Prestamos.Update(prestamo);
            await _context.SaveChangesAsync();
            return prestamo;
        }
        public async Task<bool> DeleteAsync(int id){
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return false;
            }
            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();
            return true;
        }
   }
}