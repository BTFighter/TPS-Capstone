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
    public class UserRolesController : Controller
    {
        private readonly TPS_CapstoneContext _context;

        public UserRolesController(TPS_CapstoneContext context)
        {
            _context = context;
        }

        // GET: UserRoles
        public async Task<IActionResult> Index()
        {
            var tPS_CapstoneContext = _context.UserRoles.Include(u => u.User);
            return View(await tPS_CapstoneContext.ToListAsync());
        }

        // GET: UserRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserRoles == null)
            {
                return NotFound();
            }

            var userRoles = await _context.UserRoles
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserRoleId == id);
            if (userRoles == null)
            {
                return NotFound();
            }

            return View(userRoles);
        }

        // GET: UserRoles/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Set<Users>(), "UserId", "EmailAddress");
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserRoleId,UserId,UserRole")] UserRoles userRoles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userRoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<Users>(), "UserId", "EmailAddress", userRoles.UserId);
            return View(userRoles);
        }

        // GET: UserRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserRoles == null)
            {
                return NotFound();
            }

            var userRoles = await _context.UserRoles.FindAsync(id);
            if (userRoles == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<Users>(), "UserId", "EmailAddress", userRoles.UserId);
            return View(userRoles);
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserRoleId,UserId,UserRole")] UserRoles userRoles)
        {
            if (id != userRoles.UserRoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userRoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRolesExists(userRoles.UserRoleId))
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
            ViewData["UserId"] = new SelectList(_context.Set<Users>(), "UserId", "EmailAddress", userRoles.UserId);
            return View(userRoles);
        }

        // GET: UserRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserRoles == null)
            {
                return NotFound();
            }

            var userRoles = await _context.UserRoles
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserRoleId == id);
            if (userRoles == null)
            {
                return NotFound();
            }

            return View(userRoles);
        }

        // POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserRoles == null)
            {
                return Problem("Entity set 'TPS_CapstoneContext.UserRoles'  is null.");
            }
            var userRoles = await _context.UserRoles.FindAsync(id);
            if (userRoles != null)
            {
                _context.UserRoles.Remove(userRoles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserRolesExists(int id)
        {
          return (_context.UserRoles?.Any(e => e.UserRoleId == id)).GetValueOrDefault();
        }
    }
}
