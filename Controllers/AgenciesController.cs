#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TourFirm.Data;
using TourFirm.Models;

namespace TourFirm.Controllers
{
    public class AgenciesController : Controller
    {
        private readonly TourFirmContext _context;

        public AgenciesController(TourFirmContext context)
        {
            _context = context;
        }

        // GET: Agencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agencies.ToListAsync());
        }

        // GET: Agencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencies = await _context.Agencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agencies == null)
            {
                return NotFound();
            }

            return View(agencies);
        }

        // GET: Agencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Phonenumber,Rating")] Agencies agencies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agencies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agencies);
        }

        // GET: Agencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencies = await _context.Agencies.FindAsync(id);
            if (agencies == null)
            {
                return NotFound();
            }
            return View(agencies);
        }

        // POST: Agencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Phonenumber,Rating")] Agencies agencies)
        {
            if (id != agencies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agencies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgenciesExists(agencies.Id))
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
            return View(agencies);
        }

        // GET: Agencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agencies = await _context.Agencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agencies == null)
            {
                return NotFound();
            }

            return View(agencies);
        }

        // POST: Agencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agencies = await _context.Agencies.FindAsync(id);
            _context.Agencies.Remove(agencies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgenciesExists(int id)
        {
            return _context.Agencies.Any(e => e.Id == id);
        }
    }
}
