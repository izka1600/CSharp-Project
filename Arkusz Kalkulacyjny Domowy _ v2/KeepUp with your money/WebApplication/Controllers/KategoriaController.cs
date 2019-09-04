using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthDatabase.Entities;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class KategoriaController : Controller
    {
		private readonly IAntiforgery _antiforgery;

		private readonly IArkuszService _arkuszService;
		private readonly UserManager<AppUser> _userManager;

		public KategoriaController(
			IArkuszService arkuszService,
			UserManager<AppUser> userManager)
		{
			_arkuszService = arkuszService;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				return Challenge();
			}

			return View();
		}

		[Route("/WebApiKategoria/WylistujKategorie")]
		public async Task<IActionResult> ListCategories()
		{

			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				return RedirectToAction("ListCategories");
			}

			ICollection<KategoriaViewModel> currentKategoriaItems = await _arkuszService.Get_Kategorie();
			ICollection<UzytkownikViewModel> UsersList = await _arkuszService.Get_Uzytkownicy();

			ICollection<KategoriaViewModel> newCurrentKategoriaItems = new List<KategoriaViewModel>();
			int UzId = 0;
			foreach (var item in UsersList)
			{
				if (item.EMail.ToUpper() == currentUser.Email.ToUpper())
				{
					UzId = item.UzytId;
				}
			}

			foreach (var item in currentKategoriaItems)
			{
				if (item.UzId== UzId || item.UzId==0)
				{
					newCurrentKategoriaItems.Add(item);
				}
			}
				
			var model = new ListKategoriaViewModel()
			{
				Items = newCurrentKategoriaItems
			};
			return View(model);

		}

		[Route("/WebApiKategoria/UsunWskazanaKategorie/{id}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			await _arkuszService.Delete_Kategoria(id);
			return RedirectToAction(nameof(ListCategories));
		}

		[Route("/WebApiKategoria/DodajNowaKategorie")]
		public IActionResult AddNewCategory()
		{
			return View();
		}

		[Route("/WebApiKategoria/DodajNowaKategorie")]
		[HttpPost]
		public async Task<IActionResult> AddNewCategory(NewKategoriaViewModel newkat)
		{
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				RedirectToAction("ListCategories");
			}

			int currentKategoriaId = await _arkuszService.Post_Kategoria(newkat);
			return RedirectToAction(nameof(ListCategories));
		}

	}
}