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
    public class AgenciaViajesController : Controller
    {
        private readonly MorfeoContext _context;

        public AgenciaViajesController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: AgenciaViajes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AgenciaViajes.ToListAsync());
        }

        // GET: AgenciaViajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenciaViaje = await _context.AgenciaViajes
                .FirstOrDefaultAsync(m => m.IdAgencia == id);
            if (agenciaViaje == null)
            {
                return NotFound();
            }

            return View(agenciaViaje);
        }

        // GET: AgenciaViajes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AgenciaViajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAgencia,Nombre")] AgenciaViaje agenciaViaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agenciaViaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agenciaViaje);
        }

        // GET: AgenciaViajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenciaViaje = await _context.AgenciaViajes.FindAsync(id);
            if (agenciaViaje == null)
            {
                return NotFound();
            }
            return View(agenciaViaje);
        }

        // POST: AgenciaViajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAgencia,Nombre")] AgenciaViaje agenciaViaje)
        {
            if (id != agenciaViaje.IdAgencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agenciaViaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgenciaViajeExists(agenciaViaje.IdAgencia))
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
            return View(agenciaViaje);
        }

        // GET: AgenciaViajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenciaViaje = await _context.AgenciaViajes
                .FirstOrDefaultAsync(m => m.IdAgencia == id);
            if (agenciaViaje == null)
            {
                return NotFound();
            }

            return View(agenciaViaje);
        }

        // POST: AgenciaViajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agenciaViaje = await _context.AgenciaViajes.FindAsync(id);
            if (agenciaViaje != null)
            {
                _context.AgenciaViajes.Remove(agenciaViaje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgenciaViajeExists(int id)
        {
            return _context.AgenciaViajes.Any(e => e.IdAgencia == id);
        }
    }
}
