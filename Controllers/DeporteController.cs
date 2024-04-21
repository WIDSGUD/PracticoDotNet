using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticoDotNet.Data;
using PracticoDotNet.Models;

namespace PracticoDotNet.Controllers
{
    public class DeporteController : Controller
    {
        private readonly AppDbContext _db;

        public DeporteController(AppDbContext context)
        {
            _db = context;
        }

        // GET: Deporte
        public async Task<IActionResult> Index(string buscar)
        {
            var deporteBuscado = from deporte in _db.Deporte select deporte;
            if (!String.IsNullOrEmpty(buscar)){
                deporteBuscado = deporteBuscado.Where(s => s.Nombre.Contains(buscar));
            }
            
            return View(await deporteBuscado.ToListAsync());
        }

        // GET: Deporte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deporte = await _db.Deporte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deporte == null)
            {
                return NotFound();
            }

            return View(deporte);
        }

        // GET: Deporte/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deporte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Deporte deporte)
        {
            if (ModelState.IsValid)
            {
                _db.Add(deporte);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deporte);
        }

        // GET: Deporte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deporte = await _db.Deporte.FindAsync(id);
            if (deporte == null)
            {
                return NotFound();
            }
            return View(deporte);
        }

        // POST: Deporte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Deporte deporte)
        {
            if (id != deporte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(deporte);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeporteExists(deporte.Id))
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
            return View(deporte);
        }

        // GET: Deporte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deporte = await _db.Deporte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deporte == null)
            {
                return NotFound();
            }

            return View(deporte);
        }

        // POST: Deporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deporte = await _db.Deporte.FindAsync(id);
            if (deporte != null)
            {
                _db.Deporte.Remove(deporte);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeporteExists(int id)
        {
            return _db.Deporte.Any(e => e.Id == id);
        }
    }
}
