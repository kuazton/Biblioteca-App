using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD.Data;
using CRUD.Models;
using CRUD.Services.Interfaces;

namespace CRUD.Controllers
{
    public class LibrosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILibroService _LibroService;

        public LibrosController(AppDbContext context, ILibroService LibroService)
        {
            _context = context;
            _LibroService = LibroService;
        }

        // GET: Libros
        public async Task<IActionResult> Index(int page, string? filter = null)
        {
            var resultado = await _LibroService.GetAllAsync(page, filter ?? string.Empty);
            return View(resultado);
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _LibroService.GetByIdAsync(id.Value);
            
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Apellido");
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion");
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "Id", "Nombre");
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,AutorId,EditorialId,CategoriaId,AnioPublicacion")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _LibroService.CreateAsync(libro);
                    TempData["SuccessMessage"] = "Libro creado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "Ocurrió un error inesperado al crear el libro.";
                }
            }
            // Si hay error de validación, recargar selects y mostrar vista con errores
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Apellido", libro.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", libro.CategoriaId);
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "Id", "Nombre", libro.EditorialId);
            return View(libro);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _LibroService.GetByIdAsync(id.Value);

            if (libro == null)
            {
                return NotFound();
            }
            
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Apellido", libro.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", libro.CategoriaId);
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "Id", "Nombre", libro.EditorialId);
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,AutorId,EditorialId,CategoriaId,AnioPublicacion")] Libro libro)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            if (!LibroExists(id))
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _LibroService.UpdateAsync(libro);
                    TempData["SuccessMessage"] = "Libro actualizado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                catch (DbUpdateException)
                {
                    ViewData["ErrorMessage"] = "No se pudo actualizar el libro. Verifica los datos e inténtalo nuevamente.";
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "Ocurrió un error inesperado. Por favor, inténtalo más tarde.";
                }
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Apellido", libro.AutorId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", libro.CategoriaId);
            ViewData["EditorialId"] = new SelectList(_context.Editoriales, "Id", "Nombre", libro.EditorialId);
            return View(libro);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _LibroService.GetByIdAsync(id.Value);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!LibroExists(id))
            {
                return NotFound();
            }

            try
            {
                var deleted = await _LibroService.DeleteAsync(id);
                if (deleted)
                {
                    TempData["SuccessMessage"] = "Libro eliminado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "No se pudo eliminar el libro. Inténtalo nuevamente.";
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Ocurrió un error inesperado al eliminar el libro.";
                return RedirectToAction(nameof(Delete), new { id });
            }
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
    }
}
