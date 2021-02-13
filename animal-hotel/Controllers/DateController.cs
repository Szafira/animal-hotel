using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using animal_hotel.Data;
using animal_hotel.Models;

namespace animal_hotel.Controllers
{
    public class DateController : Controller
    {
        private readonly petHistoryContext _context;

        public DateController(petHistoryContext context)
        {
            _context = context;
        }

        // GET: Date
        public async Task<IActionResult> Index()
        {
            return View(await _context.terminy.ToListAsync());
        }

        // GET: Date/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminy = await _context.terminy
                .FirstOrDefaultAsync(m => m.id_data == id);
            if (terminy == null)
            {
                return NotFound();
            }

            return View(terminy);
        }

        // GET: Date/Create
        public IActionResult Create()
        {
            return View();
        }

      
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminy = await _context.terminy.FindAsync(id);
            if (terminy == null)
            {
                return NotFound();
            }
            return View(terminy);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("id_data,termin")] terminy terminy)
        {
            if (id != terminy.id_data)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terminy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!terminyExists(terminy.id_data))
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
            return View(terminy);
        }

 
        private bool terminyExists(decimal id)
        {
            return _context.terminy.Any(e => e.id_data == id);
        }
    }
}
