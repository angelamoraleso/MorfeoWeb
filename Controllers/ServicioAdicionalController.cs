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
    public class ServicioAdicionalController : Controller
    {
        private readonly MorfeoContext _context;

        public ServicioAdicionalController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: ServicioAdicional
        public async Task<IActionResult> Index()
        {
            var morfeoContext = _context.ServicioAdicionals.Include(s => s.IdTipoServicioNavigation);
            return View(await morfeoContext.ToListAsync());
        }

        // GET: ServicioAdicional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioAdicional = await _context.ServicioAdicionals
                .Include(s => s.IdTipoServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdServicio == id);
            if (servicioAdicional == null)
            {
                return NotFound();
            }

            return View(servicioAdicional);
        }

        // GET: ServicioAdicional/Create
        public IActionResult Create()
        {
            ViewData["IdTipoServicio"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "IdTipoServicio");
            return View();
        }

        // POST: ServicioAdicional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdServicio,Precio,Descripcion,IdTipoServicio")] ServicioAdicional servicioAdicional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioAdicional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoServicio"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "IdTipoServicio", servicioAdicional.IdTipoServicio);
            return View(servicioAdicional);
        }

        // GET: ServicioAdicional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioAdicional = await _context.ServicioAdicionals.FindAsync(id);
            if (servicioAdicional == null)
            {
                return NotFound();
            }
            ViewData["IdTipoServicio"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "IdTipoServicio", servicioAdicional.IdTipoServicio);
            return View(servicioAdicional);
        }

        // POST: ServicioAdicional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdServicio,Precio,Descripcion,IdTipoServicio")] ServicioAdicional servicioAdicional)
        {
            if (id != servicioAdicional.IdServicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioAdicional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioAdicionalExists(servicioAdicional.IdServicio))
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
            ViewData["IdTipoServicio"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "IdTipoServicio", servicioAdicional.IdTipoServicio);
            return View(servicioAdicional);
        }

        // GET: ServicioAdicional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicioAdicional = await _context.ServicioAdicionals
                .Include(s => s.IdTipoServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdServicio == id);
            if (servicioAdicional == null)
            {
                return NotFound();
            }

            return View(servicioAdicional);
        }

        // POST: ServicioAdicional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicioAdicional = await _context.ServicioAdicionals.FindAsync(id);
            if (servicioAdicional != null)
            {
                _context.ServicioAdicionals.Remove(servicioAdicional);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioAdicionalExists(int id)
        {
            return _context.ServicioAdicionals.Any(e => e.IdServicio == id);
        }
    }
}
