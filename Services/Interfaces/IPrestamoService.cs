using CRUD.Models;
using CRUD.Models.ViewModels;

namespace CRUD.Services.Interfaces
{
    public interface IPrestamoService
    {
        public Task<PaginacionResultado<Prestamo>> GetAllAsync(int page);
        public Task<Prestamo?> GetByIdAsync(int id);
        public Task<Prestamo> CreateAsync(Prestamo prestamo);
        public Task<Prestamo> UpdateAsync(Prestamo prestamo);
        public Task<bool> DeleteAsync(int id);
    }
}