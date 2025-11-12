using Microsoft.EntityFrameworkCore;
using CRUD.Models;
using CRUD.Models.ViewModels;
using CRUD.Services.Interfaces;
using CRUD.Data;

namespace CRUD.Services.Implementations
{
    public class LibroService : ILibroService
    {

        private readonly AppDbContext _context;
        private readonly IPaginacion<Libro> _paginacion;

        public LibroService(AppDbContext context, IPaginacion<Libro> paginacion)
        {
            _context = context;
            _paginacion = paginacion;
        }

        public async Task<PaginacionResultado<Libro>> GetAllAsync(int page, string filter)
        {
            IQueryable<Libro> libros = _context.Libros
                .Include(l => l.Editorial)
                .Include(l => l.Autor)
                .Include(l => l.Categoria);

            if (!string.IsNullOrWhiteSpace(filter))
            {
                var filterLower = filter.ToLower();
                libros = libros.Where(p =>
                    p.Titulo.ToLower().Contains(filterLower)
                );
            }

            var LibrosPaginados = await _paginacion.PaginarAsync(libros, page);
            return LibrosPaginados;
        }
        public async Task<Libro?> GetByIdAsync(int id)
        {
            var libro = await _context.Libros
                .Include(l => l.Editorial)
                .Include(l => l.Autor)
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(l => l.Id == id);

            return libro;
        }
        public async Task<Libro> CreateAsync(Libro libro)
        {

            // Validación: Duplicado (título, autor y editorial)
            bool existe = await _context.Libros.AnyAsync(l =>
                l.Titulo == libro.Titulo &&
                l.AutorId == libro.AutorId &&
                l.EditorialId == libro.EditorialId);

            if (existe)
                throw new InvalidOperationException("Ya existe un libro con el mismo título, autor y editorial.");

            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
            return libro;
        }
        public async Task<Libro> UpdateAsync(Libro libro){
            _context.Libros.Update(libro);
            await _context.SaveChangesAsync();
            return libro;
        }
        public async Task<bool> DeleteAsync(int id){
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return false;
            }
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}