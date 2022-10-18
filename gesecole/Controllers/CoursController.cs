using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gesecole.Models;
using NuGet.Protocol.Core.Types;

namespace gesecole.Controllers
{
    public class CoursController : Controller
    {
        private readonly gesecolecontext _context;

        public CoursController(gesecolecontext context)
        {
            _context = context;
        }

        // GET: Cours
        public async Task<IActionResult> Index()
        {
            return View(await _context.cours.ToListAsync());
        }

        public async Task<IActionResult> GetCoursByEtudiant(int? id)
        {
            return View("Index",await _context.cours
            .Where( c=> c.etudiants
            .Any(s => s.Id.Equals(id)))
            .ToListAsync());
        }
        // GET: Cours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cours == null)
            {
                return NotFound();
            }

            var cour = await _context.cours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cour == null)
            {
                return NotFound();
            }

            return View(cour);
        }

        // GET: Cours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom")] Cour cour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cour);
        }

        // GET: Cours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cours == null)
            {
                return NotFound();
            }

            var cour = await _context.cours.FindAsync(id);
            if (cour == null)
            {
                return NotFound();
            }
            return View(cour);
        }

        // POST: Cours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom")] Cour cour)
        {
            if (id != cour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourExists(cour.Id))
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
            return View(cour);
        }

        // GET: Cours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cours == null)
            {
                return NotFound();
            }

            var cour = await _context.cours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cour == null)
            {
                return NotFound();
            }

            return View(cour);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cours == null)
            {
                return Problem("Entity set 'gesecolecontext.cours'  is null.");
            }
            var cour = await _context.cours.FindAsync(id);
            if (cour != null)
            {
                _context.cours.Remove(cour);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourExists(int id)
        {
          return _context.cours.Any(e => e.Id == id);
        }
    }
}
