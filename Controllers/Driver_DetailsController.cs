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
    public class Driver_DetailsController : Controller
    {
        private readonly Cab_ProjectContext _context;

        public Driver_DetailsController(Cab_ProjectContext context)
        {
            _context = context;
        }

        // GET: Driver_Details
        public async Task<IActionResult> Index()
        {
              return View(await _context.Driver_Details.ToListAsync());
        }

        // GET: Driver_Details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Driver_Details == null)
            {
                return NotFound();
            }

            var driver_Details = await _context.Driver_Details
                .FirstOrDefaultAsync(m => m.DriverId == id);
            if (driver_Details == null)
            {
                return NotFound();
            }

            return View(driver_Details);
        }

        // GET: Driver_Details/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Driver_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DriverId,Driver_Name,email,Driver_location,travel_id,price")] Driver_Details driver_Details)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driver_Details);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(driver_Details);
        }

        // GET: Driver_Details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Driver_Details == null)
            {
                return NotFound();
            }

            var driver_Details = await _context.Driver_Details.FindAsync(id);
            if (driver_Details == null)
            {
                return NotFound();
            }
            return View(driver_Details);
        }

        // POST: Driver_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string driver_location)
        {
            //if (id != driver_Details.DriverId)
            //{
            //    return NotFound();
            //}
            if (ModelState.IsValid)
            {
                var v = await _context.Driver_Details.FindAsync(id);
                try
                {
                    v.Driver_location = driver_location;
                    _context.Update(v);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Driver_DetailsExists(v.DriverId))
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
            return View();
        }

        // GET: Driver_Details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Driver_Details == null)
            {
                return NotFound();
            }

            var driver_Details = await _context.Driver_Details
                .FirstOrDefaultAsync(m => m.DriverId == id);
            if (driver_Details == null)
            {
                return NotFound();
            }

            return View(driver_Details);
        }

        // POST: Driver_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Driver_Details == null)
            {
                return Problem("Entity set 'Cab_ProjectContext.Driver_Details'  is null.");
            }
            var driver_Details = await _context.Driver_Details.FindAsync(id);
            if (driver_Details != null)
            {
                _context.Driver_Details.Remove(driver_Details);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Driver_DetailsExists(int id)
        {
          return _context.Driver_Details.Any(e => e.DriverId == id);
        }
    }
}
