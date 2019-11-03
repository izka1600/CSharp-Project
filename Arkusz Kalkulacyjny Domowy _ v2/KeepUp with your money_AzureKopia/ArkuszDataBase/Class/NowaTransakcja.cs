using System;
using System.Collections.Generic;
using System.Text;

namespace ArkuszDataBase.Class
{
	public class NowaTransakcja
	{
		public DateTime? Data { get; set; }
		public int IdUzytkownika { get; set; }
		public int IdKategorii { get; set; }
		public int IdPodkategorii { get; set; }
		public double? Kwota { get; set; }
		public int? PlanId { get; set; }
	}
}
