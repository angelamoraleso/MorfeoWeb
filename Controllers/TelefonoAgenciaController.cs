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
    public class TelefonoAgenciaController : Controller
    {
        private readonly MorfeoContext _context;

        public TelefonoAgenciaController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: TelefonoAgencia
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.TelefonoAgencias.Include(t => t.IdAgenciaNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: TelefonoAgencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoAgencia = await _context.TelefonoAgencias
                .Include(t => t.IdAgenciaNavigation)
                .FirstOrDefaultAsync(m => m.IdTelefonoAgencia == id);
            if (telefonoAgencia == null)
            {
                return NotFound();
            }

            return View(telefonoAgencia);
        }

        // GET: TelefonoAgencia/Create
        public IActionResult Create()
        {
            ViewData["IdAgencia"] = new SelectList(_context.AgenciaViajes, "IdAgencia", "IdAgencia");
            return View();
        }

        // POST: TelefonoAgencia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTelefonoAgencia,Numero,IdAgencia")] TelefonoAgencia telefonoAgencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefonoAgencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAgencia"] = new SelectList(_context.AgenciaViajes, "IdAgencia", "IdAgencia", telefonoAgencia.IdAgencia);
            return View(telefonoAgencia);
        }

        // GET: TelefonoAgencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoAgencia = await _context.TelefonoAgencias.FindAsync(id);
            if (telefonoAgencia == null)
            {
                return NotFound();
            }
            ViewData["IdAgencia"] = new SelectList(_context.AgenciaViajes, "IdAgencia", "IdAgencia", telefonoAgencia.IdAgencia);
            return View(telefonoAgencia);
        }

        // POST: TelefonoAgencia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTelefonoAgencia,Numero,IdAgencia")] TelefonoAgencia telefonoAgencia)
        {
            if (id != telefonoAgencia.IdTelefonoAgencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefonoAgencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoAgenciaExists(telefonoAgencia.IdTelefonoAgencia))
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
            ViewData["IdAgencia"] = new SelectList(_context.AgenciaViajes, "IdAgencia", "IdAgencia", telefonoAgencia.IdAgencia);
            return View(telefonoAgencia);
        }

        // GET: TelefonoAgencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoAgencia = await _context.TelefonoAgencias
                .Include(t => t.IdAgenciaNavigation)
                .FirstOrDefaultAsync(m => m.IdTelefonoAgencia == id);
            if (telefonoAgencia == null)
            {
                return NotFound();
            }

            return View(telefonoAgencia);
        }

        // POST: TelefonoAgencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefonoAgencia = await _context.TelefonoAgencias.FindAsync(id);
            if (telefonoAgencia != null)
            {
                _context.TelefonoAgencias.Remove(telefonoAgencia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoAgenciaExists(int id)
        {
            return _context.TelefonoAgencias.Any(e => e.IdTelefonoAgencia == id);
        }
    }
}
