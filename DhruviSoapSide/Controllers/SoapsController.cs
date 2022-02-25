using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DhruviSoapSide.Data;
using DhruviSoapSide.Models;

namespace DhruviSoapSide.Controllers
{
    public class SoapsController : Controller
    {
        private readonly DhruviSoapSideContext _context;

        public SoapsController(DhruviSoapSideContext context)
        {
            _context = context;
        }

        // GET: Soaps
        public async Task<IActionResult> Index(string SoapBrand, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Soaps
                                            orderby m.BrandName
                                            select m.BrandName;

            var Soaps = from m in _context.Soaps
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                Soaps = Soaps.Where(s => s.ProductName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(SoapBrand))
            {
                Soaps = Soaps.Where(x => x.BrandName == SoapBrand);
            }

            var SoapBrandVM = new SoapBrandNameViewModel
            {
                BrandName = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Soaps = await Soaps.ToListAsync()
            };

            return View(SoapBrandVM);
        }

            // GET: Soaps/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soaps = await _context.Soaps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soaps == null)
            {
                return NotFound();
            }

            return View(soaps);
        }

        // GET: Soaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Soaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,Aroma,Shape,Quality,BrandName,Weight,Price")] Soaps soaps)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soaps);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soaps);
        }

        // GET: Soaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soaps = await _context.Soaps.FindAsync(id);
            if (soaps == null)
            {
                return NotFound();
            }
            return View(soaps);
        }

        // POST: Soaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Aroma,Shape,Quality,BrandName,Weight,Price")] Soaps soaps)
        {
            if (id != soaps.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soaps);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoapsExists(soaps.Id))
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
            return View(soaps);
        }

        // GET: Soaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soaps = await _context.Soaps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soaps == null)
            {
                return NotFound();
            }

            return View(soaps);
        }

        // POST: Soaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soaps = await _context.Soaps.FindAsync(id);
            _context.Soaps.Remove(soaps);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoapsExists(int id)
        {
            return _context.Soaps.Any(e => e.Id == id);
        }
    }
}
