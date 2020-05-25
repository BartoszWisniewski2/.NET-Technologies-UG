using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CoffeProject.Areas.Identity.Pages.Account.Manage;
namespace CoffeProject.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Name { get; set; }
        public string StreetAddress { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Pesel { get; set; }
    }
}
