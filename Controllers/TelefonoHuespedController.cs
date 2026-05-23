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
    public class TelefonoHuespedController : Controller
    {
        private readonly MorfeoContext _context;

        public TelefonoHuespedController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: TelefonoHuesped
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.TelefonoHuespeds.Include(t => t.IdHuespedNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: TelefonoHuesped/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoHuesped = await _context.TelefonoHuespeds
                .Include(t => t.IdHuespedNavigation)
                .FirstOrDefaultAsync(m => m.IdTelefonoHuesped == id);
            if (telefonoHuesped == null)
            {
                return NotFound();
            }

            return View(telefonoHuesped);
        }

        // GET: TelefonoHuesped/Create
        public IActionResult Create()
        {
            ViewData["IdHuesped"] = new SelectList(_context.Huespeds, "IdHuesped", "IdHuesped");
            return View();
        }

        // POST: TelefonoHuesped/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTelefonoHuesped,Numero,IdHuesped")] TelefonoHuesped telefonoHuesped)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefonoHuesped);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHuesped"] = new SelectList(_context.Huespeds, "IdHuesped", "IdHuesped", telefonoHuesped.IdHuesped);
            return View(telefonoHuesped);
        }

        // GET: TelefonoHuesped/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoHuesped = await _context.TelefonoHuespeds.FindAsync(id);
            if (telefonoHuesped == null)
            {
                return NotFound();
            }
            ViewData["IdHuesped"] = new SelectList(_context.Huespeds, "IdHuesped", "IdHuesped", telefonoHuesped.IdHuesped);
            return View(telefonoHuesped);
        }

        // POST: TelefonoHuesped/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTelefonoHuesped,Numero,IdHuesped")] TelefonoHuesped telefonoHuesped)
        {
            if (id != telefonoHuesped.IdTelefonoHuesped)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefonoHuesped);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoHuespedExists(telefonoHuesped.IdTelefonoHuesped))
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
            ViewData["IdHuesped"] = new SelectList(_context.Huespeds, "IdHuesped", "IdHuesped", telefonoHuesped.IdHuesped);
            return View(telefonoHuesped);
        }

        // GET: TelefonoHuesped/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoHuesped = await _context.TelefonoHuespeds
                .Include(t => t.IdHuespedNavigation)
                .FirstOrDefaultAsync(m => m.IdTelefonoHuesped == id);
            if (telefonoHuesped == null)
            {
                return NotFound();
            }

            return View(telefonoHuesped);
        }

        // POST: TelefonoHuesped/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefonoHuesped = await _context.TelefonoHuespeds.FindAsync(id);
            if (telefonoHuesped != null)
            {
                _context.TelefonoHuespeds.Remove(telefonoHuesped);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoHuespedExists(int id)
        {
            return _context.TelefonoHuespeds.Any(e => e.IdTelefonoHuesped == id);
        }
    }
}
