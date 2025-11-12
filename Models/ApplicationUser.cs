using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Identity;

namespace CRUD.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Prestamo> PrestamosCliente { get; set; } = new List<Prestamo>();
        public ICollection<Prestamo> PrestamosEmpleado { get; set; } = new List<Prestamo>();
    }
}