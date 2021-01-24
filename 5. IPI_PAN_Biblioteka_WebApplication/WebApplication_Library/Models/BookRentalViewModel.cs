using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Library.CustomValidations;

namespace WebApplication_Library.Models
{
	public class BookRentaViewModel
	{
		[Display(Name = "Id wypożyczenia")]
		public int RentalId { get; set; }

		[Display(Name = "Id czytelnika")]
		public int? ReaderId { get; set; }

		[Display(Name = "Id książki")]
		public int? BookId { get; set; }

		[Display(Name = "Komentarz do książki")]
		[Required(ErrorMessage = "Komentarz jest wymagany")]
		[StringLength(100, ErrorMessage = "Komentarz za długi")]
		public string Comment { get; set; }

		[Display(Name = "Data wypożyczenia")]
		[DataType(DataType.Date)]
		[DateLessThanOrEqualToToday]
		public DateTime? RentalDate { get; set; }

		[Display(Name = "Data zwrotu")]
		[DataType(DataType.Date)]
		[DateLessThanOrEqualToToday]
		public DateTime? ReturnDate { get; set; }

	}
}
