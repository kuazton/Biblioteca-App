using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Existencia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Libro")]
        public int LibroId { get; set; }
        public Libro? Libro { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}