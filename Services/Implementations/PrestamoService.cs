using Microsoft.EntityFrameworkCore;
using CRUD.Models;
using CRUD.Models.ViewModels;
using CRUD.Services.Interfaces;
using CRUD.Data;

namespace CRUD.Services.Implementations
{
    public class PrestamoService : IPrestamoService
    {
        private readonly AppDbContext _context;
        private readonly IPaginacion<Prestamo> _paginacion;
        public PrestamoService(AppDbContext context, IPaginacion<Prestamo> paginacion)
        {
            _context = context;
            _paginacion = paginacion;
        }

        public async Task<PaginacionResultado<Prestamo>> GetAllAsync(int page)
        {
            // Obtener IDs de empleados
            var empleadosIds = (from ur in _context.UserRoles
                                join r in _context.Roles on ur.RoleId equals r.Id
                                where r.Name == "empleado"
                                select ur.UserId).ToList();

            // Obtener IDs de clientes
            var clientesIds = (from ur in _context.UserRoles
                               join r in _context.Roles on ur.RoleId equals r.Id
                               where r.Name == "cliente"
                               select ur.UserId).ToList();

            var libros = _context.Prestamos
            .Include(p => p.Cliente)
            .Include(p => p.Empleado)
            .Include(p => p.Libro)
            .Where(p => clientesIds.Contains(p.ClienteId) && empleadosIds.Contains(p.EmpleadoId));

            var PrestamosPaginados = await _paginacion.PaginarAsync(libros, page);
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