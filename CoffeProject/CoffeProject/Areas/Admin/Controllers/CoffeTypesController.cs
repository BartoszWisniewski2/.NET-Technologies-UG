using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeProject.Data;
using CoffeProject.Models;
using Microsoft.AspNetCore.Authorization;
using CoffeProject.Utility;

namespace CoffeProject.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = SD.AdminUser + "," + SD.ModeratorUser)]
    public class CoffeTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoffeTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CoffeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CoffeType.ToListAsync());
        }

        // GET: Admin/CoffeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffeType = await _context.CoffeType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffeType == null)
            {
                return NotFound();
            }

            return View(coffeType);
        }

        // GET: Admin/CoffeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CoffeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CoffeType coffeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coffeType);
        }

        // GET: Admin/CoffeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffeType = await _context.CoffeType.FindAsync(id);
            if (coffeType == null)
            {
                return NotFound();
            }
            return View(coffeType);
        }

        // POST: Admin/CoffeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CoffeType coffeType)
        {
            if (id != coffeType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeTypeExists(coffeType.Id))
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
            return View(coffeType);
        }

        // GET: Admin/CoffeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffeType = await _context.CoffeType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffeType == null)
            {
                return NotFound();
            }

            return View(coffeType);
        }

        // POST: Admin/CoffeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coffeType = await _context.CoffeType.FindAsync(id);
            _context.CoffeType.Remove(coffeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoffeTypeExists(int id)
        {
            return _context.CoffeType.Any(e => e.Id == id);
        }
    }
}
