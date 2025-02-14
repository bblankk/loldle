using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Loldle.Data;
using test.Models;

namespace Loldle.Controllers
{
    public class ClassicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Classics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Classic.ToListAsync());
        }

        // GET: Classics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classic = await _context.Classic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classic == null)
            {
                return NotFound();
            }

            return View(classic);
        }

        // GET: Classics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Type,Race,Region")] Classic classic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classic);
        }

        // GET: Classics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classic = await _context.Classic.FindAsync(id);
            if (classic == null)
            {
                return NotFound();
            }
            return View(classic);
        }

        // POST: Classics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,Type,Race,Region")] Classic classic)
        {
            if (id != classic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassicExists(classic.Id))
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
            return View(classic);
        }

        // GET: Classics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classic = await _context.Classic
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classic == null)
            {
                return NotFound();
            }

            return View(classic);
        }

        // POST: Classics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classic = await _context.Classic.FindAsync(id);
            if (classic != null)
            {
                _context.Classic.Remove(classic);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassicExists(int id)
        {
            return _context.Classic.Any(e => e.Id == id);
        }
    }
}
