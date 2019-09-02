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

			ICollection<TranskacjaViewModel> currentTransakcjaItems = await _arkuszService.Get_Transakcje();
			var model = new ListTransakcjaViewModel()
			{
				Items = currentTransakcjaItems
			};
			return View(model);

		}

		[Route("/WebApiTranskacja/UsunWskazanaTransakcje/{id}")]
		public async Task<IActionResult> DeleteTransaction(int id)
		{
			await _arkuszService.Delete_Kategoria(id);
			return RedirectToAction(nameof(ListTransactions));
		}
	}
}