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
    public class HistorialPagosController : Controller
    {
        private readonly MorfeoContext _context;

        public HistorialPagosController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: HistorialPagos
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.HistorialPagos.Include(h => h.IdEstadoPagadoNavigation).Include(h => h.IdMetodoPagoNavigation).Include(h => h.IdReservaNavigation).Include(h => h.IdTipoPagoNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: HistorialPagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialPago = await _context.HistorialPagos
                .Include(h => h.IdEstadoPagadoNavigation)
                .Include(h => h.IdMetodoPagoNavigation)
                .Include(h => h.IdReservaNavigation)
                .Include(h => h.IdTipoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdPago == id);
            if (historialPago == null)
            {
                return NotFound();
            }

            return View(historialPago);
        }

        // GET: HistorialPagos/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoPagado"] = new SelectList(_context.EstadoPagos, "IdEstadoPago", "IdEstadoPago");
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago");
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva");
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPagos, "IdTipoPago", "IdTipoPago");
            return View();
        }

        // POST: HistorialPagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPago,IdReserva,FechaPago,Monto,IdTipoPago,IdMetodoPago,IdEstadoPagado")] HistorialPago historialPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historialPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoPagado"] = new SelectList(_context.EstadoPagos, "IdEstadoPago", "IdEstadoPago", historialPago.IdEstadoPagado);
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago", historialPago.IdMetodoPago);
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", historialPago.IdReserva);
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPagos, "IdTipoPago", "IdTipoPago", historialPago.IdTipoPago);
            return View(historialPago);
        }

        // GET: HistorialPagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialPago = await _context.HistorialPagos.FindAsync(id);
            if (historialPago == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoPagado"] = new SelectList(_context.EstadoPagos, "IdEstadoPago", "IdEstadoPago", historialPago.IdEstadoPagado);
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago", historialPago.IdMetodoPago);
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", historialPago.IdReserva);
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPagos, "IdTipoPago", "IdTipoPago", historialPago.IdTipoPago);
            return View(historialPago);
        }

        // POST: HistorialPagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPago,IdReserva,FechaPago,Monto,IdTipoPago,IdMetodoPago,IdEstadoPagado")] HistorialPago historialPago)
        {
            if (id != historialPago.IdPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historialPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialPagoExists(historialPago.IdPago))
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
            ViewData["IdEstadoPagado"] = new SelectList(_context.EstadoPagos, "IdEstadoPago", "IdEstadoPago", historialPago.IdEstadoPagado);
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago", historialPago.IdMetodoPago);
            ViewData["IdReserva"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva", historialPago.IdReserva);
            ViewData["IdTipoPago"] = new SelectList(_context.TipoPagos, "IdTipoPago", "IdTipoPago", historialPago.IdTipoPago);
            return View(historialPago);
        }

        // GET: HistorialPagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialPago = await _context.HistorialPagos
                .Include(h => h.IdEstadoPagadoNavigation)
                .Include(h => h.IdMetodoPagoNavigation)
                .Include(h => h.IdReservaNavigation)
                .Include(h => h.IdTipoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdPago == id);
            if (historialPago == null)
            {
                return NotFound();
            }

            return View(historialPago);
        }

        // POST: HistorialPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historialPago = await _context.HistorialPagos.FindAsync(id);
            if (historialPago != null)
            {
                _context.HistorialPagos.Remove(historialPago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialPagoExists(int id)
        {
            return _context.HistorialPagos.Any(e => e.IdPago == id);
        }
    }
}
