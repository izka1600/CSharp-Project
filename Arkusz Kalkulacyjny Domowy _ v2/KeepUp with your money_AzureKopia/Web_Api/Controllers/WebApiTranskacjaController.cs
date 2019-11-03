using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArkuszDataBase.Controllers;
using ArkuszDataBase.Class;
using ArkuszDataBase.Models;

namespace Web_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebApiTranskacjaController : ControllerBase
    {
		/// <summary>
		/// Metoda wyświetlająca z bazy wszystkie transakcje
		/// </summary>
		/// <returns></returns>
		[HttpGet("WylistujTransakcje")]
		public ActionResult<IEnumerable<Transakcje>> Get()
		{
			var data = new TransakcjaController().WylistujTranskacje();

			if (data == null)
			{
				return NotFound();
			}
			return data;
		}

		/// <summary>
		/// Stwórz nową Transakcję
		/// </summary>
		/// <param name="tr"></param>
		/// <returns></returns>
		[HttpPost("DodajNowaTransakcje")]
		public int Post(NowaTransakcja tr)
		{
			return new TransakcjaController().DodajTransakcje(tr);
		}

		/// <summary>
		/// Usuń transakcje o danym ID
		/// </summary>
		/// <param name="id"></param>
		[HttpDelete("UsunWskazanaTransakcje")]
		public void Delete(int id)
		{
			new TransakcjaController().UsunTransakcje(id);
		}

		/// <summary>
		/// Znajdź transakcje o danym ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("PokazWybranaTransakcje")]
		public ActionResult<Transakcje> Get(int id)
		{
			var data = new TransakcjaController().WyszukajTranskacje(id);

			if (data == null)
			{
				return NotFound();
			}
			return data;
		}
	}
}