using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        public int Edad { get; set; }
        public ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}