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
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace ASRental.Controllers
{
   [Authorize(Roles = "Administrator, User")]
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
         private readonly IWebHostEnvironment _environment;

        public CarsController(ICarService carService,IWebHostEnvironment environment)
        {
            _carService = carService;
             _environment = environment;
        }

        [Authorize]
        // GET: Cars
        public async Task<IActionResult> Gallery()
        {
            return View(await _carService.GetAllCars());
        }

        // GET: Cars/Details/5
        //public async Task<IActionResult> Details(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var car = await _carService.GetCarById(id);
        //    if (car == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(car);
        //}

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details()
        {
            
            return View();
        }


        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarId,CarNumber,CarName,CarBody,Price,CarPicture,FabricationYear,TransmissionType,ClimateControl")] Car car)
        {
            if (ModelState.IsValid)
            {
                //for update profile img start
            var newFileName = string.Empty;
            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string pathDb = string.Empty;
                var files = HttpContext.Request.Form.Files;
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        var fileExtension = Path.GetExtension(fileName);
                        newFileName = myUniqueFileName + fileExtension;
                        fileName = Path.Combine(_environment.WebRootPath, "images") + $@"\{newFileName}";
                        pathDb = "/images/" + newFileName;
                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            await file.CopyToAsync(fs);
                            fs.Flush();
                            car.CarPicture = pathDb;
                        }
                    }
                }
            }

                await _carService.CreateCar(car);
                return RedirectToAction(nameof(Gallery));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CarId,CarNumber,CarName,CarBody,Price,CarPicture,FabricationYear,TransmissionType,ClimateControl")] Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _carService.UpdateCar(id, car);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_carService.CarExists(car.CarId))
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
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _carService.DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
