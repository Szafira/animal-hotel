using animal_hotel.Models;
using animal_hotel.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace animal_hotel.Controllers
{
    public class AboutUsController : Controller
    {

        [Route("AboutUs")]
        public IActionResult AboutUs()
        {
            return View();
        }

    }
}

