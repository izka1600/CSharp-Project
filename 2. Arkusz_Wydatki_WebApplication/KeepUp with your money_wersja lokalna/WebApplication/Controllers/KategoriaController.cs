using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AuthDatabase.Entities;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Services;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class KategoriaController : Controller
    {
		private readonly IAntiforgery _antiforgery;

		private readonly IArkuszService _arkuszService;
		private readonly UserManager<AppUser> _userManager;
		private readonly IHostingEnvironment _hostingEnvironment;
		public KategoriaController(
			IArkuszService arkuszService,
			UserManager<AppUser> userManager,
			IHostingEnvironment hostingEnvironment)
		{
			_hostingEnvironment = hostingEnvironment;
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
			var model0 = new ListKategoriaViewModel()
			{
				Items = NewKategoriaItems
			};

			var model = new ListPodkategoriaViewModel()
			{
				Items = newCurrentPodkategoriaItems
			};

			var tuple = new Tuple<ListKategoriaViewModel, ListPodkategoriaViewModel>( model0, model);
			return View(tuple);

		}

		[Route("/WebApiKategoria/UsunWskazanaPodkategorie/{id}")]
		public async Task<IActionResult> DeleteSubcategory(int id)
		{
			await _arkuszService.Delete_Podkategoria(id);
			return RedirectToAction(nameof(ListSubcategories));
		}

		[Route("/WebApiKategoria/DodajNowaPodkategorie")]
		public async Task<IActionResult> AddNewSubcategory()
		{
			var currentUser = await _userManager.GetUserAsync(User);
			ICollection<UzytkownikViewModel> UsersList = await _arkuszService.Get_Uzytkownicy();
			if (currentUser == null)
			{
				return RedirectToAction("ListSubcategories");
			}
			int UzId = 0;
			foreach (var item in UsersList)
			{
				if (item.EMail.ToUpper() == currentUser.Email.ToUpper())
				{
					UzId = item.UzytId;
				}
			}
			ICollection<KategoriaViewModel> currentKategoriaItems = await _arkuszService.Get_Kategorie();
			ICollection<KategoriaViewModel> NewKategoriaItems = new List<KategoriaViewModel>();
			foreach (var item in currentKategoriaItems)
			{
				if (item.UzId == UzId || item.UzId == 0)
				{
					NewKategoriaItems.Add(item);
				}
			}

			var model1 = new ListKategoriaViewModel()
			{
				Items = NewKategoriaItems
			};

			var tuple = new Tuple<NewPodkategoriaViewModel, ListKategoriaViewModel>(new NewPodkategoriaViewModel(), model1);
			return View(tuple);

		}

		[Route("/WebApiKategoria/DodajNowaPodkategorie")]
		[HttpPost]
		public async Task<IActionResult> AddNewSubcategory([Bind(Prefix = "Item1")]NewPodkategoriaViewModel newsubkat)
		{
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				RedirectToAction("ListSubcategories");
			}

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
		public async Task<IActionResult> AddNewCategory()
		{
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				RedirectToAction("ListCategories");
			}
			return View();
		}

		[Route("/WebApiKategoria/DodajNowaKategorie")]
		[HttpPost]
		public async Task<IActionResult> AddNewCategory(AddNewCategoryViewModel newkat)
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

			string uniquefileName = null; 
			if (newkat.Photo != null)
			{
				string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");
				uniquefileName = Guid.NewGuid().ToString() + "_" + newkat.Photo.FileName;
				string filePath = Path.Combine(uploadsFolder, uniquefileName);
				newkat.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
			}

			NowaKategoria nowaKat = new NowaKategoria
			{
				Kategoria = newkat.Kategoria,
				IdUzytkownika = UzId,
				SciezkaDoZdjecia = uniquefileName
			};

			int currentKategoriaId = await _arkuszService.Post_Kategoria(nowaKat);
			return RedirectToAction(nameof(ListCategories));
		}

	}
}