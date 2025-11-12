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
    public class ExistenciasController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IExistenciasService _existenciasService;

        public ExistenciasController(AppDbContext context, IExistenciasService existenciasService)
        {
            _context = context;
            _existenciasService = existenciasService;
        }

        // GET: Existencias
        public async Task<IActionResult> Index(int page)
        {
            var resultado = await _existenciasService.GetAllAsync(page);
            return View(resultado);
        }

        // GET: Existencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var existencia = await _existenciasService.GetByIdAsync(id.Value);
            if (existencia == null) return NotFound();
            return View(existencia);
        }

        // GET: Existencias/Create
        public IActionResult Create()
        {
            ViewData["LibroId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Libros, "Id", "Titulo");
            return View();
        }

        // POST: Existencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LibroId,Cantidad")] Existencia existencia)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _existenciasService.CreateAsync(existencia);
                    TempData["SuccessMessage"] = "Existencia creada exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "Ocurrió un error inesperado al crear la existencia.";
                }
            }
            ViewData["LibroId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Libros, "Id", "Titulo", existencia.LibroId);
            return View(existencia);
        }

        // GET: Existencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var existencia = await _existenciasService.GetByIdAsync(id.Value);
            if (existencia == null) return NotFound();
            ViewData["LibroId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Libros, "Id", "Titulo", existencia.LibroId);
            return View(existencia);
        }

        // POST: Existencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LibroId,Cantidad")] Existencia existencia)
        {
            if (id != existencia.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _existenciasService.UpdateAsync(existencia);
                    TempData["SuccessMessage"] = "Existencia actualizada exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "Ocurrió un error inesperado al actualizar la existencia.";
                }
            }
            ViewData["LibroId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Libros, "Id", "Titulo", existencia.LibroId);
            return View(existencia);
        }

        // GET: Existencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var existencia = await _existenciasService.GetByIdAsync(id.Value);
            if (existencia == null) return NotFound();
            return View(existencia);
        }

        // POST: Existencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var deleted = await _existenciasService.DeleteAsync(id);
                if (deleted)
                {
                    TempData["SuccessMessage"] = "Existencia eliminada exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "No se pudo eliminar la existencia.";
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Ocurrió un error inesperado al eliminar la existencia.";
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
    }
}
