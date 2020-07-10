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
using Microsoft.AspNetCore.Authorization;

namespace ASRental.Controllers
{
     [Authorize(Roles = "Administrator, User")]
    public class DriversController : Controller
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

         [Authorize]
        public IActionResult Drivers()
        {
            return View();
        }

        //GET: Drivers
        public async Task<IActionResult> Index()
        {
            return View(await _driverService.GetAllDrivers());
        }

        // GET: Drivers/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _driverService.GetDriverById(id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // GET: Drivers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DriverId,DriverName,DriverType,ProfilePicture,PhoneNumber")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                await _driverService.CreateDriver(driver);
                return RedirectToAction(nameof(Create));
            }
            return View(driver);
        }

        // GET: Drivers/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _driverService.GetDriverById(id);
            if (driver == null)
            {
                return NotFound();
            }
            return View(driver);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DriverId, DriverName, DriverType, ProfilePicture, PhoneNumber")] Driver driver)
        {
            if (id != driver.DriverId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _driverService.UpdateDriver(id, driver);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_driverService.DriverExists(driver.DriverId))
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
            return View(driver);
        }

        // GET: Drivers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _driverService.GetDriverById(id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _driverService.DeleteDriver(id);
            return RedirectToAction(nameof(Index));
        }
    }
}