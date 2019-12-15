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
	public class WebApiKategoriaController : ControllerBase
	{
		/// <summary>
		/// Metoda wyświetlająca z bazy wszystkie kategorie
		/// </summary>
		/// <returns></returns>
		[HttpGet("WylistujKategorie")]
		public ActionResult<IEnumerable<Kategorie>> Get()
		{
			var data = new KategoriaController().WylistujKategorie();

			if (data == null)
			{
				return NotFound();
			}
			return data;
		}


		/// <summary>
		/// Metoda wyświetlająca z bazy wszystkie podkategorie
		/// </summary>
		/// <returns></returns>
		[HttpGet("WylistujPodkategorie")]
		public ActionResult<IEnumerable<Podkategorie>> Get_1()
		{
			var data = new KategoriaController().WylistujPodkategorie();

			if (data == null)
			{
				return NotFound();
			}
			return data;
		}


		/// <summary>
		/// Stwórz nową Kategorie
		/// </summary>
		/// <param name="kat"></param>
		/// <returns></returns>
		[HttpPost("DodajNowaKategorie")]
		public int Post(NowaKategoria kat)
		{
			return new KategoriaController().DodajKategorie(kat);

		}


		/// <summary>
		/// Stwórz nową podkategorie
		/// </summary>
		/// <param name="pkat"></param>
		/// <returns></returns>
		[HttpPost("DodajNowaPodkategorie")]
		public int Post_1(NowaPodkategoria pkat)
		{
			return new KategoriaController().DodajPodkategorie(pkat);
		}


		/// <summary>
		/// Usuń kategorie o danym ID
		/// </summary>
		/// <param name="id"></param>
		[HttpDelete("UsunWskazanaKategorie")]
		public void Delete(int id)
		{
			new KategoriaController().UsunKategorie(id);
		}

		/// <summary>
		/// Usuń podkategorie o danym ID
		/// </summary>
		/// <param name="id"></param>
		[HttpDelete("UsunWskazanaPodkategorie")]
		public void Delete_1(int id)
		{
			new KategoriaController().UsunPodkategorie(id);
		}
	}
}