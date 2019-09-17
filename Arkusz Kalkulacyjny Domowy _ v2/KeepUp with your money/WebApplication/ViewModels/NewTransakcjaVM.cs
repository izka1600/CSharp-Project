using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
	public class NewTransakcjaVM: NewTransakcjaViewModel
	{


		[Display(Name = "Nazwa kategorii")]
		[Required(ErrorMessage = "Uzupełnienie kategorii  jest wymagane")]
		public string Kategoria { get; set; }

		[Display(Name = "Nazwa podkategorii")]
		[Required(ErrorMessage = "Uzupełnienie podkategorii jest wymagane")]
		public string Podkategoria { get; set; }


	}
}
