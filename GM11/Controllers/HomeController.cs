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
        public IActionResult SendEmailAsync(string subject, string message, string email)
        {
            string smptServer = "asmtp.unoeuro.com";
            int smptPortNumber = 587;

            try
            {
                var em = new MimeMessage();
                em.From.Add(new MailboxAddress("mailbot", "mailbot@greenmile.is"));
                em.To.Add(new MailboxAddress("info", "info@greenmile.is"));
                em.Subject = subject;
                em.Body = new TextPart("html")
                { Text = "New Message From" + "<br>" + message + "</br>" + " <br> space </br>" + email };

               



                using (var client = new SmtpClient())
                {
                    client.Connect(smptServer, smptPortNumber);                   
                    client.Authenticate("mailbot@greenmile.is", "kimschips");
                    client.Send(em);
                    client.Disconnect(true);
                }
                // old solution
                #region MyRegion
                //using (var client = new SmtpClient())
                //{
                //    client.Connect(smptServer, smptPortNumber, false);
                //    var credential = new NetworkCredential
                //    {

                //        UserName = "mailbot@greenmile.is",
                //        Password = "WickedAugustin"
                //    };


                //    await client.ConnectAsync("", 25, MailKit.Security.SecureSocketOptions.Auto).ConfigureAwait(false);
                //    await client.SendAsync(em).ConfigureAwait(false);
                //    await client.DisconnectAsync(true).ConfigureAwait(false);
                //}
                #endregion // old
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View("Contact");


        }

        [HttpPost]
        public IActionResult FindCars(DateTime DateIn, DateTime DateOut)
        {
            var carList = _context.Car
                .Include(i => i.CarType)
                .ToList();

            viewModel = carList;

            foreach(var item in viewModel)
            {
                foreach(var order in _context.Order.ToList())
                {
                    if(order.DateIN >= DateIn && order.DateIN <= DateOut || order.DateOut >= DateIn && order.DateOut <= DateOut)
                    {
                        viewModel.Remove(order.Car);
                    }
                }
            }

            return View(viewModel);
        }
    }
}
