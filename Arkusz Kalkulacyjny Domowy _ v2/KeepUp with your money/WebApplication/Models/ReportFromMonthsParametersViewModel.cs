﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
	public class ReportFromMonthsParametersViewModel
	{
		[Key]
		public int UserId { get; set; }
		public string Plan_Id { get; set; }
	}
}
