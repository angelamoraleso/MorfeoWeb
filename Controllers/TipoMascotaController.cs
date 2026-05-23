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
    public class TipoMascotaController : Controller
    {
        private readonly MorfeoContext _context;

        public TipoMascotaController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: TipoMascota
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoMascota.ToListAsync());
        }

        // GET: TipoMascota/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMascotum = await _context.TipoMascota
                .FirstOrDefaultAsync(m => m.IdTipo == id);
            if (tipoMascotum == null)
            {
                return NotFound();
            }

            return View(tipoMascotum);
        }

        // GET: TipoMascota/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMascota/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipo,TipoMascota")] TipoMascotum tipoMascotum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMascotum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMascotum);
        }

        // GET: TipoMascota/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMascotum = await _context.TipoMascota.FindAsync(id);
            if (tipoMascotum == null)
            {
                return NotFound();
            }
            return View(tipoMascotum);
        }

        // POST: TipoMascota/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipo,TipoMascota")] TipoMascotum tipoMascotum)
        {
            if (id != tipoMascotum.IdTipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMascotum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMascotumExists(tipoMascotum.IdTipo))
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
            return View(tipoMascotum);
        }

        // GET: TipoMascota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMascotum = await _context.TipoMascota
                .FirstOrDefaultAsync(m => m.IdTipo == id);
            if (tipoMascotum == null)
            {
                return NotFound();
            }

            return View(tipoMascotum);
        }

        // POST: TipoMascota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoMascotum = await _context.TipoMascota.FindAsync(id);
            if (tipoMascotum != null)
            {
                _context.TipoMascota.Remove(tipoMascotum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMascotumExists(int id)
        {
            return _context.TipoMascota.Any(e => e.IdTipo == id);
        }
    }
}
