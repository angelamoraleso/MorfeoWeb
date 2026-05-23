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
    public class LocalidadController : Controller
    {
        private readonly MorfeoContext _context;

        public LocalidadController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: Localidad
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.Localidads.Include(l => l.IdCiudadNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: Localidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localidad = await _context.Localidads
                .Include(l => l.IdCiudadNavigation)
                .FirstOrDefaultAsync(m => m.IdLocalidad == id);
            if (localidad == null)
            {
                return NotFound();
            }

            return View(localidad);
        }

        // GET: Localidad/Create
        public IActionResult Create()
        {
            ViewData["IdCiudad"] = new SelectList(_context.Ciudads, "IdCiudad", "IdCiudad");
            return View();
        }

        // POST: Localidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLocalidad,NombreLocalidad,CodigoPostal,IdCiudad")] Localidad localidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCiudad"] = new SelectList(_context.Ciudads, "IdCiudad", "IdCiudad", localidad.IdCiudad);
            return View(localidad);
        }

        // GET: Localidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localidad = await _context.Localidads.FindAsync(id);
            if (localidad == null)
            {
                return NotFound();
            }
            ViewData["IdCiudad"] = new SelectList(_context.Ciudads, "IdCiudad", "IdCiudad", localidad.IdCiudad);
            return View(localidad);
        }

        // POST: Localidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLocalidad,NombreLocalidad,CodigoPostal,IdCiudad")] Localidad localidad)
        {
            if (id != localidad.IdLocalidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalidadExists(localidad.IdLocalidad))
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
            ViewData["IdCiudad"] = new SelectList(_context.Ciudads, "IdCiudad", "IdCiudad", localidad.IdCiudad);
            return View(localidad);
        }

        // GET: Localidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localidad = await _context.Localidads
                .Include(l => l.IdCiudadNavigation)
                .FirstOrDefaultAsync(m => m.IdLocalidad == id);
            if (localidad == null)
            {
                return NotFound();
            }

            return View(localidad);
        }

        // POST: Localidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localidad = await _context.Localidads.FindAsync(id);
            if (localidad != null)
            {
                _context.Localidads.Remove(localidad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalidadExists(int id)
        {
            return _context.Localidads.Any(e => e.IdLocalidad == id);
        }
    }
}
