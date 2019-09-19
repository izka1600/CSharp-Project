using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
	public class PlanViewModel
	{
		[BindNever]

		public int PlanId { get; set; }

		[Display(Name = "Miesiąc")]
		public DateTime? Miesiąc { get; set; }


		[Display(Name = "Założona kwota wydatków na dany miesiąc")]
		public decimal? ZalozonaKwota { get; set; }

		[Display(Name = "Faktyczna kwota wydatków na dany miesiąc")]
		public decimal? FaktycznaKwota { get; set; }
		public int IdUzytkownika { get; set; }

		[Display(Name = "Id transakcji")]
		public int IdTransakcji { get; set; }
	}
}
