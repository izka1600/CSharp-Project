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
		string url = "https://localhost:44382/";
		HttpClient httpClient = new HttpClient();

		private readonly IMapper _mapper;

		public ArkuszSerice(IMapper mapper)
		{
			_mapper = mapper;
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
		public async Task<System.Collections.Generic.ICollection<KategoriaViewModel>> Get_Uzytkownicy()
		{
			ArkuszServiceHttpClient todoServiceClient = new ArkuszServiceHttpClient(url, httpClient);
			ICollection<Kategorie> dtoKategorie = await todoServiceClient.GetAllAsync();

			ICollection<KategoriaViewModel> returnValue = _mapper.Map<List<KategoriaViewModel>>(dtoKategorie);

			return returnValue;
		}

	}
}
