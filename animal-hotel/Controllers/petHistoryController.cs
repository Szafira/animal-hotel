using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using animal_hotel.Data;
using animal_hotel.Models;
using Microsoft.Data.SqlClient;

namespace animal_hotel.Controllers
{
    public class petHistoryController : Controller
    {
        private readonly petHistoryContext _context;

        public static getid_klienta()
        {
            return id_klienta;
        }
        public petHistoryController(petHistoryContext context)
        {
            _context = context;
        }
       // SqlConnection con = new SqlConnection("name=DefaultConnection:connectionString");
       // SqlCommand command = new SqlCommand("Select imie, gatunek, rasa, wiek, dodatkowe_informacje from zwierzak where id_klienta=1");
       // SqlDataReader reader = command.ExecuteReader();


        // GET: petHistory
        public async Task<IActionResult> Index()
        {
            return View(await _context.zwierzak.ToListAsync());
        }

        // GET: petHistory/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zwierzak = await _context.zwierzak
                .FirstOrDefaultAsync(m => m.id_zwierz == id);
            if (zwierzak == null)
            {
                return NotFound();
            }

            return View(zwierzak);
        }

        // GET: petHistory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: petHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_zwierz,id_klienta,imie,gatunek,rasa,wielkosc,wiek,dodatkowe_informacje")] zwierzak zwierzak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zwierzak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zwierzak);
        }

        // GET: petHistory/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zwierzak = await _context.zwierzak.FindAsync(id);
            if (zwierzak == null)
            {
                return NotFound();
            }
            return View(zwierzak);
        }

        // POST: petHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("id_zwierz,id_klienta,imie,gatunek,rasa,wielkosc,wiek,dodatkowe_informacje")] zwierzak zwierzak)
        {
            if (id != zwierzak.id_zwierz)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zwierzak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!zwierzakExists(zwierzak.id_zwierz))
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
            return View(zwierzak);
        }

        // GET: petHistory/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zwierzak = await _context.zwierzak
                .FirstOrDefaultAsync(m => m.id_zwierz == id);
            if (zwierzak == null)
            {
                return NotFound();
            }

            return View(zwierzak);
        }

        // POST: petHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var zwierzak = await _context.zwierzak.FindAsync(id);
            _context.zwierzak.Remove(zwierzak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool zwierzakExists(decimal id)
        {
            return _context.zwierzak.Any(e => e.id_zwierz == id);
        }
    }
}
