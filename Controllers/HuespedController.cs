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
    public class HuespedController : Controller
    {
        private readonly MorfeoContext _context;

        public HuespedController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: Huesped
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.Huespeds.Include(h => h.IdPaisNavigation).Include(h => h.IdTipoHuespedNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: Huesped/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huesped = await _context.Huespeds
                .Include(h => h.IdPaisNavigation)
                .Include(h => h.IdTipoHuespedNavigation)
                .FirstOrDefaultAsync(m => m.IdHuesped == id);
            if (huesped == null)
            {
                return NotFound();
            }

            return View(huesped);
        }

        // GET: Huesped/Create
        public IActionResult Create()
        {
            ViewData["IdPais"] = new SelectList(_context.Pais, "IdPais", "IdPais");
            ViewData["IdTipoHuesped"] = new SelectList(_context.TipoHuespeds, "IdTipoHuesped", "IdTipoHuesped");
            return View();
        }

        // POST: Huesped/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHuesped,Nombre,FechaNacimiento,Documento,IdTipoHuesped,IdPais")] Huesped huesped)
        {
            if (ModelState.IsValid)
            {
                _context.Add(huesped);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPais"] = new SelectList(_context.Pais, "IdPais", "IdPais", huesped.IdPais);
            ViewData["IdTipoHuesped"] = new SelectList(_context.TipoHuespeds, "IdTipoHuesped", "IdTipoHuesped", huesped.IdTipoHuesped);
            return View(huesped);
        }

        // GET: Huesped/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huesped = await _context.Huespeds.FindAsync(id);
            if (huesped == null)
            {
                return NotFound();
            }
            ViewData["IdPais"] = new SelectList(_context.Pais, "IdPais", "IdPais", huesped.IdPais);
            ViewData["IdTipoHuesped"] = new SelectList(_context.TipoHuespeds, "IdTipoHuesped", "IdTipoHuesped", huesped.IdTipoHuesped);
            return View(huesped);
        }

        // POST: Huesped/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHuesped,Nombre,FechaNacimiento,Documento,IdTipoHuesped,IdPais")] Huesped huesped)
        {
            if (id != huesped.IdHuesped)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(huesped);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuespedExists(huesped.IdHuesped))
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
            ViewData["IdPais"] = new SelectList(_context.Pais, "IdPais", "IdPais", huesped.IdPais);
            ViewData["IdTipoHuesped"] = new SelectList(_context.TipoHuespeds, "IdTipoHuesped", "IdTipoHuesped", huesped.IdTipoHuesped);
            return View(huesped);
        }

        // GET: Huesped/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huesped = await _context.Huespeds
                .Include(h => h.IdPaisNavigation)
                .Include(h => h.IdTipoHuespedNavigation)
                .FirstOrDefaultAsync(m => m.IdHuesped == id);
            if (huesped == null)
            {
                return NotFound();
            }

            return View(huesped);
        }

        // POST: Huesped/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var huesped = await _context.Huespeds.FindAsync(id);
            if (huesped != null)
            {
                _context.Huespeds.Remove(huesped);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HuespedExists(int id)
        {
            return _context.Huespeds.Any(e => e.IdHuesped == id);
        }
    }
}
