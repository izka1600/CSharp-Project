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
    public class PlanController : Controller
    {
		private readonly IAntiforgery _antiforgery;

		private readonly IArkuszService _arkuszService;
		private readonly UserManager<AppUser> _userManager;

		public PlanController(
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

		[Route("/WebApiPlan/WylistujPlany")]
		public async Task<IActionResult> ListPlans()
		{

			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				return RedirectToAction("ListPlans");
			}

			ICollection<PlanViewModel> currentPlanItems = await _arkuszService.Get_Plan();
			ICollection<PlanViewModel> NewPlanItems = new List<PlanViewModel>();
			ICollection<UzytkownikViewModel> UsersList = await _arkuszService.Get_Uzytkownicy();

			int UzId = 0;
			foreach (var item in UsersList)
			{
				if (item.EMail.ToUpper() == currentUser.Email.ToUpper())
				{
					UzId = item.UzytId;
				}
			}

			foreach (var item in currentPlanItems)
			{
				if (item.IdUzytkownika == UzId || item.IdUzytkownika == 0)
				{
					NewPlanItems.Add(item);
				}
			}


			var model = new ListPlanViewModel()
			{
				Items = NewPlanItems
			};
			return View(model);

		}

		[Route("/WebApiPlan/UsunWskazanyPlan/{id}")]
		public async Task<IActionResult> DeletePlan(int id)
		{
			await _arkuszService.Delete_Plan(id);
			return RedirectToAction(nameof(ListPlans));
		}

		[Route("/WebApiPlan/DodajNowyPlan")]
		public async Task<IActionResult> AddNewPlan()
		{
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				return RedirectToAction("ListPlans");
			}
			ICollection<PlanViewModel> currentPlanItems = await _arkuszService.Get_Plan();
			var model = new ListPlanViewModel()
			{
				Items = currentPlanItems
			};
			NewPlanViewModel newPlan = new NewPlanViewModel();

			var tuple = new Tuple<ListPlanViewModel, NewPlanViewModel>(model, newPlan);
			return View(tuple);
		}

		[Route("/WebApiPlan/DodajNowyPlan")]
		[HttpPost]
		public async Task<IActionResult> AddNewPlan([Bind(Prefix = "Item2")]NewPlanViewModel newplan)
		{
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				RedirectToAction("ListPlans");
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

			newplan.IdUzytkownika = UzId;

			int currentTransakcjaId = await _arkuszService.Post_Plan(newplan);
			return RedirectToAction(nameof(ListPlans));
		}
	}
}