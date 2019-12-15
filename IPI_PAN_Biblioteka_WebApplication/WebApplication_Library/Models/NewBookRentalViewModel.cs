using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Library.Models
{
	public class NewBookRentalViewModel
	{
		[Display(Name = "Id Czytelnika")]
		public int? ReaderId { get; set; }

		[Display(Name = "Id książki")]
		public int? BookId { get; set; }

		[Display(Name = "Komentarz do książki")]
		[Required(ErrorMessage = "Komentarz jest wymagany")]
		[StringLength(100, ErrorMessage = "Komentarz za długi")]
		public string Comment { get; set; }
	}
}
