using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.ViewModels;

namespace WebApplication.Services
{
	public interface IArkuszService
	{
		Task<System.Collections.Generic.ICollection<ReportFromMonthsViewModel>> GetRaportAsync(ReportFromMonthsParametersViewModel rap);


		Task UpdateAsync10(AddTransactionToPlan fplan);

		Task<System.Collections.Generic.ICollection<PlanViewModel>> Get_Plan();
		Task<int> Post_Plan(NewPlanViewModel newplan);
		Task Delete_Plan(int id);
		Task Update_Plan(UpdatePlanViewModel plan);



		Task<System.Collections.Generic.ICollection<KategoriaViewModel>> Get_Kategorie();
		Task<int> Post_Kategoria(NowaKategoria newkat);
		Task Delete_Kategoria(int id);



		Task<System.Collections.Generic.ICollection<PodkategoriaViewModel>> Get_Podkategorie();
		Task<int> Post_Podkategoria(NewPodkategoriaViewModel newkat);
		Task Delete_Podkategoria(int id);



		Task<System.Collections.Generic.ICollection<TranskacjaViewModel>> Get_Transakcje();
		Task<int> Post_Transakcja(NewTransakcjaViewModel newtr);
		Task Delete_Transakcja(int id);
		Task<TranskacjaViewModel> Get_TransakcjaID(int id);



		Task<System.Collections.Generic.ICollection<UzytkownikViewModel>> Get_Uzytkownicy();
		Task<UzytkownikViewModel> Get_UzytkownikID(int id);
		Task<int> Post_Uzytkownik(NewUzytkownikViewModel newtr);
		Task Delete_Uzykownik(int id);

	}
}
