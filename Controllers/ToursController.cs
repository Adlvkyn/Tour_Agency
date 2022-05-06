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
    public class ToursController : Controller
    {
        private readonly TourFirmContext _context;

        public ToursController(TourFirmContext context)
        {
            _context = context;
        }

        // GET: Tours
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tours.ToListAsync());
        }

        // GET: Tours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tours = await _context.Tours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tours == null)
            {
                return NotFound();
            }

            return View(tours);
        }

        // GET: Tours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Price,TourDate")] Tours tours)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tours);
        }

        // GET: Tours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tours = await _context.Tours.FindAsync(id);
            if (tours == null)
            {
                return NotFound();
            }
            return View(tours);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Price,TourDate")] Tours tours)
        {
            if (id != tours.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToursExists(tours.Id))
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
            return View(tours);
        }

        // GET: Tours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tours = await _context.Tours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tours == null)
            {
                return NotFound();
            }

            return View(tours);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tours = await _context.Tours.FindAsync(id);
            _context.Tours.Remove(tours);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToursExists(int id)
        {
            return _context.Tours.Any(e => e.Id == id);
        }
    }
}
