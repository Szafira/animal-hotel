using animal_hotel.Data;
using animal_hotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace animal_hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private petHistoryContext Context { get; }

        public HomeController(petHistoryContext _context)
        {
            this.Context = _context;
        }

        public IActionResult History()
        {
           
            List<zwierzak> pets = (from zwierzak in this.Context.zwierzak.Take(10) where zwierzak.id_klienta ==2
                                   select zwierzak).ToList();

            return View(pets);
        }
    

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Reservation()
        {
            return View();
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
