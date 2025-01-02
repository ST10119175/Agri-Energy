using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agri_Energy_app.Data;
using Agri_Energy_app.Models;
using Microsoft.AspNetCore.Authorization;

namespace Agri_Energy_app.Controllers
{
    [Authorize(Roles = "Admin")]
   
    public class FarmersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Farmers
        public async Task<IActionResult> Index()
        {
              return _context.Farmer != null ? 
                          View(await _context.Farmer.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Farmer'  is null.");
        }

        // GET: Farmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Farmer == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmer
                .FirstOrDefaultAsync(m => m.FarmerId == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // GET: Farmers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FarmerId,Name,Password")] Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmer);
        }

        // GET: Farmers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Farmer == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmer.FindAsync(id);
            if (farmer == null)
            {
                return NotFound();
            }
            return View(farmer);
        }

        // POST: Farmers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FarmerId,Name,Password")] Farmer farmer)
        {
            if (id != farmer.FarmerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmerExists(farmer.FarmerId))
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
            return View(farmer);
        }

        // GET: Farmers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Farmer == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmer
                .FirstOrDefaultAsync(m => m.FarmerId == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // POST: Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Farmer == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Farmer'  is null.");
            }
            var farmer = await _context.Farmer.FindAsync(id);
            if (farmer != null)
            {
                _context.Farmer.Remove(farmer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmerExists(int id)
        {
          return (_context.Farmer?.Any(e => e.FarmerId == id)).GetValueOrDefault();
        }
    }
}
