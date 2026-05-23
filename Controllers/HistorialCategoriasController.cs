using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MorfeoWeb.Models;

namespace MorfeoWeb.Controllers
{
    public class HistorialCategoriasController : Controller
    {
        private readonly MorfeoContext _context;

        public HistorialCategoriasController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: HistorialCategorias
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.HistorialCategorias.Include(h => h.IdEstrellasNavigation).Include(h => h.IdHotelNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: HistorialCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialCategoria = await _context.HistorialCategorias
                .Include(h => h.IdEstrellasNavigation)
                .Include(h => h.IdHotelNavigation)
                .FirstOrDefaultAsync(m => m.IdHistoriaCategor == id);
            if (historialCategoria == null)
            {
                return NotFound();
            }

            return View(historialCategoria);
        }

        // GET: HistorialCategorias/Create
        public IActionResult Create()
        {
            ViewData["IdEstrellas"] = new SelectList(_context.CategoriaEstrellas, "IdEstrellas", "IdEstrellas");
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel");
            return View();
        }

        // POST: HistorialCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHistoriaCategor,IdHotel,FechaCambio,MotivoCambio,IdEstrellas")] HistorialCategoria historialCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historialCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstrellas"] = new SelectList(_context.CategoriaEstrellas, "IdEstrellas", "IdEstrellas", historialCategoria.IdEstrellas);
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel", historialCategoria.IdHotel);
            return View(historialCategoria);
        }

        // GET: HistorialCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialCategoria = await _context.HistorialCategorias.FindAsync(id);
            if (historialCategoria == null)
            {
                return NotFound();
            }
            ViewData["IdEstrellas"] = new SelectList(_context.CategoriaEstrellas, "IdEstrellas", "IdEstrellas", historialCategoria.IdEstrellas);
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel", historialCategoria.IdHotel);
            return View(historialCategoria);
        }

        // POST: HistorialCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHistoriaCategor,IdHotel,FechaCambio,MotivoCambio,IdEstrellas")] HistorialCategoria historialCategoria)
        {
            if (id != historialCategoria.IdHistoriaCategor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historialCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialCategoriaExists(historialCategoria.IdHistoriaCategor))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstrellas"] = new SelectList(_context.CategoriaEstrellas, "IdEstrellas", "IdEstrellas", historialCategoria.IdEstrellas);
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel", historialCategoria.IdHotel);
            return View(historialCategoria);
        }

        // GET: HistorialCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialCategoria = await _context.HistorialCategorias
                .Include(h => h.IdEstrellasNavigation)
                .Include(h => h.IdHotelNavigation)
                .FirstOrDefaultAsync(m => m.IdHistoriaCategor == id);
            if (historialCategoria == null)
            {
                return NotFound();
            }

            return View(historialCategoria);
        }

        // POST: HistorialCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historialCategoria = await _context.HistorialCategorias.FindAsync(id);
            if (historialCategoria != null)
            {
                _context.HistorialCategorias.Remove(historialCategoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialCategoriaExists(int id)
        {
            return _context.HistorialCategorias.Any(e => e.IdHistoriaCategor == id);
        }
    }
}
