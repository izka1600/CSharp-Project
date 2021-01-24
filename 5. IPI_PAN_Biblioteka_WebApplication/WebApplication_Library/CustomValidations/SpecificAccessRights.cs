using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Library.CustomValidations
{
	public class SpecificAccessRights : ValidationAttribute
	{

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{

			if (value.ToString() == "r" || value.ToString() == "w")
			{
				return ValidationResult.Success;
			}


			return new ValidationResult("Wprowadź prawidłową wartość.");
		}
	}
}

