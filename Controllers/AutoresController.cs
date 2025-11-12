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
    public class AutoresController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAutorService _autorService;

        public AutoresController(AppDbContext context, IAutorService autorService)
        {
            _context = context;
            _autorService = autorService;
        }

        // GET: Autores
        public async Task<IActionResult> Index(int page)
        {
            var resultado = await _autorService.GetAllAsync(page);
            return View(resultado);
        }

        // GET: Autores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var autor = await _autorService.GetByIdAsync(id.Value);
            if (autor == null) return NotFound();
            return View(autor);
        }

        // GET: Autores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _autorService.CreateAsync(autor);
                    TempData["SuccessMessage"] = "Autor creado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "Ocurrió un error inesperado al crear el autor.";
                }
            }
            return View(autor);
        }

        // GET: Autores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var autor = await _autorService.GetByIdAsync(id.Value);
            if (autor == null) return NotFound();
            return View(autor);
        }

        // POST: Autores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido")] Autor autor)
        {
            if (id != autor.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _autorService.UpdateAsync(autor);
                    TempData["SuccessMessage"] = "Autor actualizado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "Ocurrió un error inesperado al actualizar el autor.";
                }
            }
            return View(autor);
        }

        // GET: Autores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var autor = await _autorService.GetByIdAsync(id.Value);
            if (autor == null) return NotFound();
            return View(autor);
        }

        // POST: Autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var deleted = await _autorService.DeleteAsync(id);
                if (deleted)
                {
                    TempData["SuccessMessage"] = "Autor eliminado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "No se pudo eliminar el autor.";
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Ocurrió un error inesperado al eliminar el autor.";
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
    }
}
