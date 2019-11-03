using System;
using System.Collections.Generic;
using System.Text;

namespace ArkuszDataBase.Class
{
	public class UpdatePlan
	{
		public int PlanId { get; set; }
		public DateTime? Miesiąc { get; set; }
		public decimal? ZalozonaKwota { get; set; }
		public bool Active { get; set; }
		public int Warning { get; set; }
	}
}
