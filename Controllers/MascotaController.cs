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
    public class MascotaController : Controller
    {
        private readonly MorfeoContext _context;

        public MascotaController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: Mascota
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.Mascota.Include(m => m.IdHuespedNavigation).Include(m => m.IdTipoNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: Mascota/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotum = await _context.Mascota
                .Include(m => m.IdHuespedNavigation)
                .Include(m => m.IdTipoNavigation)
                .FirstOrDefaultAsync(m => m.IdMascota == id);
            if (mascotum == null)
            {
                return NotFound();
            }

            return View(mascotum);
        }

        // GET: Mascota/Create
        public IActionResult Create()
        {
            ViewData["IdHuesped"] = new SelectList(_context.Huespeds, "IdHuesped", "IdHuesped");
            ViewData["IdTipo"] = new SelectList(_context.TipoMascota, "IdTipo", "IdTipo");
            return View();
        }

        // POST: Mascota/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMascota,Nombre,IdTipo,IdHuesped")] Mascotum mascotum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mascotum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHuesped"] = new SelectList(_context.Huespeds, "IdHuesped", "IdHuesped", mascotum.IdHuesped);
            ViewData["IdTipo"] = new SelectList(_context.TipoMascota, "IdTipo", "IdTipo", mascotum.IdTipo);
            return View(mascotum);
        }

        // GET: Mascota/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotum = await _context.Mascota.FindAsync(id);
            if (mascotum == null)
            {
                return NotFound();
            }
            ViewData["IdHuesped"] = new SelectList(_context.Huespeds, "IdHuesped", "IdHuesped", mascotum.IdHuesped);
            ViewData["IdTipo"] = new SelectList(_context.TipoMascota, "IdTipo", "IdTipo", mascotum.IdTipo);
            return View(mascotum);
        }

        // POST: Mascota/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMascota,Nombre,IdTipo,IdHuesped")] Mascotum mascotum)
        {
            if (id != mascotum.IdMascota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mascotum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotumExists(mascotum.IdMascota))
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
            ViewData["IdHuesped"] = new SelectList(_context.Huespeds, "IdHuesped", "IdHuesped", mascotum.IdHuesped);
            ViewData["IdTipo"] = new SelectList(_context.TipoMascota, "IdTipo", "IdTipo", mascotum.IdTipo);
            return View(mascotum);
        }

        // GET: Mascota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotum = await _context.Mascota
                .Include(m => m.IdHuespedNavigation)
                .Include(m => m.IdTipoNavigation)
                .FirstOrDefaultAsync(m => m.IdMascota == id);
            if (mascotum == null)
            {
                return NotFound();
            }

            return View(mascotum);
        }

        // POST: Mascota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascotum = await _context.Mascota.FindAsync(id);
            if (mascotum != null)
            {
                _context.Mascota.Remove(mascotum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotumExists(int id)
        {
            return _context.Mascota.Any(e => e.IdMascota == id);
        }
    }
}
