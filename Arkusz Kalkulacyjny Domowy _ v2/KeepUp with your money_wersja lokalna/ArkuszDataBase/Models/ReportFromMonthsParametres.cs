using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArkuszDataBase.Models
{
	public partial class ReportFromMonthsParametres
	{
		[Key]
		public int UserId { get; set; }
		public string Plan_Id { get; set; }
	}
}
