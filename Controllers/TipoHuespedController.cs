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
    public class TipoHuespedController : Controller
    {
        private readonly MorfeoContext _context;

        public TipoHuespedController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: TipoHuesped
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoHuespeds.ToListAsync());
        }

        // GET: TipoHuesped/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoHuesped = await _context.TipoHuespeds
                .FirstOrDefaultAsync(m => m.IdTipoHuesped == id);
            if (tipoHuesped == null)
            {
                return NotFound();
            }

            return View(tipoHuesped);
        }

        // GET: TipoHuesped/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoHuesped/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoHuesped,Descripcion")] TipoHuesped tipoHuesped)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoHuesped);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoHuesped);
        }

        // GET: TipoHuesped/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoHuesped = await _context.TipoHuespeds.FindAsync(id);
            if (tipoHuesped == null)
            {
                return NotFound();
            }
            return View(tipoHuesped);
        }

        // POST: TipoHuesped/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoHuesped,Descripcion")] TipoHuesped tipoHuesped)
        {
            if (id != tipoHuesped.IdTipoHuesped)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoHuesped);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoHuespedExists(tipoHuesped.IdTipoHuesped))
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
            return View(tipoHuesped);
        }

        // GET: TipoHuesped/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoHuesped = await _context.TipoHuespeds
                .FirstOrDefaultAsync(m => m.IdTipoHuesped == id);
            if (tipoHuesped == null)
            {
                return NotFound();
            }

            return View(tipoHuesped);
        }

        // POST: TipoHuesped/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoHuesped = await _context.TipoHuespeds.FindAsync(id);
            if (tipoHuesped != null)
            {
                _context.TipoHuespeds.Remove(tipoHuesped);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoHuespedExists(int id)
        {
            return _context.TipoHuespeds.Any(e => e.IdTipoHuesped == id);
        }
    }
}
