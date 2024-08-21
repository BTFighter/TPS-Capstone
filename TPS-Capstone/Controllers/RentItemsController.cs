using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TPS_Capstone.Data;
using WebApplication3.Models;

namespace TPS_Capstone.Controllers
{
    public class RentItemsController : Controller
    {
        private readonly TPS_CapstoneContext _context;

        public RentItemsController(TPS_CapstoneContext context)
        {
            _context = context;
        }

        // GET: RentItems
        public async Task<IActionResult> Index()
        {
            var tPS_CapstoneContext = _context.RentItem.Include(r => r.Product).Include(r => r.Rent);
            return View(await tPS_CapstoneContext.ToListAsync());
        }

        // GET: RentItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RentItem == null)
            {
                return NotFound();
            }

            var rentItem = await _context.RentItem
                .Include(r => r.Product)
                .Include(r => r.Rent)
                .FirstOrDefaultAsync(m => m.RentItemID == id);
            if (rentItem == null)
            {
                return NotFound();
            }

            return View(rentItem);
        }

        // GET: RentItems/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName");
            ViewData["RentId"] = new SelectList(_context.Rent, "RentId", "RentId");
            return View();
        }

        // POST: RentItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentItemID,RentId,ProductID,Quantity")] RentItem rentItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName", rentItem.ProductID);
            ViewData["RentId"] = new SelectList(_context.Rent, "RentId", "RentId", rentItem.RentId);
            return View(rentItem);
        }

        // GET: RentItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RentItem == null)
            {
                return NotFound();
            }

            var rentItem = await _context.RentItem.FindAsync(id);
            if (rentItem == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName", rentItem.ProductID);
            ViewData["RentId"] = new SelectList(_context.Rent, "RentId", "RentId", rentItem.RentId);
            return View(rentItem);
        }

        // POST: RentItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentItemID,RentId,ProductID,Quantity")] RentItem rentItem)
        {
            if (id != rentItem.RentItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentItemExists(rentItem.RentItemID))
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
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName", rentItem.ProductID);
            ViewData["RentId"] = new SelectList(_context.Rent, "RentId", "RentId", rentItem.RentId);
            return View(rentItem);
        }

        // GET: RentItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RentItem == null)
            {
                return NotFound();
            }

            var rentItem = await _context.RentItem
                .Include(r => r.Product)
                .Include(r => r.Rent)
                .FirstOrDefaultAsync(m => m.RentItemID == id);
            if (rentItem == null)
            {
                return NotFound();
            }

            return View(rentItem);
        }

        // POST: RentItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RentItem == null)
            {
                return Problem("Entity set 'TPS_CapstoneContext.RentItem'  is null.");
            }
            var rentItem = await _context.RentItem.FindAsync(id);
            if (rentItem != null)
            {
                _context.RentItem.Remove(rentItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentItemExists(int id)
        {
          return (_context.RentItem?.Any(e => e.RentItemID == id)).GetValueOrDefault();
        }
    }
}
