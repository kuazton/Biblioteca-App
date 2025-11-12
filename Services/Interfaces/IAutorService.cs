using CRUD.Models;
using CRUD.Models.ViewModels;

namespace CRUD.Services.Interfaces
{
    public interface IAutorService
    {
        Task<PaginacionResultado<Autor>> GetAllAsync(int page);
        Task<Autor?> GetByIdAsync(int id);
        Task<Autor> CreateAsync(Autor autor);
        Task<Autor> UpdateAsync(Autor autor);
        Task<bool> DeleteAsync(int id);
    }
}
