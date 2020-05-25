using System;
using System.Collections.Generic;
using System.Text;
using CoffeProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoffeProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<CoffeType> CoffeType { get; set; }
        public DbSet<CoffeItem> CoffeItem { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1, Name = "Lavazza" },
                new Manufacturer { Id = 2, Name = "Dallmayr" },
                new Manufacturer { Id = 3, Name = "Segafredo" },
                new Manufacturer { Id = 4, Name = "Gimoka" },
                new Manufacturer { Id = 5, Name = "Tchibo" },
                new Manufacturer { Id = 6, Name = "Jacobs" },
                new Manufacturer { Id = 7, Name = "Nescafe" }
            );
            modelBuilder.Entity<CoffeType>().HasData(
                new CoffeType { Id = 1, Name = "Ziarnista" },
                new CoffeType { Id = 2, Name = "Mielona" },
                new CoffeType { Id = 3, Name = "Cafissimo" },
                new CoffeType { Id = 4, Name = "Tassimo" },
                new CoffeType { Id = 5, Name = "Senseo" },
                new CoffeType { Id = 6, Name = "Dolce Gusto" }
            );
            modelBuilder.Entity<CoffeItem>().HasData(
                new CoffeItem { Id = 1, Name = "Kawa ziarnista idealna dla każdego :)", Description = "kupuj i się nie zastanawiaj", Quantity = 10, Price = 20.2, CoffeTypeId = 1, ManufacturerId = 1, MinimumBestBeforeDate = new DateTime(2020, 12, 12) },
                new CoffeItem { Id = 2, Name = "Kawa mielona :)", Description = "kupuj bo tania, cena za 1kg", Price = 10.7, Quantity = 10, CoffeTypeId = 2, ManufacturerId = 1, MinimumBestBeforeDate = new DateTime(2020, 12, 12) },
                new CoffeItem { Id = 3, Name = "Kapsułki Cafissimo", Description = "kupuj", Price = 30.6, Quantity = 10, CoffeTypeId = 3, ManufacturerId = 6, MinimumBestBeforeDate = new DateTime(2020, 12, 12) },
                new CoffeItem { Id = 4, Name = "Kapsułki Tassimo", Description = "kupuj", Price = 23.14, Quantity = 10, CoffeTypeId = 4, ManufacturerId = 5, MinimumBestBeforeDate = new DateTime(2020, 12, 12) },
                new CoffeItem { Id = 5, Name = "Saszetki Senseo", Description = "kupuj", Price = 70.2, Quantity = 10, CoffeTypeId = 5, ManufacturerId = 2, MinimumBestBeforeDate = new DateTime(2020, 12, 12) },
                new CoffeItem { Id = 6, Name = "Kapsułki Dolce Gusto", Description = "kupuj", Price = 66.6, Quantity = 10, CoffeTypeId = 6, ManufacturerId = 7, MinimumBestBeforeDate = new DateTime(2020, 12, 12) },
                new CoffeItem { Id = 7, Name = "Kawa super droga", Description = "Nie wiem czemu taka droga, raczej nie warta swojej ceny", Price = 999.9, Quantity = 10, CoffeTypeId = 1, ManufacturerId = 1, MinimumBestBeforeDate = new DateTime(1990, 12, 12) }
           );

        }
    }
}
