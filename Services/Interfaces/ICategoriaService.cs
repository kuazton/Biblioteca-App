using CRUD.Models;
using CRUD.Models.ViewModels;

namespace CRUD.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<PaginacionResultado<Categoria>> GetAllAsync(int page);
        Task<Categoria?> GetByIdAsync(int id);
        Task<Categoria> CreateAsync(Categoria categoria);
        Task<Categoria> UpdateAsync(Categoria categoria);
        Task<bool> DeleteAsync(int id);
    }
}
