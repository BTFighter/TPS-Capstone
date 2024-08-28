using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TPS_Capstone.Data;
using TPS_Capstone.Models;

namespace TPS_Capstone.Controllers
{
    public class RentsController : Controller
    {
        private readonly TPS_CapstoneContext _context;

        public RentsController(TPS_CapstoneContext context)
        {
            _context = context;
        }

        // GET: Rents
        public async Task<IActionResult> Index()
        {
            var tPS_CapstoneContext = _context.Rent.Include(r => r.OrderType);
            return View(await tPS_CapstoneContext.ToListAsync());
        }

        // GET: Rents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rent == null)
            {
                return NotFound();
            }

            var rent = await _context.Rent
                .Include(r => r.OrderType)
                .FirstOrDefaultAsync(m => m.RentID == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // GET: Rents/Create
        public IActionResult Create()
        {
            ViewData["OrderTypeID"] = new SelectList(_context.OrderType, "OrderTypeID", "OrderTypeName");
            return View();
        }

        // POST: Rents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentID,CustomerName,Email,PhoneNumber,DateStart,ReturnDate,Description,Quantity,OrderTypeID")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderTypeID"] = new SelectList(_context.OrderType, "OrderTypeID", "OrderTypeName", rent.OrderTypeID);
            return View(rent);
        }

        // GET: Rents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rent == null)
            {
                return NotFound();
            }

            var rent = await _context.Rent.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }
            ViewData["OrderTypeID"] = new SelectList(_context.OrderType, "OrderTypeID", "OrderTypeName", rent.OrderTypeID);
            return View(rent);
        }

        // POST: Rents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentID,CustomerName,Email,PhoneNumber,DateStart,ReturnDate,Description,Quantity,OrderTypeID")] Rent rent)
        {
            if (id != rent.RentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentExists(rent.RentID))
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
            ViewData["OrderTypeID"] = new SelectList(_context.OrderType, "OrderTypeID", "OrderTypeName", rent.OrderTypeID);
            return View(rent);
        }

        // GET: Rents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rent == null)
            {
                return NotFound();
            }

            var rent = await _context.Rent
                .Include(r => r.OrderType)
                .FirstOrDefaultAsync(m => m.RentID == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rent == null)
            {
                return Problem("Entity set 'TPS_CapstoneContext.Rent'  is null.");
            }
            var rent = await _context.Rent.FindAsync(id);
            if (rent != null)
            {
                _context.Rent.Remove(rent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentExists(int id)
        {
          return (_context.Rent?.Any(e => e.RentID == id)).GetValueOrDefault();
        }
    }
}
