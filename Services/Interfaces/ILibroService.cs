using CRUD.Models;
using CRUD.Models.ViewModels;

namespace CRUD.Services.Interfaces
{
    public interface ILibroService
    {
        public Task<PaginacionResultado<Libro>> GetAllAsync(int page, string filtro);
        public Task<Libro?> GetByIdAsync(int id);
        public Task<Libro> CreateAsync(Libro libro);
        public Task<Libro> UpdateAsync(Libro libro);
        public Task<bool> DeleteAsync(int id);
    }
}