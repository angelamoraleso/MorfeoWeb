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
    public class HabitacionController : Controller
    {
        private readonly MorfeoContext _context;

        public HabitacionController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: Habitacion
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.Habitacions.Include(h => h.IdEstadoNavigation).Include(h => h.IdHotelNavigation).Include(h => h.IdTipoHabitacionNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: Habitacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacions
                .Include(h => h.IdEstadoNavigation)
                .Include(h => h.IdHotelNavigation)
                .Include(h => h.IdTipoHabitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // GET: Habitacion/Create
        public IActionResult Create()
        {
            ViewData["IdEstado"] = new SelectList(_context.EstadoHabitacions, "IdEstado", "IdEstado");
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel");
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "IdTipoHabitacion");
            return View();
        }

        // POST: Habitacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHabitacion,Capacidad,PrecioNoche,IdEstado,IdTipoHabitacion,IdHotel")] Habitacion habitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstado"] = new SelectList(_context.EstadoHabitacions, "IdEstado", "IdEstado", habitacion.IdEstado);
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel", habitacion.IdHotel);
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "IdTipoHabitacion", habitacion.IdTipoHabitacion);
            return View(habitacion);
        }

        // GET: Habitacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacions.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            ViewData["IdEstado"] = new SelectList(_context.EstadoHabitacions, "IdEstado", "IdEstado", habitacion.IdEstado);
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel", habitacion.IdHotel);
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "IdTipoHabitacion", habitacion.IdTipoHabitacion);
            return View(habitacion);
        }

        // POST: Habitacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHabitacion,Capacidad,PrecioNoche,IdEstado,IdTipoHabitacion,IdHotel")] Habitacion habitacion)
        {
            if (id != habitacion.IdHabitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionExists(habitacion.IdHabitacion))
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
            ViewData["IdEstado"] = new SelectList(_context.EstadoHabitacions, "IdEstado", "IdEstado", habitacion.IdEstado);
            ViewData["IdHotel"] = new SelectList(_context.Hotels, "IdHotel", "IdHotel", habitacion.IdHotel);
            ViewData["IdTipoHabitacion"] = new SelectList(_context.TipoHabitacions, "IdTipoHabitacion", "IdTipoHabitacion", habitacion.IdTipoHabitacion);
            return View(habitacion);
        }

        // GET: Habitacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacions
                .Include(h => h.IdEstadoNavigation)
                .Include(h => h.IdHotelNavigation)
                .Include(h => h.IdTipoHabitacionNavigation)
                .FirstOrDefaultAsync(m => m.IdHabitacion == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // POST: Habitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habitacion = await _context.Habitacions.FindAsync(id);
            if (habitacion != null)
            {
                _context.Habitacions.Remove(habitacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacionExists(int id)
        {
            return _context.Habitacions.Any(e => e.IdHabitacion == id);
        }
    }
}
