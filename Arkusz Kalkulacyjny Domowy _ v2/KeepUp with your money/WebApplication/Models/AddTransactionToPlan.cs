using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
	public class AddTransactionToPlan
	{

		public decimal FaktycznaKwota;
		public int PlanId { get; set; }

		public decimal Amount;

	}
}
