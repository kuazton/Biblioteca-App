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
    public class PrestamosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPrestamoService _prestamoService;

        public PrestamosController(AppDbContext context, IPrestamoService prestamoService)
        {
            _context = context;
            _prestamoService = prestamoService;
        }

        // GET: Prestamos
        public async Task<IActionResult> Index(int page)
        {
            var resultado = await _prestamoService.GetAllAsync(page);
            return View(resultado);
        }

        // GET: Prestamos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var prestamo = await _prestamoService.GetByIdAsync(id.Value);
            if (prestamo == null) return NotFound();
            return View(prestamo);
        }

        // GET: Prestamos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Users, "Id", "UserName");
            ViewData["EmpleadoId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Users, "Id", "UserName");
            ViewData["LibroId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Libros, "Id", "Titulo");
            return View();
        }

        // POST: Prestamos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Estado,InicPrestamo,FinPrestamo,Multa,ClienteId,EmpleadoId,LibroId")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _prestamoService.CreateAsync(prestamo);
                    TempData["SuccessMessage"] = "Préstamo creado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "Ocurrió un error inesperado al crear el préstamo.";
                }
            }
            ViewData["ClienteId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Users, "Id", "UserName", prestamo.ClienteId);
            ViewData["EmpleadoId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Users, "Id", "UserName", prestamo.EmpleadoId);
            ViewData["LibroId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Libros, "Id", "Titulo", prestamo.LibroId);
            return View(prestamo);
        }

        // GET: Prestamos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var prestamo = await _prestamoService.GetByIdAsync(id.Value);
            if (prestamo == null) return NotFound();
            ViewData["ClienteId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Users, "Id", "UserName", prestamo.ClienteId);
            ViewData["EmpleadoId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Users, "Id", "UserName", prestamo.EmpleadoId);
            ViewData["LibroId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Libros, "Id", "Titulo", prestamo.LibroId);
            return View(prestamo);
        }

        // POST: Prestamos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Estado,InicPrestamo,FinPrestamo,Multa,ClienteId,EmpleadoId,LibroId")] Prestamo prestamo)
        {
            if (id != prestamo.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _prestamoService.UpdateAsync(prestamo);
                    TempData["SuccessMessage"] = "Préstamo actualizado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ViewData["ErrorMessage"] = "Ocurrió un error inesperado al actualizar el préstamo.";
                }
            }
            ViewData["ClienteId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Users, "Id", "UserName", prestamo.ClienteId);
            ViewData["EmpleadoId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Users, "Id", "UserName", prestamo.EmpleadoId);
            ViewData["LibroId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Libros, "Id", "Titulo", prestamo.LibroId);
            return View(prestamo);
        }

        // GET: Prestamos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var prestamo = await _prestamoService.GetByIdAsync(id.Value);
            if (prestamo == null) return NotFound();
            return View(prestamo);
        }

        // POST: Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var deleted = await _prestamoService.DeleteAsync(id);
                if (deleted)
                {
                    TempData["SuccessMessage"] = "Préstamo eliminado exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "No se pudo eliminar el préstamo.";
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Ocurrió un error inesperado al eliminar el préstamo.";
                return RedirectToAction(nameof(Delete), new { id });
            }
        }
    }
}
