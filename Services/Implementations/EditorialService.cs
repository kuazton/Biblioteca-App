using Microsoft.EntityFrameworkCore;
using CRUD.Models;
using CRUD.Models.ViewModels;
using CRUD.Services.Interfaces;
using CRUD.Data;

namespace CRUD.Services.Implementations
{
    public class EditorialService : IEditorialService
    {
        private readonly AppDbContext _context;
        private readonly IPaginacion<Editorial> _paginacion;
        public EditorialService(AppDbContext context, IPaginacion<Editorial> paginacion)
        {
            _context = context;
            _paginacion = paginacion;
        }

        public async Task<PaginacionResultado<Editorial>> GetAllAsync(int page)
        {
            var Editorial = _context.Editoriales.Include(e => e.Libros);

            var EditorialPaginados = await _paginacion.PaginarAsync(Editorial, page);
            return EditorialPaginados;
        }

        public async Task<Editorial?> GetByIdAsync(int id)
        {
            var Editorial = await _context.Editoriales
            .FirstOrDefaultAsync(p => p.Id == id);
            return Editorial;
        }
        public async Task<Editorial> CreateAsync(Editorial editorial)
        {
            _context.Editoriales.Add(editorial);
            await _context.SaveChangesAsync();
            return editorial;
        }
        public async Task<Editorial> UpdateAsync(Editorial editorial){
            _context.Editoriales.Update(editorial);
            await _context.SaveChangesAsync();
            return editorial;
        }
        public async Task<bool> DeleteAsync(int id){
            var editorial = await _context.Editoriales.FindAsync(id);
            if (editorial == null)
            {
                return false;
            }
            _context.Editoriales.Remove(editorial);
            await _context.SaveChangesAsync();
            return true;
        }
   }
}