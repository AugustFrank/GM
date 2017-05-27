using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GM011.Models;
using GM11.Models;
using GM11.Models.GMViewModels;
using Microsoft.AspNetCore.Authorization;

namespace GM11.Controllers
{
    //[Authorize(Roles ="admin")]//[Authorize(Roles ="admin")]
    public class CarsController : Controller
    {
        private readonly GMContext _context;

        public CarsController(GMContext context)
        {
            _context = context;    
        }

        // GET: Cars
        public async Task<IActionResult> Index(int? id, int? typeID)
        {
            var viewModel = new CarIndexData();
            viewModel.Cars = await _context.Car
                .Include(i => i.CarType)
                .Include(i => i.Services)
                .AsNoTracking()
                .OrderBy(i => i.RegNo)
                .ToListAsync();

            if (id != null)
            {
                ViewData["CarID"] = id.Value;
                Car Cars = viewModel.Cars.Where(i => i.CarID == id.Value).Single();
                viewModel.CarTypes = viewModel.Cars.Select(i => i.CarType);
            }
            //if (typeID!=null)
            //{
            //    ViewData["CourseID"] = typeID.Value;


            //}
            return View(viewModel);
            //var gMContext = _context.Car.Include(c => c.CarType);
            //return View(await gMContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.CarType)
                .SingleOrDefaultAsync(m => m.CarID == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["CarTypeID"] = new SelectList(_context.CarType, "CarTypeID", "CarTypeID");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarID,RegNo,CarTypeID,ServiceID,Year,CurrentMilage,NextServiceMilage,Doors,Seats,Fuel,FuelPerKM,Transmission")] Car car)
        {



            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CarTypeID"] = new SelectList(_context.CarType, "CarTypeID", "CarTypeID", car.CarTypeID);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.SingleOrDefaultAsync(m => m.CarID == id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["CarTypeID"] = new SelectList(_context.CarType, "CarTypeID", "CarTypeID", car.CarTypeID);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarID,RegNo,CarTypeID,ServiceID,Year,CurrentMilage,NextServiceMilage,Doors,Seats,Fuel,FuelPerKM,Transmission")] Car car)
        {
            if (id != car.CarID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CarTypeID"] = new SelectList(_context.CarType, "CarTypeID", "CarTypeID", car.CarTypeID);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.CarType)
                .SingleOrDefaultAsync(m => m.CarID == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.SingleOrDefaultAsync(m => m.CarID == id);
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.CarID == id);
        }
    }
}
