using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Services;
using WebApplication.ViewModels;

namespace WebApplication
{
	public class MapperProfile:Profile
	{
		public MapperProfile()
		{
			CreateMap<KategoriaViewModel, Kategorie>().ReverseMap();
			CreateMap<TranskacjaViewModel, Transakcje>().ReverseMap();
			CreateMap<NewKategoriaViewModel, NowaKategoria>().ReverseMap();
			CreateMap<NewUzytkownikViewModel, NowyUzytkownik>().ReverseMap();
			CreateMap<UzytkownikViewModel, Uzytkownik>().ReverseMap();
			CreateMap<NewTransakcjaViewModel, NowaTransakcja>().ReverseMap();
			CreateMap<NewTransakcjaViewModel, NewTransakcjaVM>().ReverseMap();
			CreateMap<DateTimeOffset, DateTime>();
		}

	}
}
