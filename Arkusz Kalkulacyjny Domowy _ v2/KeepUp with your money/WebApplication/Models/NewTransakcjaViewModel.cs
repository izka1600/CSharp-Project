using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
	public class NewTransakcjaViewModel
	{
		[Display(Name = "Data transakcji")]
		public DateTime? Data { get; set; }


		[Display(Name = "Identyfikator użytkownika")]
		[Required(ErrorMessage = "Identyfikator użytkownika jest wymagany")]
		public int IdUzytkownika { get; set; }


		[Display(Name = "Identyfikator kategorii")]
		[Required(ErrorMessage = "Identyfikator kategorii  jest wymagany")]
		public int IdKategorii { get; set; }

		[Display(Name = "Identyfikator podkategorii")]
		[Required(ErrorMessage = "Identyfikator podkategorii jest wymagany")]
		public int IdPodkategorii { get; set; }


		[Display(Name = "Kwota")]
		public double? Kwota { get; set; }
	}
}
