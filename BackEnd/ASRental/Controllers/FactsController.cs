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

namespace ASRental.Controllers
{
    public class FactsController : Controller
    {
        private readonly IFactService _factService;

        public FactsController(IFactService factService)
        {
            _factService = factService;
        }


        public IActionResult Facts()
        {
            return View();
        }

        //GET: Facts
        public async Task<IActionResult> Index()
        {
            return View(await _factService.GetAllFacts());
        }

        // GET: Facts/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fact = await _factService.GetFactById(id);
            if (fact == null)
            {
                return NotFound();
            }

            return View(fact);
        }

        // GET: Facts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FactId,Title,Author,Content,Picture,Date")] Fact fact)
        {
            if (ModelState.IsValid)
            {
                await _factService.CreateFact(fact);
                return RedirectToAction(nameof(Create));
            }
            return View(fact);
        }

        // GET: Facts/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fact = await _factService.GetFactById(id);
            if (fact == null)
            {
                return NotFound();
            }
            return View(fact);
        }

        // POST: Facts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FactId,Title,Author,Content,Picture,Date")] Fact fact)
        {
            if (id != fact.FactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _factService.UpdateFact(id, fact);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_factService.FactExists(fact.FactId))
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
            return View(fact);
        }

        // GET: Facts/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fact = await _factService.GetFactById(id);
            if (fact == null)
            {
                return NotFound();
            }

            return View(fact);
        }

        // POST: Facts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _factService.DeleteFact(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
