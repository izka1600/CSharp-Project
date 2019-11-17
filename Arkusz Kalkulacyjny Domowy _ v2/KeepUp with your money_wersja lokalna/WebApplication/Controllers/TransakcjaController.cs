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
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class TransakcjaController : Controller
    {
		private readonly IAntiforgery _antiforgery;

		private readonly IArkuszService _arkuszService;
		private readonly UserManager<AppUser> _userManager;

		public TransakcjaController(
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

		[Route("/WebApiTranskacja/WylistujTransakcje")]
		public async Task<IActionResult> ListTransactions()
		{

			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				return RedirectToAction("ListTransactions");
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
			ICollection<TranskacjaViewModel> AllcurrentTransakcjaItems = await _arkuszService.Get_Transakcje();

			ICollection<TranskacjaViewModel> currentTransakcjaItems = new List<TranskacjaViewModel>();

			foreach (var item in AllcurrentTransakcjaItems)
			{
				if (item.IdUzytkownika == UzId)
				{
					currentTransakcjaItems.Add(item);
				}
			}

			var model = new ListTransakcjaViewModel()
			{
				Items = currentTransakcjaItems
			};

			ICollection<KategoriaViewModel> currentKategoriaItems = await _arkuszService.Get_Kategorie();
			ICollection<KategoriaViewModel> newCurrentKategoriaItems = new List<KategoriaViewModel>();
			foreach (var item in currentKategoriaItems)
			{
				if (item.UzId == UzId || item.UzId == 0)
				{
					newCurrentKategoriaItems.Add(item);
				}
			}
			var model1 = new ListKategoriaViewModel()
			{
				Items = newCurrentKategoriaItems
			};

			ICollection<PodkategoriaViewModel> currentPodkategoriaItems = await _arkuszService.Get_Podkategorie();
			ICollection<PodkategoriaViewModel> newCurrentPodkategoriaItems = new List<PodkategoriaViewModel>();

			foreach (var item in currentPodkategoriaItems)
			{
				foreach (var x in newCurrentKategoriaItems)
				{
					if (item.IdKategorii == x.KatId)
					{
						newCurrentPodkategoriaItems.Add(item);
					}
				}
			}

			var model2 = new ListPodkategoriaViewModel()
			{
				Items = newCurrentPodkategoriaItems
			};

			ICollection<PlanViewModel> currentPlanItems = await _arkuszService.Get_Plan();
			ICollection<PlanViewModel> newCurrenPlanItems = new List<PlanViewModel>();
			foreach (var item in currentPlanItems)
			{
				if (item.IdUzytkownika == UzId)
				{
					newCurrenPlanItems.Add(item);
				}
			}

			var model3 = new ListPlanViewModel()
			{
				Items = newCurrenPlanItems
			};

			var tuple = new Tuple<ListTransakcjaViewModel,ListKategoriaViewModel, ListPodkategoriaViewModel, ListPlanViewModel>(model, model1, model2, model3);
			return View(tuple);

		}

		[Route("/WebApiTranskacja/DodajNowaTransakcje")]
		public async Task<IActionResult> AddNewTransaction()
		{
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				return RedirectToAction("ListTransactions");
			}

			ICollection<UzytkownikViewModel> UsersList = await _arkuszService.Get_Uzytkownicy();

			ICollection<KategoriaViewModel> currentKategoriaItems = await _arkuszService.Get_Kategorie();
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
				if (item.UzId == UzId || item.UzId == 0)
				{
					newCurrentKategoriaItems.Add(item);
				}
			}

			var model = new ListKategoriaViewModel()
			{
				Items = newCurrentKategoriaItems
			};

			ICollection<PodkategoriaViewModel> currentPodkategoriaItems = await _arkuszService.Get_Podkategorie();
			ICollection<PodkategoriaViewModel> newCurrentPodkategoriaItems = new List<PodkategoriaViewModel>();

			foreach (var item in currentPodkategoriaItems)
			{
				foreach (var x in newCurrentKategoriaItems)
				{
					if (item.IdKategorii == x.KatId)
					{
						newCurrentPodkategoriaItems.Add(item);
					}
				}
			}

			var model1 = new ListPodkategoriaViewModel()
			{
				Items = newCurrentPodkategoriaItems
			};

			ICollection<PlanViewModel> currentPlanItems = await _arkuszService.Get_Plan();
			ICollection<PlanViewModel> newCurrenPlanItems = new List<PlanViewModel>();
			foreach (var item in currentPlanItems)
			{
				if (item.IdUzytkownika == UzId )
				{
					newCurrenPlanItems.Add(item);
				}
			}

			var model2 = new ListPlanViewModel()
			{
				Items = newCurrenPlanItems
			};

			var tuple = new Tuple<NewTransakcjaVM_Month, ListKategoriaViewModel, ListPodkategoriaViewModel, ListPlanViewModel>(new NewTransakcjaVM_Month(), model, model1, model2);
			return View(tuple);
		}

		[Route("/WebApiTranskacja/DodajNowaTransakcje")]
		[HttpPost]
		public async Task<IActionResult> AddNewTransaction([Bind(Prefix = "Item1")] NewTransakcjaVM_Month newtrVM)
		{
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				RedirectToAction("ListTransactions");
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

			ICollection<PlanViewModel> currentPlanItems = await _arkuszService.Get_Plan();
			int x = 0;
			foreach (var item in currentPlanItems)
			{
				if (item.IdUzytkownika == UzId && item.Miesiąc.ToString().Substring(0,7) == newtrVM.Month.ToString().Substring(0,7))
				{
					x = item.PlanId;
				}
			}


			NewTransakcjaViewModel newtr = new NewTransakcjaViewModel
			{
				IdUzytkownika = UzId,
				Kwota =newtrVM.Kwota,
				IdPodkategorii = newtrVM.IdPodkategorii,
				IdKategorii = newtrVM.IdKategorii,
				PlanId = x,
				Data = newtrVM.Data
			};

			int currentTransakcjaId = await _arkuszService.Post_Transakcja(newtr);
			AddTransactionToPlan FaktycznyPlan = new AddTransactionToPlan
			{
				PlanId = x,
				Amount = (decimal)newtrVM.Kwota
			};
			await _arkuszService.UpdateAsync10(FaktycznyPlan);
			return RedirectToAction(nameof(ListTransactions));
		}


		[Route("/WebApiTranskacja/UsunWskazanaTransakcje/{id}")]
		public async Task<IActionResult> DeleteTransaction(int id)
		{
			await _arkuszService.Delete_Transakcja(id);
			return RedirectToAction(nameof(ListTransactions));
		}
	}
}