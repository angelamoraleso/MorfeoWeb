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
    public class EstadoHabitacionController : Controller
    {
        private readonly MorfeoContext _context;

        public EstadoHabitacionController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: EstadoHabitacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoHabitacions.ToListAsync());
        }

        // GET: EstadoHabitacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoHabitacion = await _context.EstadoHabitacions
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (estadoHabitacion == null)
            {
                return NotFound();
            }

            return View(estadoHabitacion);
        }

        // GET: EstadoHabitacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoHabitacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstado,NombreEstado")] EstadoHabitacion estadoHabitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoHabitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoHabitacion);
        }

        // GET: EstadoHabitacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoHabitacion = await _context.EstadoHabitacions.FindAsync(id);
            if (estadoHabitacion == null)
            {
                return NotFound();
            }
            return View(estadoHabitacion);
        }

        // POST: EstadoHabitacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstado,NombreEstado")] EstadoHabitacion estadoHabitacion)
        {
            if (id != estadoHabitacion.IdEstado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoHabitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoHabitacionExists(estadoHabitacion.IdEstado))
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
            return View(estadoHabitacion);
        }

        // GET: EstadoHabitacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoHabitacion = await _context.EstadoHabitacions
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (estadoHabitacion == null)
            {
                return NotFound();
            }

            return View(estadoHabitacion);
        }

        // POST: EstadoHabitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoHabitacion = await _context.EstadoHabitacions.FindAsync(id);
            if (estadoHabitacion != null)
            {
                _context.EstadoHabitacions.Remove(estadoHabitacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoHabitacionExists(int id)
        {
            return _context.EstadoHabitacions.Any(e => e.IdEstado == id);
        }
    }
}
