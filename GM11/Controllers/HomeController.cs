using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GM011.Models;
using GM11.Models;
using GM11.Models.GMViewModels;
namespace GM11.Controllers
{
    public class HomeController : Controller
    {

        private readonly GMContext _context;
        private List<Car> viewModel = new List<Car>();

        public HomeController(GMContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new CarIndexData();
            viewModel.Cars = await _context.Car
                .Include(i => i.CarType)
                .AsNoTracking()
                .OrderBy(i => i.CarType.UnitPrice)
                .ToListAsync();

           

            foreach(Car item in _context.Car.ToList())
            {
                
            }

            //List.Add()

            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
