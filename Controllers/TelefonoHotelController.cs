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
    public class TelefonoHotelController : Controller
    {
        private readonly MorfeoContext _context;

        public TelefonoHotelController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: TelefonoHotel
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.TelefonoHotels.Include(t => t.IdHotelNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: TelefonoHotel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoHotel = await _context.TelefonoHotels
                .Include(t => t.IdHotelNavigation)
                .FirstOrDefaultAsync(m => m.IdTelefonoHotel == id);
            if (telefonoHotel == null)
            {
                return NotFound();
            }

            return View(telefonoHotel);
        }

        // GET: TelefonoHotel/Create
        public IActionResult Create()
        {
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel");
            return View();
        }

        // POST: TelefonoHotel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTelefonoHotel,Numero,IdHotel")] TelefonoHotel telefonoHotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefonoHotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel", telefonoHotel.IdHotel);
            return View(telefonoHotel);
        }

        // GET: TelefonoHotel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoHotel = await _context.TelefonoHotels.FindAsync(id);
            if (telefonoHotel == null)
            {
                return NotFound();
            }
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel", telefonoHotel.IdHotel);
            return View(telefonoHotel);
        }

        // POST: TelefonoHotel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTelefonoHotel,Numero,IdHotel")] TelefonoHotel telefonoHotel)
        {
            if (id != telefonoHotel.IdTelefonoHotel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefonoHotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoHotelExists(telefonoHotel.IdTelefonoHotel))
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
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel", telefonoHotel.IdHotel);
            return View(telefonoHotel);
        }

        // GET: TelefonoHotel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoHotel = await _context.TelefonoHotels
                .Include(t => t.IdHotelNavigation)
                .FirstOrDefaultAsync(m => m.IdTelefonoHotel == id);
            if (telefonoHotel == null)
            {
                return NotFound();
            }

            return View(telefonoHotel);
        }

        // POST: TelefonoHotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefonoHotel = await _context.TelefonoHotels.FindAsync(id);
            if (telefonoHotel != null)
            {
                _context.TelefonoHotels.Remove(telefonoHotel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoHotelExists(int id)
        {
            return _context.TelefonoHotels.Any(e => e.IdTelefonoHotel == id);
        }
    }
}
