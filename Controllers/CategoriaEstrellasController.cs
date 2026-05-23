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
    public class CategoriaEstrellasController : Controller
    {
        private readonly MorfeoContext _context;

        public CategoriaEstrellasController(MorfeoContext context)
        {
            _context = context;
        }

        // GET: CategoriaEstrellas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaEstrellas.ToListAsync());
        }

        // GET: CategoriaEstrellas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaEstrella = await _context.CategoriaEstrellas
                .FirstOrDefaultAsync(m => m.IdEstrellas == id);
            if (categoriaEstrella == null)
            {
                return NotFound();
            }

            return View(categoriaEstrella);
        }

        // GET: CategoriaEstrellas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaEstrellas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstrellas,Nivel")] CategoriaEstrella categoriaEstrella)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaEstrella);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaEstrella);
        }

        // GET: CategoriaEstrellas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaEstrella = await _context.CategoriaEstrellas.FindAsync(id);
            if (categoriaEstrella == null)
            {
                return NotFound();
            }
            return View(categoriaEstrella);
        }

        // POST: CategoriaEstrellas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstrellas,Nivel")] CategoriaEstrella categoriaEstrella)
        {
            if (id != categoriaEstrella.IdEstrellas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaEstrella);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaEstrellaExists(categoriaEstrella.IdEstrellas))
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
            return View(categoriaEstrella);
        }

        // GET: CategoriaEstrellas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaEstrella = await _context.CategoriaEstrellas
                .FirstOrDefaultAsync(m => m.IdEstrellas == id);
            if (categoriaEstrella == null)
            {
                return NotFound();
            }

            return View(categoriaEstrella);
        }

        // POST: CategoriaEstrellas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaEstrella = await _context.CategoriaEstrellas.FindAsync(id);
            if (categoriaEstrella != null)
            {
                _context.CategoriaEstrellas.Remove(categoriaEstrella);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaEstrellaExists(int id)
        {
            return _context.CategoriaEstrellas.Any(e => e.IdEstrellas == id);
        }
    }
}
