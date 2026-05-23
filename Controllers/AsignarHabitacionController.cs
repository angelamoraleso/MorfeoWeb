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
    public class AsignarHabitacionController : Controller
    {
        private readonly MorfeoContext _context;

        public AsignarHabitacionController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: AsignarHabitacion
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.AsignarHabitacions.Include(a => a.IdHabitacionNavigation).Include(a => a.IdHuespedNavigation).Include(a => a.IdReservaNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: AsignarHabitacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignarHabitacion = await _context.AsignarHabitacions
                .Include(a => a.IdHabitacionNavigation)
                .Include(a => a.IdHuespedNavigation)
                .Include(a => a.IdReservaNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignarHabitacion == null)
            {
                return NotFound();
            }

            return View(asignarHabitacion);
        }

        // GET: AsignarHabitacion/Create
        public IActionResult Create()
        {
            ViewData["IdHabitacion"] = new SelectList(_context.Habitacions, "IdHabitacion", "IdHabitacion");
            ViewData["IdHuesped"] = new SelectList(_context.Huespeds, "IdHuesped", "IdHuesped");
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva");
            return View();
        }

        // POST: AsignarHabitacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsignacion,IdHuesped,IdReserva,IdHabitacion")] AsignarHabitacion asignarHabitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignarHabitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHabitacion"] = new SelectList(_context.Habitacions, "IdHabitacion", "IdHabitacion", asignarHabitacion.IdHabitacion);
            ViewData["IdHuesped"] = new SelectList(_context.Huespeds, "IdHuesped", "IdHuesped", asignarHabitacion.IdHuesped);
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", asignarHabitacion.IdReserva);
            return View(asignarHabitacion);
        }

        // GET: AsignarHabitacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignarHabitacion = await _context.AsignarHabitacions.FindAsync(id);
            if (asignarHabitacion == null)
            {
                return NotFound();
            }
            ViewData["IdHabitacion"] = new SelectList(_context.Habitacions, "IdHabitacion", "IdHabitacion", asignarHabitacion.IdHabitacion);
            ViewData["IdHuesped"] = new SelectList(_context.Huespeds, "IdHuesped", "IdHuesped", asignarHabitacion.IdHuesped);
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", asignarHabitacion.IdReserva);
            return View(asignarHabitacion);
        }

        // POST: AsignarHabitacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsignacion,IdHuesped,IdReserva,IdHabitacion")] AsignarHabitacion asignarHabitacion)
        {
            if (id != asignarHabitacion.IdAsignacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignarHabitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignarHabitacionExists(asignarHabitacion.IdAsignacion))
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
            ViewData["IdHabitacion"] = new SelectList(_context.Habitacions, "IdHabitacion", "IdHabitacion", asignarHabitacion.IdHabitacion);
            ViewData["IdHuesped"] = new SelectList(_context.Huespeds, "IdHuesped", "IdHuesped", asignarHabitacion.IdHuesped);
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", asignarHabitacion.IdReserva);
            return View(asignarHabitacion);
        }

        // GET: AsignarHabitacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignarHabitacion = await _context.AsignarHabitacions
                .Include(a => a.IdHabitacionNavigation)
                .Include(a => a.IdHuespedNavigation)
                .Include(a => a.IdReservaNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignarHabitacion == null)
            {
                return NotFound();
            }

            return View(asignarHabitacion);
        }

        // POST: AsignarHabitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignarHabitacion = await _context.AsignarHabitacions.FindAsync(id);
            if (asignarHabitacion != null)
            {
                _context.AsignarHabitacions.Remove(asignarHabitacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignarHabitacionExists(int id)
        {
            return _context.AsignarHabitacions.Any(e => e.IdAsignacion == id);
        }
    }
}
