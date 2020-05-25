using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeProject.Models;
using CoffeProject.Data;
using Microsoft.EntityFrameworkCore;

namespace CoffeProject.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(string? searchString)
        {
            if (searchString is null)
            {
                var applicationDbContext = _context.CoffeItem.Include(c => c.CoffeType).Include(c => c.Manufacturer);
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                var applicationDbContext = _context.CoffeItem.Include(c => c.CoffeType)
                    .Include(c => c.Manufacturer)
                    .Where(s => s.Description.Contains(searchString) ||
                    s.CoffeType.Name.Contains(searchString) ||
                    s.Manufacturer.Name.Contains(searchString) ||
                    s.Name.Contains(searchString)).OrderBy(s => s.Name);
                return View(await applicationDbContext.ToListAsync());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public async Task<PartialViewResult> AddPartialToView(string id, string searchString)
        {
            if (searchString is null)
            {
                var applicationDbContext = _context.CoffeItem.Include(c => c.CoffeType).Include(c => c.Manufacturer);
                return PartialView(id, await applicationDbContext.ToListAsync());
            }
            else
            {
                var applicationDbContext = _context.CoffeItem.Include(c => c.CoffeType)
                    .Include(c => c.Manufacturer)
                    .Where(s => s.Description.Contains(searchString) ||
                    s.CoffeType.Name.Contains(searchString) ||
                    s.Manufacturer.Name.Contains(searchString) ||
                    s.Name.Contains(searchString)).OrderBy(s => s.Name);
                return PartialView(id, await applicationDbContext.ToListAsync());
            }
        }
    }
}
