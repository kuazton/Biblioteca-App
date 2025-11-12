using CRUD.Models;
using CRUD.Models.ViewModels;

namespace CRUD.Services.Interfaces
{
    public interface IExistenciasService
    {
        Task<PaginacionResultado<Existencia>> GetAllAsync(int page);
        Task<Existencia?> GetByIdAsync(int id);
        Task<Existencia> CreateAsync(Existencia existencia);
        Task<Existencia> UpdateAsync(Existencia existencia);
        Task<bool> DeleteAsync(int id);
    }
}
