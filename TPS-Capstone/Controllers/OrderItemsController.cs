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
    public class OrderItemsController : Controller
    {
        private readonly TPS_CapstoneContext _context;

        public OrderItemsController(TPS_CapstoneContext context)
        {
            _context = context;
        }

        // GET: OrderItems
        public async Task<IActionResult> Index()
        {
            var tPS_CapstoneContext = _context.QueryItem.Include(o => o.Product).Include(o => o.Rent);
            return View(await tPS_CapstoneContext.ToListAsync());
        }

        // GET: OrderItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.QueryItem == null)
            {
                return NotFound();
            }

            var orderItem = await _context.QueryItem
                .Include(o => o.Product)
                .Include(o => o.Rent)
                .FirstOrDefaultAsync(m => m.OrderItemID == id);
            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        // GET: OrderItems/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID");
            ViewData["RentID"] = new SelectList(_context.Rent, "OrderID", "OrderID");
            return View();
        }

        // POST: OrderItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderItemID,RentID,ProductID,Quantity")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", orderItem.ProductID);
            ViewData["RentID"] = new SelectList(_context.Rent, "OrderID", "OrderID", orderItem.RentID);
            return View(orderItem);
        }

        // GET: OrderItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.QueryItem == null)
            {
                return NotFound();
            }

            var orderItem = await _context.QueryItem.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", orderItem.ProductID);
            ViewData["RentID"] = new SelectList(_context.Rent, "OrderID", "OrderID", orderItem.RentID);
            return View(orderItem);
        }

        // POST: OrderItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderItemID,RentID,ProductID,Quantity")] OrderItem orderItem)
        {
            if (id != orderItem.OrderItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderItemExists(orderItem.OrderItemID))
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
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", orderItem.ProductID);
            ViewData["RentID"] = new SelectList(_context.Rent, "OrderID", "OrderID", orderItem.RentID);
            return View(orderItem);
        }

        // GET: OrderItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.QueryItem == null)
            {
                return NotFound();
            }

            var orderItem = await _context.QueryItem
                .Include(o => o.Product)
                .Include(o => o.Rent)
                .FirstOrDefaultAsync(m => m.OrderItemID == id);
            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.QueryItem == null)
            {
                return Problem("Entity set 'TPS_CapstoneContext.QueryItem'  is null.");
            }
            var orderItem = await _context.QueryItem.FindAsync(id);
            if (orderItem != null)
            {
                _context.QueryItem.Remove(orderItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderItemExists(int id)
        {
          return (_context.QueryItem?.Any(e => e.OrderItemID == id)).GetValueOrDefault();
        }
    }
}
