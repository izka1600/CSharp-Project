using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArkuszDataBase.Controllers;
using ArkuszDataBase.Class;
using ArkuszDataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Web_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebApiUzytkownikController : ControllerBase
    {
		/// <summary>
		/// Metoda wyświetlająca z bazy wszystkich użytkowników
		/// </summary>
		/// <returns></returns>
		[HttpGet("WylistujUzytkownikow")]
		public ActionResult<IEnumerable<Uzytkownik>> Get()
		{
			var data = new UzytkownikController().WylistujUzytkownikow();

			if (data == null)
			{
				return NotFound();
			}
			return data;
		}

		/// <summary>
		/// Znajdź użytkownika o danym ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("PokazWybranegoUzytkownika")]
		public ActionResult<Uzytkownik> Get(int id)
		{
			var data = new UzytkownikController().ZnajdzUzytkownika(id);

			if (data == null)
			{
				return NotFound();
			}
			return data;
		}

		/// <summary>
		/// Stwórz nowego Użytkownika
		/// </summary>
		/// <param name="uz"></param>
		/// <returns></returns>
		[HttpPost("DodajNowegoUzytkownika")]
		[EnableCors]
		public int Post(NowyUzytkownik uz )
		{
			return new UzytkownikController().StworzNowegoUzytkownika(uz);
		}

		/// <summary>
		/// Usuń użytkownika o danym ID
		/// </summary>
		/// <param name="id"></param>
		[HttpDelete("UsunWskazanegoUzytkownika")]
		public void Delete(int id)
		{
			new UzytkownikController().UsunUzytkownika(id);
		}

	}
}