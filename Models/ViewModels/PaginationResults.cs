namespace CRUD.Models.ViewModels
{
    public class PaginacionResultado<T>
    {
        public IEnumerable<T> Datos { get; set; } = System.Array.Empty<T>();
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
        public int TotalRegistros { get; set; }
        public bool TienePaginaAnterior => PaginaActual > 1;
        public bool TienePaginaSiguiente => PaginaActual < TotalPaginas;
    }
}
