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
    public class BarrioController : Controller
    {
        private readonly MorfeoContext _context;

        public BarrioController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: Barrio
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.Barrios.Include(b => b.IdLocalidadNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: Barrio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barrio = await _context.Barrios
                .Include(b => b.IdLocalidadNavigation)
                .FirstOrDefaultAsync(m => m.IdBarrio == id);
            if (barrio == null)
            {
                return NotFound();
            }

            return View(barrio);
        }

        // GET: Barrio/Create
        public IActionResult Create()
        {
            ViewData["IdLocalidad"] = new SelectList(_context.Localidads, "IdLocalidad", "IdLocalidad");
            return View();
        }

        // POST: Barrio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBarrio,nombre_barrio,NombreBarrio,IdLocalidad")] Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barrio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLocalidad"] = new SelectList(_context.Localidads, "IdLocalidad", "IdLocalidad", barrio.IdLocalidad);
            return View(barrio);
        }

        // GET: Barrio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barrio = await _context.Barrios.FindAsync(id);
            if (barrio == null)
            {
                return NotFound();
            }
            ViewData["IdLocalidad"] = new SelectList(_context.Localidads, "IdLocalidad", "IdLocalidad", barrio.IdLocalidad);
            return View(barrio);
        }

        // POST: Barrio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBarrio,nombre_barrio,NombreBarrio,IdLocalidad")] Barrio barrio)
        {
            if (id != barrio.IdBarrio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barrio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarrioExists(barrio.IdBarrio))
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
            ViewData["IdLocalidad"] = new SelectList(_context.Localidads, "IdLocalidad", "IdLocalidad", barrio.IdLocalidad);
            return View(barrio);
        }

        // GET: Barrio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barrio = await _context.Barrios
                .Include(b => b.IdLocalidadNavigation)
                .FirstOrDefaultAsync(m => m.IdBarrio == id);
            if (barrio == null)
            {
                return NotFound();
            }

            return View(barrio);
        }

        // POST: Barrio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barrio = await _context.Barrios.FindAsync(id);
            if (barrio != null)
            {
                _context.Barrios.Remove(barrio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarrioExists(int id)
        {
            return _context.Barrios.Any(e => e.IdBarrio == id);
        }
    }
}
