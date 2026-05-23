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
    public class AsignarTurnoController : Controller
    {
        private readonly MorfeoContext _context;

        public AsignarTurnoController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: AsignarTurno
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.AsignarTurnos.Include(a => a.IdEmpleadoNavigation).Include(a => a.IdTurnoNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: AsignarTurno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignarTurno = await _context.AsignarTurnos
                .Include(a => a.IdEmpleadoNavigation)
                .Include(a => a.IdTurnoNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacionTurno == id);
            if (asignarTurno == null)
            {
                return NotFound();
            }

            return View(asignarTurno);
        }

        // GET: AsignarTurno/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado");
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno");
            return View();
        }

        // POST: AsignarTurno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsignacionTurno,Fecha,IdEmpleado,IdTurno")] AsignarTurno asignarTurno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignarTurno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", asignarTurno.IdEmpleado);
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", asignarTurno.IdTurno);
            return View(asignarTurno);
        }

        // GET: AsignarTurno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignarTurno = await _context.AsignarTurnos.FindAsync(id);
            if (asignarTurno == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", asignarTurno.IdEmpleado);
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", asignarTurno.IdTurno);
            return View(asignarTurno);
        }

        // POST: AsignarTurno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsignacionTurno,Fecha,IdEmpleado,IdTurno")] AsignarTurno asignarTurno)
        {
            if (id != asignarTurno.IdAsignacionTurno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignarTurno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignarTurnoExists(asignarTurno.IdAsignacionTurno))
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
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", asignarTurno.IdEmpleado);
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", asignarTurno.IdTurno);
            return View(asignarTurno);
        }

        // GET: AsignarTurno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignarTurno = await _context.AsignarTurnos
                .Include(a => a.IdEmpleadoNavigation)
                .Include(a => a.IdTurnoNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacionTurno == id);
            if (asignarTurno == null)
            {
                return NotFound();
            }

            return View(asignarTurno);
        }

        // POST: AsignarTurno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignarTurno = await _context.AsignarTurnos.FindAsync(id);
            if (asignarTurno != null)
            {
                _context.AsignarTurnos.Remove(asignarTurno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignarTurnoExists(int id)
        {
            return _context.AsignarTurnos.Any(e => e.IdAsignacionTurno == id);
        }
    }
}
