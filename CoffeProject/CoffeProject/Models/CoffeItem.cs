using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CoffeProject.Utility;

namespace CoffeProject.Models
{
    public class CoffeItem 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = " Zła ilość")]
        [Display(Name = "Ilość")]
        public int Quantity { get; set; }

        [Display(Name="Nazwa Kawy")]
        [Required]
        [StringLength(50, ErrorMessage = "Za długa nazwa")]
        public string Name { get; set; }

        [Display(Name="Opis")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Cena")]
        [Range(1, int.MaxValue, ErrorMessage = " Cena musi być większa niż 1")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Producent")]
        public int ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        [Display(Name = "Producent")]
        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        [Display(Name = "Typ Kawy")]
        public int CoffeTypeId { get; set; }

        [ForeignKey("CoffeTypeId")]
        [Display(Name = "Typ Kawy")]
        public virtual CoffeType CoffeType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Spożyć przed")]
        [MinimumDate(30)]
        public DateTime MinimumBestBeforeDate { get; set; }
        
    }
}
