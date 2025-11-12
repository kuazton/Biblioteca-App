using CRUD.Models;
using CRUD.Models.ViewModels;

namespace CRUD.Services.Interfaces
{
    public interface IEditorialService
    {
        public Task<PaginacionResultado<Editorial>> GetAllAsync(int page);
        public Task<Editorial?> GetByIdAsync(int id);
        public Task<Editorial> CreateAsync(Editorial editorial);
        public Task<Editorial> UpdateAsync(Editorial editorial);
        public Task<bool> DeleteAsync(int id);
    }
}