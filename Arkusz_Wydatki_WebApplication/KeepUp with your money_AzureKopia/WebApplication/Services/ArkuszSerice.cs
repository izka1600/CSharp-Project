using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
	public class ArkuszSerice : IArkuszService
	{
		string url = "https://webapikuwym.azurewebsites.net/";
		HttpClient httpClient = new HttpClient();

		private readonly IMapper _mapper;

		public ArkuszSerice(IMapper mapper)
		{
			_mapper = mapper;
		}

		//wyświetlam raport 
		public async Task<System.Collections.Generic.ICollection<ReportFromMonthsViewModel>> GetRaportAsync(ReportFromMonthsParametersViewModel rap)
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			ICollection<RaportFromMonths> dtoPlan = await todoServiceClient.GetRaportAsync(_mapper.Map<ReportFromMonthsParametres>(rap));
			ICollection<ReportFromMonthsViewModel> dtoRaport = _mapper.Map<List<ReportFromMonthsViewModel>>(dtoPlan);
			return dtoRaport;
		}

		//updatuje faktyczna kwote planu
		public async Task UpdateAsync10(AddTransactionToPlan fplan)
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			await todoServiceClient.UpdateAsync10(_mapper.Map<UpdateFaktycznyPlan>(fplan));
		}


		//wyświetlam wszystkie plany
		public async Task<System.Collections.Generic.ICollection<PlanViewModel>> Get_Plan()
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			ICollection<Plan> dtoPlan = await todoServiceClient.Get15Async();

			ICollection<PlanViewModel> returnValue = _mapper.Map<List<PlanViewModel>>(dtoPlan);

			return returnValue;
		}

		//dodaję nowy plan
		public async Task<int> Post_Plan(NewPlanViewModel newplan)
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);

			int returnValue = await todoServiceClient.Post22Async(_mapper.Map<NowyPlan>(newplan));

			return returnValue;
		}

		// kasuję plan o danym Id
		public async Task Delete_Plan(int id)
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			await todoServiceClient.Delete20Async(id);
		}

		//updatuje dany plan
		public async Task Update_Plan(UpdatePlanViewModel plan)
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			await todoServiceClient.UpdateAsync(_mapper.Map<UpdatePlan>(plan));
		}


		//wyświetlam wszystkie kategorie
		public async Task<System.Collections.Generic.ICollection<KategoriaViewModel>> Get_Kategorie()
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			ICollection<Kategorie> dtoKategorie = await todoServiceClient.GetAllAsync();

			ICollection<KategoriaViewModel> returnValue = _mapper.Map<List<KategoriaViewModel>>(dtoKategorie);

			return returnValue;
		}

		//dodaję nową kategorie
		public async Task<int> Post_Kategoria(NewKategoriaViewModel newkat)
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);

			int returnValue = await todoServiceClient.PostAsync(_mapper.Map<NowaKategoria>(newkat));

			return returnValue;
		}

		// kasuję kategorię o danym Id
		public async Task Delete_Kategoria(int id)
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			await todoServiceClient.DeleteAsync(id);
		}

		//wyświetlam wszystkie podkategorie
		public async Task<System.Collections.Generic.ICollection<PodkategoriaViewModel>> Get_Podkategorie()
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			ICollection<Podkategorie> dtoKategorie = await todoServiceClient.GetAllAsync10();

			ICollection<PodkategoriaViewModel> returnValue = _mapper.Map<List<PodkategoriaViewModel>>(dtoKategorie);

			return returnValue;
		}

		//dodaję nową podkategorie
		public async Task<int> Post_Podkategoria(NewPodkategoriaViewModel newkat)
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);

			int returnValue = await todoServiceClient.PostAsync10(_mapper.Map<NowaPodkategoria>(newkat));

			return returnValue;
		}

		// kasuję podkategorię o danym Id
		public async Task Delete_Podkategoria(int id)
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			await todoServiceClient.DeleteAsync10(id);
		}

		//wyświetlam wszystkie transakcje
		public async Task<System.Collections.Generic.ICollection<TranskacjaViewModel>> Get_Transakcje()
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			ICollection<Transakcje> dtoTransakcje = await todoServiceClient.GetAsync();

			ICollection<TranskacjaViewModel> returnValue = _mapper.Map<List<TranskacjaViewModel>>(dtoTransakcje);

			return returnValue;
		}

		//dodaję nową transakcje
		public async Task<int> Post_Transakcja(NewTransakcjaViewModel newtr)
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);

			int returnValue = await todoServiceClient.Post2Async(_mapper.Map<NowaTransakcja>(newtr));

			return returnValue;
		}

		// kasuję transakcje o danym Id
		public async Task Delete_Transakcja(int id)
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			await todoServiceClient.Delete2Async(id);
		}

		// wyświetlam transakcje o danym Id 
		public async Task<TranskacjaViewModel> Get_TransakcjaID(int id)
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			Transakcje dtotrans = await todoServiceClient.Get2Async(id);

			TranskacjaViewModel returnValue = _mapper.Map<TranskacjaViewModel>(dtotrans);

			return returnValue;
		}

		//wyświetlam wszystkich użytkowników
		public async Task<System.Collections.Generic.ICollection<UzytkownikViewModel>> Get_Uzytkownicy()
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			ICollection<Uzytkownik> dtoKategorie = await todoServiceClient.Get3Async();

			ICollection<UzytkownikViewModel> returnValue = _mapper.Map<List<UzytkownikViewModel>>(dtoKategorie);

			return returnValue;
		}

		// wyświetlam uzytkownika o danym Id 
		public async Task<UzytkownikViewModel> Get_UzytkownikID(int id)
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			Uzytkownik dtouz = await todoServiceClient.Get4Async(id);

			UzytkownikViewModel returnValue = _mapper.Map<UzytkownikViewModel>(dtouz);

			return returnValue;
		}

		//dodaję nowego użytkownika
		public async Task<int> Post_Uzytkownik(NewUzytkownikViewModel newtr)
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);

			int returnValue = await todoServiceClient.Post3Async(_mapper.Map<NowyUzytkownik>(newtr));

			return returnValue;
		}

		// kasuję użytkownika o danym Id
		public async Task Delete_Uzykownik(int id)
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			await todoServiceClient.Delete2Async(id);
		}

	}
}
