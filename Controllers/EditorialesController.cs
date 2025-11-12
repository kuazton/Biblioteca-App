using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUD.Data;
using CRUD.Models;
using CRUD.Services.Interfaces;

namespace CRUD.Controllers
{
    public class EditorialesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEditorialService _editorialService;

        public EditorialesController(AppDbContext context, IEditorialService editorialService)
        {
            _context = context;
            _editorialService = editorialService;
        }

        // GET: Editoriales
        public async Task<IActionResult> Index(int page)
        {
            var resultado = await _editorialService.GetAllAsync(page);
            return View(resultado);
        }

        // GET: Editoriales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var editorial = await _editorialService.GetByIdAsync(id.Value);
            if (editorial == null) return NotFound();
            return View(editorial);
        }

        // GET: Editoriales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editoriales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _editorialService.CreateAsync(editorial);
                    TempData["SuccessMessage"] = "Editorial creada exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "Ocurrió un error inesperado al crear la editorial.";
                }
            }
            return View(editorial);
        }

        // GET: Editoriales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var editorial = await _editorialService.GetByIdAsync(id.Value);
            if (editorial == null) return NotFound();
            return View(editorial);
        }

        // POST: Editoriales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Editorial editorial)
        {
            if (id != editorial.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _editorialService.UpdateAsync(editorial);
                    TempData["SuccessMessage"] = "Editorial actualizada exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "Ocurrió un error inesperado al actualizar la editorial.";
                }
            }
            return View(editorial);
        }

        // GET: Editoriales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var editorial = await _editorialService.GetByIdAsync(id.Value);
            if (editorial == null) return NotFound();
            return View(editorial);
        }

        // POST: Editoriales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var deleted = await _editorialService.DeleteAsync(id);
                if (deleted)
                {
                    TempData["SuccessMessage"] = "Editorial eliminada exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "No se pudo eliminar la editorial.";
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Ocurrió un error inesperado al eliminar la editorial.";
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
    }
}
