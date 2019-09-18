using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
	public interface IArkuszService
	{
		Task<System.Collections.Generic.ICollection<KategoriaViewModel>> Get_Kategorie();
		Task<System.Collections.Generic.ICollection<PodkategoriaViewModel>> Get_Podkategorie();
		Task<int> Post_Kategoria(NewKategoriaViewModel newkat);
		Task<int> Post_Podkategoria(NewPodkategoriaViewModel newkat);
		Task Delete_Kategoria(int id);
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
