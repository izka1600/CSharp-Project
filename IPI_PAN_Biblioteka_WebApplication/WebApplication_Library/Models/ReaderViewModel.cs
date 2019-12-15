using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Library.CustomValidations;

namespace WebApplication_Library.Models
{
	public class ReaderViewModel
	{
		[Display(Name = "Id Czytelnika")]
		[Required]
		public int ReaderId { get; set; }

		[Display(Name = "Imię Czytelnika")]
		[Required]
		[StringLength(30, ErrorMessage = "Imię Czytelnika jest za długie")]
		public string FirstName { get; set; }

		[Display(Name = "Nazwisko Czytelnika")]
		[Required]
		[StringLength(30, ErrorMessage = "Nazwisko Czytelnika jest za długie")]
		public string LastName { get; set; }

		[Display(Name = "Email Czytelnika")]
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Display(Name = "Prawa dostępu")]
		[SpecificAccessRights]
		[Required]
		public string AccessRights { get; set; }

	}
}
