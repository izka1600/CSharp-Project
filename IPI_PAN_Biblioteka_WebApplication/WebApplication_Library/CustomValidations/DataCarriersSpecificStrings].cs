using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Library.CustomValidations
{
	public class DataCarriersSpecificStrings_ : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{

			if (value.ToString() == "Ksiazka" || value.ToString() == "DVD" || value.ToString() == "CD")
			{
				return ValidationResult.Success;
			}


			return new ValidationResult("Wprowadź prawidłową wartość.");
		}
	}
}
