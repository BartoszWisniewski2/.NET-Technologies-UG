using CoffeProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeProject.Utility
{
    public class MinimumDateAttribute : ValidationAttribute
    {
        private int _days;

        public MinimumDateAttribute(int Days)
        {
            _days = Days;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var coffeItem = (CoffeItem)validationContext.ObjectInstance;

            var date = DateTime.Now;
            date = date.AddDays(_days);

            if (coffeItem.MinimumBestBeforeDate < date)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return $"Data przydatności musi wynosić co najmniej {_days} dni";
        }
    }
}
