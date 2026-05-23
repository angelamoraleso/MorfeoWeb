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
    public class DetalleServicioReservaController : Controller
    {
        private readonly MorfeoContext _context;

        public DetalleServicioReservaController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: DetalleServicioReserva
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.DetalleServicioReservas.Include(d => d.IdReservaNavigation).Include(d => d.IdServicioNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: DetalleServicioReserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleServicioReserva = await _context.DetalleServicioReservas
                .Include(d => d.IdReservaNavigation)
                .Include(d => d.IdServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (detalleServicioReserva == null)
            {
                return NotFound();
            }

            return View(detalleServicioReserva);
        }

        // GET: DetalleServicioReserva/Create
        public IActionResult Create()
        {
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva");
            ViewData["IdServicio"] = new SelectList(_context.ServicioAdicionals, "IdServicio", "IdServicio");
            return View();
        }

        // POST: DetalleServicioReserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReserva,IdServicio,PrecioUnitario,Cantidad")] DetalleServicioReserva detalleServicioReserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleServicioReserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", detalleServicioReserva.IdReserva);
            ViewData["IdServicio"] = new SelectList(_context.ServicioAdicionals, "IdServicio", "IdServicio", detalleServicioReserva.IdServicio);
            return View(detalleServicioReserva);
        }

        // GET: DetalleServicioReserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleServicioReserva = await _context.DetalleServicioReservas.FindAsync(id);
            if (detalleServicioReserva == null)
            {
                return NotFound();
            }
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", detalleServicioReserva.IdReserva);
            ViewData["IdServicio"] = new SelectList(_context.ServicioAdicionals, "IdServicio", "IdServicio", detalleServicioReserva.IdServicio);
            return View(detalleServicioReserva);
        }

        // POST: DetalleServicioReserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,IdServicio,PrecioUnitario,Cantidad")] DetalleServicioReserva detalleServicioReserva)
        {
            if (id != detalleServicioReserva.IdReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleServicioReserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleServicioReservaExists(detalleServicioReserva.IdReserva))
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
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", detalleServicioReserva.IdReserva);
            ViewData["IdServicio"] = new SelectList(_context.ServicioAdicionals, "IdServicio", "IdServicio", detalleServicioReserva.IdServicio);
            return View(detalleServicioReserva);
        }

        // GET: DetalleServicioReserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleServicioReserva = await _context.DetalleServicioReservas
                .Include(d => d.IdReservaNavigation)
                .Include(d => d.IdServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (detalleServicioReserva == null)
            {
                return NotFound();
            }

            return View(detalleServicioReserva);
        }

        // POST: DetalleServicioReserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleServicioReserva = await _context.DetalleServicioReservas.FindAsync(id);
            if (detalleServicioReserva != null)
            {
                _context.DetalleServicioReservas.Remove(detalleServicioReserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleServicioReservaExists(int id)
        {
            return _context.DetalleServicioReservas.Any(e => e.IdReserva == id);
        }
    }
}
