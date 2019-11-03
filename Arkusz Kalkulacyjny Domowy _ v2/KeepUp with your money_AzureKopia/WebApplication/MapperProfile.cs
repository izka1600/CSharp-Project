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
			CreateMap<ReportFromMonthsViewModel, RaportFromMonths>().ReverseMap();
			CreateMap<ReportFromMonthsParametersViewModel, ReportFromMonthsParametres>().ReverseMap();

			CreateMap<AddTransactionToPlan, UpdateFaktycznyPlan>().ReverseMap();

			CreateMap<PlanViewModel, Plan>().ReverseMap();
			CreateMap<NewPlanViewModel, NowyPlan>().ReverseMap();
			CreateMap<UpdatePlanViewModel, UpdatePlan>().ReverseMap();

			CreateMap<KategoriaViewModel, Kategorie>().ReverseMap();
			CreateMap<NewKategoriaViewModel, NowaKategoria>().ReverseMap();

			CreateMap<PodkategoriaViewModel, Podkategorie>().ReverseMap();
			CreateMap<NewPodkategoriaViewModel, NowaPodkategoria>().ReverseMap();

			CreateMap<TranskacjaViewModel, Transakcje>().ReverseMap();
			CreateMap<NewTransakcjaViewModel, NowaTransakcja>().ReverseMap();
			CreateMap<NewTransakcjaViewModel, NewTransakcjaVM_Month>().ReverseMap();

			CreateMap<NewUzytkownikViewModel, NowyUzytkownik>().ReverseMap();
			CreateMap<UzytkownikViewModel, Uzytkownik>().ReverseMap();

			CreateMap<DateTimeOffset, DateTime>();
		}

	}
}
