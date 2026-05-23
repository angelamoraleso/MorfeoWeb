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
    public class TelefonoEmpleadoController : Controller
    {
        private readonly MorfeoContext _context;

        public TelefonoEmpleadoController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: TelefonoEmpleado
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.TelefonoEmpleados.Include(t => t.IdEmpleadoNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: TelefonoEmpleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoEmpleado = await _context.TelefonoEmpleados
                .Include(t => t.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdTelefonoEmpleado == id);
            if (telefonoEmpleado == null)
            {
                return NotFound();
            }

            return View(telefonoEmpleado);
        }

        // GET: TelefonoEmpleado/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado");
            return View();
        }

        // POST: TelefonoEmpleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTelefonoEmpleado,Numero,IdEmpleado")] TelefonoEmpleado telefonoEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefonoEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", telefonoEmpleado.IdEmpleado);
            return View(telefonoEmpleado);
        }

        // GET: TelefonoEmpleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoEmpleado = await _context.TelefonoEmpleados.FindAsync(id);
            if (telefonoEmpleado == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", telefonoEmpleado.IdEmpleado);
            return View(telefonoEmpleado);
        }

        // POST: TelefonoEmpleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTelefonoEmpleado,Numero,IdEmpleado")] TelefonoEmpleado telefonoEmpleado)
        {
            if (id != telefonoEmpleado.IdTelefonoEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefonoEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoEmpleadoExists(telefonoEmpleado.IdTelefonoEmpleado))
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
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", telefonoEmpleado.IdEmpleado);
            return View(telefonoEmpleado);
        }

        // GET: TelefonoEmpleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoEmpleado = await _context.TelefonoEmpleados
                .Include(t => t.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdTelefonoEmpleado == id);
            if (telefonoEmpleado == null)
            {
                return NotFound();
            }

            return View(telefonoEmpleado);
        }

        // POST: TelefonoEmpleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefonoEmpleado = await _context.TelefonoEmpleados.FindAsync(id);
            if (telefonoEmpleado != null)
            {
                _context.TelefonoEmpleados.Remove(telefonoEmpleado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoEmpleadoExists(int id)
        {
            return _context.TelefonoEmpleados.Any(e => e.IdTelefonoEmpleado == id);
        }
    }
}
