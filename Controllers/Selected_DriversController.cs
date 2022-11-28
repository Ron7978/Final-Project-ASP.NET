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
    public class Selected_DriversController : Controller
    {
        private readonly Cab_ProjectContext _context;

        public Selected_DriversController(Cab_ProjectContext context)
        {
            _context = context;
        }

        // GET: Selected_Drivers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Selected_Drivers.ToListAsync());
        }

        // GET: Selected_Drivers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Selected_Drivers == null)
            {
                return NotFound();
            }

            var selected_Drivers = await _context.Selected_Drivers
                .FirstOrDefaultAsync(m => m.email == id);
            if (selected_Drivers == null)
            {
                return NotFound();
            }

            return View(selected_Drivers);
        }

        // GET: Selected_Drivers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Selected_Drivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("email,password")] Selected_Drivers selected_Drivers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(selected_Drivers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(selected_Drivers);
        }

        // GET: Selected_Drivers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Selected_Drivers == null)
            {
                return NotFound();
            }

            var selected_Drivers = await _context.Selected_Drivers.FindAsync(id);
            if (selected_Drivers == null)
            {
                return NotFound();
            }
            return View(selected_Drivers);
        }

        // POST: Selected_Drivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("email,password")] Selected_Drivers selected_Drivers)
        {
            if (id != selected_Drivers.email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(selected_Drivers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Selected_DriversExists(selected_Drivers.email))
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
            return View(selected_Drivers);
        }

        // GET: Selected_Drivers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Selected_Drivers == null)
            {
                return NotFound();
            }

            var selected_Drivers = await _context.Selected_Drivers
                .FirstOrDefaultAsync(m => m.email == id);
            if (selected_Drivers == null)
            {
                return NotFound();
            }

            return View(selected_Drivers);
        }

        // POST: Selected_Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Selected_Drivers == null)
            {
                return Problem("Entity set 'Cab_ProjectContext.Selected_Drivers'  is null.");
            }
            var selected_Drivers = await _context.Selected_Drivers.FindAsync(id);
            if (selected_Drivers != null)
            {
                _context.Selected_Drivers.Remove(selected_Drivers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Selected_DriversExists(string id)
        {
          return _context.Selected_Drivers.Any(e => e.email == id);
        }
    }
}
