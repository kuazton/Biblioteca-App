using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CRUD.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Autor")]
        public int AutorId { get; set; }
        public Autor? Autor { get; set;}

        [Required]
        [Display(Name = "Editorial")]
        public int EditorialId { get; set; } // FK a Editorial
        public Editorial? Editorial { get; set; }  // navegación correcta

        [Required]
        [Display(Name = "Categoría")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El año debe ser mayor a 0")]
        [Display(Name = "Año Publicación")]
        public int AnioPublicacion { get; set; }

        public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
        public ICollection<Existencia> Existencias { get; set; } = new List<Existencia>();
    }
}