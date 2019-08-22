using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
	public class UserViewModel
	{
		[Display(Name = "Id Użytkownika")]
		[Required]
		public int ReaderId { get; set; }

		[Display(Name = "Imię Użytkownika")]
		[Required]
		[StringLength(30, ErrorMessage = "Imię Użytkownika jest za długie")]
		public string FirstName { get; set; }

		[Display(Name = "Nazwisko Użytkownika")]
		[Required]
		[StringLength(30, ErrorMessage = "Nazwisko Użytkownika jest za długie")]
		public string LastName { get; set; }

		[Display(Name = "Email Użytkownika")]
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Display(Name = "Prawa dostępu")]
		[Required]
		public string AccessRights { get; set; }
	}
}
