using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Library.CustomValidations
{
	public class DateLessThanOrEqualToToday : ValidationAttribute
	{
		public override string FormatErrorMessage(string name)
		{
			return "Data publikacji nie powinna być datą z przyszłości.";
		}

		protected override ValidationResult IsValid(object objValue,
													   ValidationContext validationContext)
		{
			var dateValue = objValue as DateTime? ?? new DateTime();

			//alter this as needed. I am doing the date comparison if the value is not null

			if (dateValue.Date > DateTime.Now.Date)
			{
				return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
			}
			return ValidationResult.Success;
		}
	}
}
