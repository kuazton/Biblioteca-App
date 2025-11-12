using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CRUD.Models
{
    public class Prestamo : IValidatableObject
    {
        [Key]
        public int Id { get; set; }
        public enum EstadoPrestamo { Pendiente = 0, Activo = 1, Devuelto = 2, Retrasado = 3 }

        [Required]
        public EstadoPrestamo Estado { get; set; } = EstadoPrestamo.Pendiente;

        [Required]
        public DateTime InicPrestamo { get; set; } = DateTime.Now;

        [Required]
        public DateTime FinPrestamo { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La multa debe ser un número positivo.")]
        public int Multa { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public string ClienteId { get; set; } = string.Empty;
        public ApplicationUser? Cliente { get; set; }

        [Required]
        [Display(Name = "Libro")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un libro válido.")]
        public int LibroId { get; set; }
        public Libro? Libro { get; set; }

        [Display(Name = "Empleado")]
        public string? EmpleadoId { get; set; } = string.Empty;
        public ApplicationUser? Empleado { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FinPrestamo <= InicPrestamo)
            {
                yield return new ValidationResult(
                    "La fecha límiete del prestamo debe ser mayor a la fecha de inicio.",
                    new[] { nameof(FinPrestamo) }
                );
            }
            if (ClienteId == EmpleadoId)
            {
                yield return new ValidationResult(
                    "El cliente y el empleado no pueden ser la misma persona.",
                    new[] { nameof(ClienteId), nameof(EmpleadoId) }
                );
            }
        }
    }
}