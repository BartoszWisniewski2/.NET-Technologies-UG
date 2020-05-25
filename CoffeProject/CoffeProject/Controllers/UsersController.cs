using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoffeProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UsersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyName(string Name, string lastName)
        {
            if ((Name == lastName))
            {
                return Json($"A user named {Name} {lastName} already exists.");
            }

            return Json($"A user named {Name} {lastName} already exists.");
        }
    }
}