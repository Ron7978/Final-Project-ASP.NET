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
    public class Rides_TakenController : Controller
    {
        private readonly Cab_ProjectContext _context;

        public Rides_TakenController(Cab_ProjectContext context)
        {
            _context = context;
        }

        // GET: Rides_Taken
        public async Task<IActionResult> Index()
        {
              return View(await _context.Rides_Taken.ToListAsync());
        }

        // GET: Rides_Taken/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rides_Taken == null)
            {
                return NotFound();
            }

            var rides_Taken = await _context.Rides_Taken
                .FirstOrDefaultAsync(m => m.id == id);
            if (rides_Taken == null)
            {
                return NotFound();
            }

            return View(rides_Taken);
        }

        // GET: Rides_Taken/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rides_Taken/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Customer_name,email,pickup_location,drop_location,price,travel_id")] Rides_Taken rides_Taken)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rides_Taken);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rides_Taken);
        }

        // GET: Rides_Taken/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rides_Taken == null)
            {
                return NotFound();
            }

            var rides_Taken = await _context.Rides_Taken.FindAsync(id);
            if (rides_Taken == null)
            {
                return NotFound();
            }
            return View(rides_Taken);
        }

        // POST: Rides_Taken/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Customer_name,email,pickup_location,drop_location,price,travel_id")] Rides_Taken rides_Taken)
        {
            if (id != rides_Taken.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rides_Taken);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Rides_TakenExists(rides_Taken.id))
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
            return View(rides_Taken);
        }

        // GET: Rides_Taken/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rides_Taken == null)
            {
                return NotFound();
            }

            var rides_Taken = await _context.Rides_Taken
                .FirstOrDefaultAsync(m => m.id == id);
            if (rides_Taken == null)
            {
                return NotFound();
            }

            return View(rides_Taken);
        }

        // POST: Rides_Taken/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rides_Taken == null)
            {
                return Problem("Entity set 'Cab_ProjectContext.Rides_Taken'  is null.");
            }
            var rides_Taken = await _context.Rides_Taken.FindAsync(id);
            if (rides_Taken != null)
            {
                _context.Rides_Taken.Remove(rides_Taken);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Rides_TakenExists(int id)
        {
          return _context.Rides_Taken.Any(e => e.id == id);
        }
    }
}
