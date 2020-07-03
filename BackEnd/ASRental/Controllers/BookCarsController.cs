using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASRental.Data;
using ASRental.Models;

namespace ASRental.Controllers
{
    public class BookCarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookCarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookCars
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookCars.ToListAsync());
        }

        // GET: BookCars/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCar = await _context.BookCars
                .FirstOrDefaultAsync(m => m.BookCarId == id);
            if (bookCar == null)
            {
                return NotFound();
            }

            return View(bookCar);
        }

        // GET: BookCars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookCarId,CarId,Location,PickDate,ReturnDate,CarName")] BookCar bookCar)
        {
            if (ModelState.IsValid)
            {
                bookCar.BookCarId = Guid.NewGuid();
                _context.Add(bookCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookCar);
        }

        // GET: BookCars/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCar = await _context.BookCars.FindAsync(id);
            if (bookCar == null)
            {
                return NotFound();
            }
            return View(bookCar);
        }

        // POST: BookCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BookCarId,CarId,Location,PickDate,ReturnDate,CarName")] BookCar bookCar)
        {
            if (id != bookCar.BookCarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCarExists(bookCar.BookCarId))
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
            return View(bookCar);
        }

        // GET: BookCars/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCar = await _context.BookCars
                .FirstOrDefaultAsync(m => m.BookCarId == id);
            if (bookCar == null)
            {
                return NotFound();
            }

            return View(bookCar);
        }

        // POST: BookCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bookCar = await _context.BookCars.FindAsync(id);
            _context.BookCars.Remove(bookCar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCarExists(Guid id)
        {
            return _context.BookCars.Any(e => e.BookCarId == id);
        }
    }
}
