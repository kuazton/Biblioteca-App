using Microsoft.EntityFrameworkCore;
using CRUD.Models;
using CRUD.Models.ViewModels;
using CRUD.Services.Interfaces;
using CRUD.Data;

namespace CRUD.Services.Implementations
{
    public class AutorService : IAutorService
    {
        private readonly AppDbContext _context;
        private readonly IPaginacion<Autor> _paginacion;

        public AutorService(AppDbContext context, IPaginacion<Autor> paginacion)
        {
            _context = context;
            _paginacion = paginacion;
        }

        public async Task<PaginacionResultado<Autor>> GetAllAsync(int page)
        {
            var autores = _context.Autores;
            return await _paginacion.PaginarAsync(autores, page);
        }

        public async Task<Autor?> GetByIdAsync(int id)
        {
            return await _context.Autores.FindAsync(id);
        }

        public async Task<Autor> CreateAsync(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
            return autor;
        }

        public async Task<Autor> UpdateAsync(Autor autor)
        {
            _context.Autores.Update(autor);
            await _context.SaveChangesAsync();
            return autor;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null) return false;
            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
