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
    public class EstadoPagoController : Controller
    {
        private readonly MorfeoContext _context;

        public EstadoPagoController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: EstadoPago
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoPagos.ToListAsync());
        }

        // GET: EstadoPago/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPago = await _context.EstadoPagos
                .FirstOrDefaultAsync(m => m.IdEstadoPago == id);
            if (estadoPago == null)
            {
                return NotFound();
            }

            return View(estadoPago);
        }

        // GET: EstadoPago/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoPago/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadoPago,Descripcion")] EstadoPago estadoPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoPago);
        }

        // GET: EstadoPago/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPago = await _context.EstadoPagos.FindAsync(id);
            if (estadoPago == null)
            {
                return NotFound();
            }
            return View(estadoPago);
        }

        // POST: EstadoPago/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadoPago,Descripcion")] EstadoPago estadoPago)
        {
            if (id != estadoPago.IdEstadoPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoPagoExists(estadoPago.IdEstadoPago))
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
            return View(estadoPago);
        }

        // GET: EstadoPago/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoPago = await _context.EstadoPagos
                .FirstOrDefaultAsync(m => m.IdEstadoPago == id);
            if (estadoPago == null)
            {
                return NotFound();
            }

            return View(estadoPago);
        }

        // POST: EstadoPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoPago = await _context.EstadoPagos.FindAsync(id);
            if (estadoPago != null)
            {
                _context.EstadoPagos.Remove(estadoPago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoPagoExists(int id)
        {
            return _context.EstadoPagos.Any(e => e.IdEstadoPago == id);
        }
    }
}
