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
    public class AtencionReservaController : Controller
    {
        private readonly MorfeoContext _context;

        public AtencionReservaController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: AtencionReserva
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.AtencionReservas.Include(a => a.IdEmpleadoNavigation).Include(a => a.IdReservaNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: AtencionReserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atencionReserva = await _context.AtencionReservas
                .Include(a => a.IdEmpleadoNavigation)
                .Include(a => a.IdReservaNavigation)
                .FirstOrDefaultAsync(m => m.IdAtencion == id);
            if (atencionReserva == null)
            {
                return NotFound();
            }

            return View(atencionReserva);
        }

        // GET: AtencionReserva/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado");
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva");
            return View();
        }

        // POST: AtencionReserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAtencion,FechaAtencion,IdEmpleado,IdReserva")] AtencionReserva atencionReserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atencionReserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", atencionReserva.IdEmpleado);
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", atencionReserva.IdReserva);
            return View(atencionReserva);
        }

        // GET: AtencionReserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atencionReserva = await _context.AtencionReservas.FindAsync(id);
            if (atencionReserva == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", atencionReserva.IdEmpleado);
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", atencionReserva.IdReserva);
            return View(atencionReserva);
        }

        // POST: AtencionReserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAtencion,FechaAtencion,IdEmpleado,IdReserva")] AtencionReserva atencionReserva)
        {
            if (id != atencionReserva.IdAtencion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atencionReserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtencionReservaExists(atencionReserva.IdAtencion))
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
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", atencionReserva.IdEmpleado);
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", atencionReserva.IdReserva);
            return View(atencionReserva);
        }

        // GET: AtencionReserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atencionReserva = await _context.AtencionReservas
                .Include(a => a.IdEmpleadoNavigation)
                .Include(a => a.IdReservaNavigation)
                .FirstOrDefaultAsync(m => m.IdAtencion == id);
            if (atencionReserva == null)
            {
                return NotFound();
            }

            return View(atencionReserva);
        }

        // POST: AtencionReserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atencionReserva = await _context.AtencionReservas.FindAsync(id);
            if (atencionReserva != null)
            {
                _context.AtencionReservas.Remove(atencionReserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtencionReservaExists(int id)
        {
            return _context.AtencionReservas.Any(e => e.IdAtencion == id);
        }
    }
}
