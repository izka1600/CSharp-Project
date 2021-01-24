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
	public class WebApiRaportFromSomeMonthsController : ControllerBase
	{
		/// <summary>
		/// Pokaż raport transakcji z danych miesięcy
		/// </summary>
		[HttpGet("PokazRaportZDanychMiesiecy")]
		public ActionResult<IEnumerable<RaportFromMonths>> GetRaport(ReportFromMonthsParametres id)
		{
			var data = new RaportFromSomeMonthsController().RaportFromSomeMonths(id);

			if (data == null)
			{
				return NotFound();
			}
			return data;
		}

	}
}
