using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
	public class UpdatePlanViewModel
	{
		public int PlanId { get; set; }

		[Display(Name = "Miesiąc")]
		public DateTime? Miesiąc { get; set; }


		[Display(Name = "Założona kwota wydatków na dany miesiąc")]
		public decimal? ZalozonaKwota { get; set; }

		public bool Active { get; set; }
		public int Warning { get; set; }
	}
}
