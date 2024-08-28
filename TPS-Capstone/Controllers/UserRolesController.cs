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
              return _context.UserRole != null ? 
                          View(await _context.UserRole.ToListAsync()) :
                          Problem("Entity set 'TPS_CapstoneContext.UserRole'  is null.");
        }

        // GET: UserRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserRole == null)
            {
                return NotFound();
            }

            var userRole = await _context.UserRole
                .FirstOrDefaultAsync(m => m.UserRoleID == id);
            if (userRole == null)
            {
                return NotFound();
            }

            return View(userRole);
        }

        // GET: UserRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserRoleID,UserRoleName")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userRole);
        }

        // GET: UserRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserRole == null)
            {
                return NotFound();
            }

            var userRole = await _context.UserRole.FindAsync(id);
            if (userRole == null)
            {
                return NotFound();
            }
            return View(userRole);
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserRoleID,UserRoleName")] UserRole userRole)
        {
            if (id != userRole.UserRoleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRoleExists(userRole.UserRoleID))
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
            return View(userRole);
        }

        // GET: UserRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserRole == null)
            {
                return NotFound();
            }

            var userRole = await _context.UserRole
                .FirstOrDefaultAsync(m => m.UserRoleID == id);
            if (userRole == null)
            {
                return NotFound();
            }

            return View(userRole);
        }

        // POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserRole == null)
            {
                return Problem("Entity set 'TPS_CapstoneContext.UserRole'  is null.");
            }
            var userRole = await _context.UserRole.FindAsync(id);
            if (userRole != null)
            {
                _context.UserRole.Remove(userRole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserRoleExists(int id)
        {
          return (_context.UserRole?.Any(e => e.UserRoleID == id)).GetValueOrDefault();
        }
    }
}
