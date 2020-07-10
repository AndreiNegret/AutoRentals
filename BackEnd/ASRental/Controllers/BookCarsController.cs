using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASRental.Data;
using ASRental.Models;
using ASRental.Services.Interfaces;
using ASRental.Dto;

namespace ASRental.Controllers
{
    public class BookCarsController : Controller
    {
        private readonly IBookCarService _bookCarService;

        public BookCarsController(IBookCarService bookCarService)
        {
            _bookCarService = bookCarService;
        }

        // GET: bookCars
        public async Task<IActionResult> Index()
        {
            return View(await _bookCarService.GetAllBookCars());
        }

        // GET: bookCars/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCar = await _bookCarService.GetBookCarById(id);
            if (bookCar == null)
            {
                return NotFound();
            }

            return View(bookCar);
        }

        // GET: bookCars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: bookCars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookCarDto bookCar)
        {
            try
            {
                var newBookCar = new BookCar(bookCar);
                await _bookCarService.CreateBookCar(newBookCar);
                return Ok(bookCar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: bookCars/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCar = await _bookCarService.GetBookCarById(id);
            if (bookCar == null)
            {
                return NotFound();
            }
            return View(bookCar);
        }

        // POST: bookCars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    await _bookCarService.UpdateBookCar(id, bookCar);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_bookCarService.BookCarExists(bookCar.BookCarId))
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

        // GET: bookCars/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCar = await _bookCarService.GetBookCarById(id);
            if (bookCar == null)
            {
                return NotFound();
            }

            return View(bookCar);
        }

        // POST: bookCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bookCarService.DeleteBookCar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
