using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GM011.Models;
using GM11.Models;
using GM11.Models.GMViewModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Net;

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
                .Include(i=>i.CarType)
                                                                                         
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task SendEmailAsync(string email, string subject, string message)
        {
           
            try
            {
                var em = new MimeMessage();
                em.From.Add(new MailboxAddress(""));
                em.To.Add(new MailboxAddress(""));
                em.Subject = subject;
                em.Body = new TextPart("Plain") { Text = message };

                using (var client = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "",
                        Password = ""
                    };
                    
                    client.LocalDomain = "";
                    await client.ConnectAsync("", 25, MailKit.Security.SecureSocketOptions.Auto).ConfigureAwait(false);
                    await client.SendAsync(em).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            


        }
    }
}
