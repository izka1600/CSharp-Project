using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Library.CustomValidations;

namespace WebApplication_Library.Models
{
	public class NewBookViewModel
	{
		[BindNever]

		[Display(Name = "Tytuł książki")]
		[Required(ErrorMessage = "Tytuł książki jest wymagany")]
		[StringLength(100, ErrorMessage = "Tytuł książki jest za długi")]
		public string BookName { get; set; }

		[Display(Name = "Imię Autora")]
		[Required(ErrorMessage = "Imię autora jest wymagane")]
		[StringLength(30, ErrorMessage = "Imię autora jest za długie")]
		public string FirstName { get; set; }

		[Display(Name = "Nazwisko Autora")]
		[Required(ErrorMessage = "Nazwisko autora jest wymagane")]
		[StringLength(30, ErrorMessage = "Nazwisko autora jest za długie")]
		public string LastName { get; set; }

		[Display(Name = "Data publikacji")]
		[Required(ErrorMessage = "Data publikacji jest wymagana")]
		[DataType(DataType.Date)]
		[DateLessThanOrEqualToToday]
		public DateTime PublicationDate { get; set; }

		[Display(Name = "Nazwa okładki")]
		[Required(ErrorMessage = "Tytuł okładki jest wymagany")]
		[StringLength(100, ErrorMessage = "Tytuł okładki  jest za długi")]
		public string CoverName { get; set; }

		[Display(Name = "Nazwa nośnika danych")]
		[Required(ErrorMessage = "Nazwa nośnika danych jest wymagana")]
		[DataCarriersSpecificStrings_]
		public string DataCarrierName { get; set; }
	}
}
