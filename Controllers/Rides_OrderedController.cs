using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cab_Project.Data;
using Cab_Project.Models;

namespace Cab_Project.Controllers
{
    public class Rides_OrderedController : Controller
    {
        private readonly Cab_ProjectContext _context;

        public Rides_OrderedController(Cab_ProjectContext context)
        {
            _context = context;
        }

        // GET: Rides_Ordered
        public async Task<IActionResult> Index()
        {
              return View(await _context.Rides_Ordered.ToListAsync());
        }

        // GET: Rides_Ordered/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rides_Ordered == null)
            {
                return NotFound();
            }

            var rides_Ordered = await _context.Rides_Ordered
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rides_Ordered == null)
            {
                return NotFound();
            }

            return View(rides_Ordered);
        }

        // GET: Rides_Ordered/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rides_Ordered/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Driver_Name,email,pickup_location,drop_location,price")] Rides_Ordered rides_Ordered)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rides_Ordered);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rides_Ordered);
        }

        // GET: Rides_Ordered/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rides_Ordered == null)
            {
                return NotFound();
            }

            var rides_Ordered = await _context.Rides_Ordered.FindAsync(id);
            if (rides_Ordered == null)
            {
                return NotFound();
            }
            return View(rides_Ordered);
        }

        // POST: Rides_Ordered/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Driver_Name,email,pickup_location,drop_location,price")] Rides_Ordered rides_Ordered)
        {
            if (id != rides_Ordered.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rides_Ordered);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Rides_OrderedExists(rides_Ordered.Id))
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
            return View(rides_Ordered);
        }

        // GET: Rides_Ordered/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rides_Ordered == null)
            {
                return NotFound();
            }

            var rides_Ordered = await _context.Rides_Ordered
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rides_Ordered == null)
            {
                return NotFound();
            }

            return View(rides_Ordered);
        }

        // POST: Rides_Ordered/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rides_Ordered == null)
            {
                return Problem("Entity set 'Cab_ProjectContext.Rides_Ordered'  is null.");
            }
            var rides_Ordered = await _context.Rides_Ordered.FindAsync(id);
            if (rides_Ordered != null)
            {
                _context.Rides_Ordered.Remove(rides_Ordered);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Rides_OrderedExists(int id)
        {
          return _context.Rides_Ordered.Any(e => e.Id == id);
        }
    }
}
