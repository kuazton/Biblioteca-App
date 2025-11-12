using Microsoft.EntityFrameworkCore;
using CRUD.Models;
using CRUD.Models.ViewModels;
using CRUD.Services.Interfaces;
using CRUD.Data;

namespace CRUD.Services.Implementations
{
    public class ExistenciasService : IExistenciasService
    {
        private readonly AppDbContext _context;
        private readonly IPaginacion<Existencia> _paginacion;

        public ExistenciasService(AppDbContext context, IPaginacion<Existencia> paginacion)
        {
            _context = context;
            _paginacion = paginacion;
        }

        public async Task<PaginacionResultado<Existencia>> GetAllAsync(int page)
        {
            var existencias = _context.Existencias.Include(e => e.Libro);
            return await _paginacion.PaginarAsync(existencias, page);
        }

        public async Task<Existencia?> GetByIdAsync(int id)
        {
            return await _context.Existencias.Include(e => e.Libro).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Existencia> CreateAsync(Existencia existencia)
        {
            _context.Existencias.Add(existencia);
            await _context.SaveChangesAsync();
            return existencia;
        }

        public async Task<Existencia> UpdateAsync(Existencia existencia)
        {
            _context.Existencias.Update(existencia);
            await _context.SaveChangesAsync();
            return existencia;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existencia = await _context.Existencias.FindAsync(id);
            if (existencia == null) return false;
            _context.Existencias.Remove(existencia);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
