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
    public class ReservationsController : Controller
    {
        private readonly petHistoryContext _context;

        public ReservationsController(petHistoryContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            return View(await _context.rezerwacje.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacje = await _context.rezerwacje
                .FirstOrDefaultAsync(m => m.id_rezerwacji == id);
            if (rezerwacje == null)
            {
                return NotFound();
            }

            return View(rezerwacje);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_rezerwacji,id_data,id_zwierz")] rezerwacje rezerwacje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezerwacje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rezerwacje);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacje = await _context.rezerwacje.FindAsync(id);
            if (rezerwacje == null)
            {
                return NotFound();
            }
            return View(rezerwacje);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("id_rezerwacji,id_data,id_zwierz")] rezerwacje rezerwacje)
        {
            if (id != rezerwacje.id_rezerwacji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezerwacje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!rezerwacjeExists(rezerwacje.id_rezerwacji))
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
            return View(rezerwacje);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacje = await _context.rezerwacje
                .FirstOrDefaultAsync(m => m.id_rezerwacji == id);
            if (rezerwacje == null)
            {
                return NotFound();
            }

            return View(rezerwacje);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var rezerwacje = await _context.rezerwacje.FindAsync(id);
            _context.rezerwacje.Remove(rezerwacje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool rezerwacjeExists(decimal id)
        {
            return _context.rezerwacje.Any(e => e.id_rezerwacji == id);
        }
    }
}
