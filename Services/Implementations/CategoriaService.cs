using Microsoft.EntityFrameworkCore;
using CRUD.Models;
using CRUD.Models.ViewModels;
using CRUD.Services.Interfaces;
using CRUD.Data;

namespace CRUD.Services.Implementations
{
    public class CategoriaService : ICategoriaService
    {
        private readonly AppDbContext _context;
        private readonly IPaginacion<Categoria> _paginacion;

        public CategoriaService(AppDbContext context, IPaginacion<Categoria> paginacion)
        {
            _context = context;
            _paginacion = paginacion;
        }

        public async Task<PaginacionResultado<Categoria>> GetAllAsync(int page)
        {
            var categorias = _context.Categorias;
            return await _paginacion.PaginarAsync(categorias, page);
        }

        public async Task<Categoria?> GetByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<Categoria> CreateAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> UpdateAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null) return false;
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
