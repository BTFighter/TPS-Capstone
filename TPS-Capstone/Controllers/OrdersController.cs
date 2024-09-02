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
    public class OrdersController : Controller
    {
        private readonly TPS_CapstoneContext _context;

        public OrdersController(TPS_CapstoneContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var tPS_CapstoneContext = _context.Rent.Include(o => o.OrderType);
            return View(await tPS_CapstoneContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rent == null)
            {
                return NotFound();
            }

            var order = await _context.Rent
                .Include(o => o.OrderType)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["OrderTypeID"] = new SelectList(_context.OrderType, "OrderTypeID", "OrderTypeName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,CustomerName,Email,PhoneNumber,DateStart,ReturnDate,Description,OrderTypeID")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderTypeID"] = new SelectList(_context.OrderType, "OrderTypeID", "OrderTypeName", order.OrderTypeID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rent == null)
            {
                return NotFound();
            }

            var order = await _context.Rent.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["OrderTypeID"] = new SelectList(_context.OrderType, "OrderTypeID", "OrderTypeName", order.OrderTypeID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,CustomerName,Email,PhoneNumber,DateStart,ReturnDate,Description,OrderTypeID")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
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
            ViewData["OrderTypeID"] = new SelectList(_context.OrderType, "OrderTypeID", "OrderTypeName", order.OrderTypeID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rent == null)
            {
                return NotFound();
            }

            var order = await _context.Rent
                .Include(o => o.OrderType)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rent == null)
            {
                return Problem("Entity set 'TPS_CapstoneContext.Rent'  is null.");
            }
            var order = await _context.Rent.FindAsync(id);
            if (order != null)
            {
                _context.Rent.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return (_context.Rent?.Any(e => e.OrderID == id)).GetValueOrDefault();
        }
    }
}
