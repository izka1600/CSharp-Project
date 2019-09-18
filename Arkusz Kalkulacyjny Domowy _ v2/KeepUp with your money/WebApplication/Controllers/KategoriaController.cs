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

		[Route("/WebApiKategoria/WylistujPodkategorie")]
		public async Task<IActionResult> ListSubcategories()
		{

			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				return RedirectToAction("ListSubcategories");
			}

			ICollection<KategoriaViewModel> currentKategoriaItems = await _arkuszService.Get_Kategorie();
			ICollection<KategoriaViewModel> NewKategoriaItems = new List<KategoriaViewModel>();
			ICollection<UzytkownikViewModel> UsersList = await _arkuszService.Get_Uzytkownicy();

			ICollection<PodkategoriaViewModel> currentPodkategoriaItems = await _arkuszService.Get_Podkategorie();
			ICollection<PodkategoriaViewModel> newCurrentPodkategoriaItems = new List<PodkategoriaViewModel>();
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
				if (item.UzId == UzId || item.UzId == 0)
				{
					NewKategoriaItems.Add(item);
				}
			}

			foreach (var item in currentPodkategoriaItems)
			{
				foreach (var x in NewKategoriaItems)
				{
					if (item.IdKategorii == x.KatId)
					{
						newCurrentPodkategoriaItems.Add(item);
					}
				}
			}

			var model = new ListPodkategoriaViewModel()
			{
				Items = newCurrentPodkategoriaItems
			};
			return View(model);

		}

		[Route("/WebApiKategoria/UsunWskazanaPodkategorie/{id}")]
		public async Task<IActionResult> DeleteSubcategory(int id)
		{
			await _arkuszService.Delete_Podkategoria(id);
			return RedirectToAction(nameof(ListSubcategories));
		}

		[Route("/WebApiKategoria/DodajNowaPodkategorie")]
		public IActionResult AddNewSubcategory()
		{
			return View();
		}
		[Route("/WebApiKategoria/DodajNowaPodkategorie")]
		[HttpPost]
		public async Task<IActionResult> AddNewSubcategory(NewPodkategoriaViewModel newsubkat)
		{
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				RedirectToAction("ListSubcategories");
			}
			ICollection<UzytkownikViewModel> UsersList = await _arkuszService.Get_Uzytkownicy();
			int UzId = 0;
			foreach (var item in UsersList)
			{
				if (item.EMail.ToUpper() == currentUser.Email.ToUpper())
				{
					UzId = item.UzytId;
				}
			}
			//newkat.IdUzytkownika = UzId;

			int currentKategoriaId = await _arkuszService.Post_Podkategoria(newsubkat);
			return RedirectToAction(nameof(ListSubcategories));
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
			ICollection<UzytkownikViewModel> UsersList = await _arkuszService.Get_Uzytkownicy();
			int UzId = 0;
			foreach (var item in UsersList)
			{
				if (item.EMail.ToUpper() == currentUser.Email.ToUpper())
				{
					UzId = item.UzytId;
				}
			}
			newkat.IdUzytkownika = UzId;

			int currentKategoriaId = await _arkuszService.Post_Kategoria(newkat);
			return RedirectToAction(nameof(ListCategories));
		}

	}
}