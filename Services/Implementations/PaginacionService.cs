using Microsoft.EntityFrameworkCore;
using CRUD.Models.ViewModels;
using CRUD.Services.Interfaces;

namespace CRUD.Services.Implementations
{
    public class PaginacionService<T> : IPaginacion<T>
    {
        private const int PageSize = 10;

        public async Task<PaginacionResultado<T>> PaginarAsync(IQueryable<T> query, int pagina)
        {
            var page = pagina < 1 ? 1 : pagina;
            var totalRegistros = await query.CountAsync();
            var totalPaginas = (int)Math.Ceiling(totalRegistros / (double)PageSize);

            var datos = await query
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            return new PaginacionResultado<T>
            {
                Datos = datos,
                PaginaActual = page,
                TotalPaginas = totalPaginas,
                TotalRegistros = totalRegistros
            };
        }
    }
}