using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
	public class NewKategoriaViewModel
	{
		[Display(Name = "Nazwa kategorii")]
		[StringLength(100, ErrorMessage = "Nazwa kategorii jest za długa")]
		public string Kategoria { get; set; }

		public int IdUzytkownika { get; set; }

		public string SciezkaDoZdjecia { get; set; }

	}
}
