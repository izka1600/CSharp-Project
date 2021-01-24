using ArkuszDataBase.Controllers;
using ArkuszDataBase.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class WebApiAddTransactionToPlanController : ControllerBase
	{

		[HttpPut("ZaktualizujFaktycznyPlan")]
		public void Update(UpdateFaktycznyPlan fp)
		{
			new AddTransactionToPlanController().AddTransactionToPlan(fp);
		}
	}
}
