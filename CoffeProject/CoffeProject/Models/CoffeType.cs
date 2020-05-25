using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeProject.Models
{
    public class CoffeType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Typ Kawy")]
        public string Name { get; set; }
    }
}
