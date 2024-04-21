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
    public class ConfederacionController : Controller
    {
        private readonly AppDbContext _db;

        public ConfederacionController(AppDbContext context)
        {
            _db = context;
        }

        // GET: Confederacion
        public async Task<IActionResult> Index()
        {
            return View(await _db.Confederacion.ToListAsync());
        }

        // GET: Confederacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confederacion = await _db.Confederacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confederacion == null)
            {
                return NotFound();
            }

            return View(confederacion);
        }

        // GET: Confederacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Confederacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Fundacion")] Confederacion confederacion)
        {
            if (ModelState.IsValid)
            {
                _db.Add(confederacion);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(confederacion);
        }

        // GET: Confederacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confederacion = await _db.Confederacion.FindAsync(id);
            if (confederacion == null)
            {
                return NotFound();
            }
            return View(confederacion);
        }

        // POST: Confederacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Fundacion")] Confederacion confederacion)
        {
            if (id != confederacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(confederacion);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfederacionExists(confederacion.Id))
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
            return View(confederacion);
        }

        // GET: Confederacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confederacion = await _db.Confederacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confederacion == null)
            {
                return NotFound();
            }

            return View(confederacion);
        }

        // POST: Confederacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var confederacion = await _db.Confederacion.FindAsync(id);
            if (confederacion != null)
            {
                _db.Confederacion.Remove(confederacion);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfederacionExists(int id)
        {
            return _db.Confederacion.Any(e => e.Id == id);
        }
    }
}
