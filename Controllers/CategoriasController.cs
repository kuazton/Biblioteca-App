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
    public class CategoriasController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(AppDbContext context, ICategoriaService categoriaService)
        {
            _context = context;
            _categoriaService = categoriaService;
        }

        // GET: Categorias
        public async Task<IActionResult> Index(int page)
        {
            var resultado = await _categoriaService.GetAllAsync(page);
            return View(resultado);
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var categoria = await _categoriaService.GetByIdAsync(id.Value);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoriaService.CreateAsync(categoria);
                    TempData["SuccessMessage"] = "Categoría creada exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "Ocurrió un error inesperado al crear la categoría.";
                }
            }
            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var categoria = await _categoriaService.GetByIdAsync(id.Value);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] Categoria categoria)
        {
            if (id != categoria.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoriaService.UpdateAsync(categoria);
                    TempData["SuccessMessage"] = "Categoría actualizada exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "Ocurrió un error inesperado al actualizar la categoría.";
                }
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var categoria = await _categoriaService.GetByIdAsync(id.Value);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var deleted = await _categoriaService.DeleteAsync(id);
                if (deleted)
                {
                    TempData["SuccessMessage"] = "Categoría eliminada exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "No se pudo eliminar la categoría.";
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Ocurrió un error inesperado al eliminar la categoría.";
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
    }
}
