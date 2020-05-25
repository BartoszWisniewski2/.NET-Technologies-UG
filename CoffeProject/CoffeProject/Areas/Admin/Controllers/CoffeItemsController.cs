using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeProject.Data;
using CoffeProject.Models;
using CoffeProject.Utility;
using Microsoft.AspNetCore.Authorization;

namespace CoffeProject.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = SD.AdminUser +","+ SD.ModeratorUser)]
    public class CoffeItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoffeItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CoffeItems
        public async Task<IActionResult> Index()
        {
                var applicationDbContext = _context.CoffeItem.Include(c => c.CoffeType).Include(c => c.Manufacturer);
                return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/CoffeItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffeItem = await _context.CoffeItem
                .Include(c => c.CoffeType)
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffeItem == null)
            {
                return NotFound();
            }

            return View(coffeItem);
        }

        // GET: Admin/CoffeItems/Create
        public IActionResult Create()
        {
            ViewData["CoffeTypeId"] = new SelectList(_context.CoffeType, "Id", "Name");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Name");
            return View(new CoffeItem{
                MinimumBestBeforeDate = DateTime.Now }
            );
        }

        // POST: Admin/CoffeItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantity,Name,Description,Price,ManufacturerId,CoffeTypeId,MinimumBestBeforeDate")] CoffeItem coffeItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffeItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CoffeTypeId"] = new SelectList(_context.CoffeType, "Id", "Name", coffeItem.CoffeTypeId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Name", coffeItem.ManufacturerId);
            return View(coffeItem);
        }




        // GET: Admin/CoffeItems1Controller9/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffeItem = await _context.CoffeItem.FindAsync(id);
            if (coffeItem == null)
            {
                return NotFound();
            }
            ViewData["CoffeTypeId"] = new SelectList(_context.CoffeType, "Id", "Name", coffeItem.CoffeTypeId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Name", coffeItem.ManufacturerId);
            return View(coffeItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,Name,Description,Price,ManufacturerId,CoffeTypeId,MinimumBestBeforeDate")] CoffeItem coffeItem)
        {
            if (id != coffeItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffeItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeItemExists(coffeItem.Id))
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
            ViewData["CoffeTypeId"] = new SelectList(_context.CoffeType, "Id", "Name", coffeItem.CoffeTypeId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "Id", "Name", coffeItem.ManufacturerId);
            return View(coffeItem);
        }

        // GET: Admin/CoffeItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffeItem = await _context.CoffeItem
                .Include(c => c.CoffeType)
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffeItem == null)
            {
                return NotFound();
            }

            return View(coffeItem);
        }

        // POST: Admin/CoffeItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coffeItem = await _context.CoffeItem.FindAsync(id);
            _context.CoffeItem.Remove(coffeItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoffeItemExists(int id)
        {
            return _context.CoffeItem.Any(e => e.Id == id);
        }
    }
}
