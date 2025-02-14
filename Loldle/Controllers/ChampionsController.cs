using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Loldle.Data;
using Loldle.Models;

namespace Loldle.Controllers
{
    public class ChampionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChampionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Champions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Champions.ToListAsync());
        }

        // GET: Champions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var champions = await _context.Champions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (champions == null)
            {
                return NotFound();
            }

            return View(champions);
        }

        // GET: Champions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Champions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Type,Race,Region")] Champions champions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(champions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(champions);
        }

        // GET: Champions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var champions = await _context.Champions.FindAsync(id);
            if (champions == null)
            {
                return NotFound();
            }
            return View(champions);
        }

        // POST: Champions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,Type,Race,Region")] Champions champions)
        {
            if (id != champions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(champions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChampionsExists(champions.Id))
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
            return View(champions);
        }

        // GET: Champions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var champions = await _context.Champions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (champions == null)
            {
                return NotFound();
            }

            return View(champions);
        }

        // POST: Champions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var champions = await _context.Champions.FindAsync(id);
            if (champions != null)
            {
                _context.Champions.Remove(champions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChampionsExists(int id)
        {
            return _context.Champions.Any(e => e.Id == id);
        }
    }
}
