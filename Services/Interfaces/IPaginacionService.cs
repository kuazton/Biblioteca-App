using CRUD.Models.ViewModels;

namespace CRUD.Services.Interfaces
{
    public interface IPaginacion<T>
    {
        Task<PaginacionResultado<T>> PaginarAsync(IQueryable<T> query, int pagina);
    }
}