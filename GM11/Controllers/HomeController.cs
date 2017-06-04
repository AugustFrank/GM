using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GM011.Models;
using GM11.Models;

namespace GM11.Controllers
{
    public class HomeController : Controller
    {

        private readonly GMContext _context;
        private List<Car> List = new List<Car>();

        public HomeController(GMContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {

           

            foreach(Car item in _context.Car.ToList())
            {
                List.Add(item);
            }

            //List.Add()

            return View(List);
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
