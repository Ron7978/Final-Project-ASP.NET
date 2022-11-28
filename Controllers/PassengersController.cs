using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cab_Project.Data;
using Cab_Project.Models;
using Microsoft.AspNet.Identity;
using System.Xml.Linq;

namespace Cab_Project.Controllers
{
    public class PassengersController : Controller
    {
        private readonly Cab_ProjectContext _context;

        public PassengersController(Cab_ProjectContext context)
        {
            _context = context;
        }

        // GET: Passengers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Passengers.ToListAsync());
        }

        // GET: Passengers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passengers = await _context.Passengers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passengers == null)
            {
                return NotFound();
            }

            return View(passengers);
        }

        // GET: Passengers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int Id,string name,string pickup,string drop)
        {
            if (ModelState.IsValid)
            {
                Passengers passenger = new Passengers();
                passenger.name = name;
                passenger.email = User.Identity.GetUserName();
                passenger.pickup = pickup;
                passenger.drop = drop;
                Distance d = new Distance();
                var c = new List<Distance>();
                foreach (Distance k in await _context.Distances.ToListAsync())
                {
                    if (k.location1 == pickup)
                    {
                        if (k.location2 == drop)
                        {
                            passenger.price = k.price;



                            break;
                        }
                    }
                    else if (k.location1 == drop)
                    {
                        if (k.location2 == pickup)
                        {
                            passenger.price = k.price;
                            break;
                        }
                    }
                }
                _context.Add(passenger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Accept(int? id)
        {
            var v = await _context.Passengers.FindAsync(id);
            return View(v);
        }

        [HttpPost]
        public async Task<IActionResult> Accept(int id)
        {
            var v = await _context.Passengers.FindAsync(id);
            Driver_Details driver_Details = new Driver_Details();
            string email = User.Identity.GetUserName();
            driver_Details = await _context.Driver_Details.FirstOrDefaultAsync(m => m.email == email);

            

            driver_Details.Driver_location = v.drop;
            _context.Driver_Details.Update(driver_Details);



            Rides_Taken taken = new Rides_Taken();
            taken.Customer_name = v.name;
            taken.email = driver_Details.email;
            taken.pickup_location = v.pickup;
            taken.drop_location = v.drop;
            taken.price = v.price;
            taken.travel_id = v.Id;



            Rides_Ordered ordered = new Rides_Ordered();
            ordered.Driver_Name = driver_Details.Driver_Name;
            ordered.email = v.email;
            ordered.pickup_location = v.pickup;
            ordered.drop_location = v.drop;
            ordered.price = v.price;



            _context.Rides_Taken.Add(taken);
            _context.Rides_Ordered.Add(ordered);
            _context.Passengers.Remove(v);
            await _context.SaveChangesAsync();




            return RedirectToAction(nameof(Index));

        }

        // GET: Passengers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passengers = await _context.Passengers.FindAsync(id);
            if (passengers == null)
            {
                return NotFound();
            }
            return View(passengers);
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,email,pickup,drop,price")] Passengers passengers)
        {
            if (id != passengers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passengers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassengersExists(passengers.Id))
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
            return View(passengers);
        }

        // GET: Passengers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Passengers == null)
            {
                return NotFound();
            }

            var passengers = await _context.Passengers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passengers == null)
            {
                return NotFound();
            }

            return View(passengers);
        }

        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passengers == null)
            {
                return Problem("Entity set 'Cab_ProjectContext.Passengers'  is null.");
            }
            var passengers = await _context.Passengers.FindAsync(id);
            if (passengers != null)
            {
                _context.Passengers.Remove(passengers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassengersExists(int id)
        {
          return _context.Passengers.Any(e => e.Id == id);
        }
    }
}
