using Microsoft.AspNetCore.Identity;
using CRUD.Models;
using CRUD.Models.ViewModels;

namespace CRUD.Services.Interfaces
{
    public interface IUsuarioService
    {
    string? GetUsuarioId();
    string? GetRol();
    public Task<List<ApplicationUser>> GetUsuariosClienteAsync();
    }
}