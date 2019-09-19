using ArkuszDataBase.Controllers;
using ArkuszDataBase.Class;
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
	public class WebApiPlanController : ControllerBase
	{
		/// <summary>
		/// Metoda wyświetlająca z bazy wszystkie plany
		/// </summary>
		/// <returns></returns>
		[HttpGet("WylistujPlany")]
		public ActionResult<IEnumerable<Plan>> Get()
		{
			var data = new PlanController().WylistujPlany();

			if (data == null)
			{
				return NotFound();
			}
			return data;
		}

		/// <summary>
		/// Stwórz nowy plan
		/// </summary>
		/// <param name="plan"></param>
		/// <returns></returns>
		[HttpPost("DodajNowyPlan")]
		public int Post(NowyPlan plan)
		{
			return new PlanController().DodajPlan(plan);

		}

		/// <summary>
		/// Usuń plan o danym ID
		/// </summary>
		/// <param name="id"></param>
		[HttpDelete("UsunWskazanyPlan")]
		public void Delete(int id)
		{
			new PlanController().UsunPlan(id);
		}

		/// <summary>
		/// Zaktualizuj plan o danym ID
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="data"></param>
		/// <param name="IdTr"></param>
		/// <param name="zalKwota"></param>
		[HttpPost("ZaktualizujWskazanyPlan")]
		public void Update(UpdatePlan plan)
		{
			new PlanController().UzytkownikZaktualizaujPlan(plan);
		}
	}


}
