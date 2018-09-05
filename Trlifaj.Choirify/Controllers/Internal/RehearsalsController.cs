using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trlifaj.Choirify.Data;
using Trlifaj.Choirify.Models;
using Trlifaj.Choirify.Services;

namespace Trlifaj.Choirify.Controllers.Internal
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Chairman + "," + Roles.ViceChairman)]
    public class RehearsalsController : Controller
    {
        private readonly ChoirDbContext _context;

        public RehearsalsController(ChoirDbContext context)
        {
            _context = context;
        }

        // GET: Rehearsals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rehearsals.ToListAsync());
        }

        // GET: Rehearsals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rehearsal = await _context.Rehearsals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rehearsal == null)
            {
                return NotFound();
            }

            return View(rehearsal);
        }

        // GET: Rehearsals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rehearsals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Description,IsDeleted")] Rehearsal rehearsal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rehearsal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rehearsal);
        }

        // GET: Rehearsals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rehearsal = await _context.Rehearsals.FindAsync(id);
            if (rehearsal == null)
            {
                return NotFound();
            }
            return View(rehearsal);
        }

        // POST: Rehearsals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Description,IsDeleted")] Rehearsal rehearsal)
        {
            if (id != rehearsal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rehearsal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RehearsalExists(rehearsal.Id))
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
            return View(rehearsal);
        }

        // GET: Rehearsals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rehearsal = await _context.Rehearsals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rehearsal == null)
            {
                return NotFound();
            }

            return View(rehearsal);
        }

        // POST: Rehearsals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rehearsal = await _context.Rehearsals.FindAsync(id);
            _context.Rehearsals.Remove(rehearsal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RehearsalExists(int id)
        {
            return _context.Rehearsals.Any(e => e.Id == id);
        }
    }
}
