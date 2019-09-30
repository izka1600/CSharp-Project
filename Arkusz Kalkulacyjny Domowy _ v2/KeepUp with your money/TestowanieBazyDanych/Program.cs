using System;
using System.Collections.Generic;
using ArkuszDataBase.Class;
using ArkuszDataBase.Controllers;
using ArkuszDataBase.Models;

namespace TestowanieBazyDanych
{
	class Program
	{
		static void Main(string[] args)
		{
			//UzytkownikController kontrolerUzytkownika = new ArkuszDataBase.Controllers.UzytkownikController();
			//kontrolerUzytkownika.StworzNowegoUzytkownika("Piotr", "Koszelak", "piotrusONEONE", "koszelak.piotr@gmail.com");
			//List<Uzytkownik> listaUz = kontrolerUzytkownika.WylistujUzytkownikow();
			//foreach (var item in listaUz)
			//{
			//	Console.WriteLine(item.Imie + " " + item.Nazwisko);
			//}


			//KategoriaController katkontroler = new ArkuszDataBase.Controllers.KategoriaController();
			//katkontroler.DodajKategorie("Jedzenie");
			//katkontroler.DodajKategorie("Bilety");
			//katkontroler.DodajKategorie("Restauracje");
			//katkontroler.DodajKategorie("Oszczędzności");

			//katkontroler.DodajPodkategorie(1, "warzywa");
			//katkontroler.DodajPodkategorie(2, "miejskie");
			//katkontroler.DodajPodkategorie(3, "piątkowe wyjście");

			//List<Kategorie> lista = katkontroler.WylistujKategorie();
			//foreach (var item in lista)
			//{
			//	Console.WriteLine(item.Kategoria);
			//}

			//TransakcjaController trankontroler = new ArkuszDataBase.Controllers.TransakcjaController();
			////trankontroler.DodajTransakcje(Convert.ToDateTime("2019-07-13"), 1, 1, 1, 12.30);
			//Console.WriteLine("Done");

			//PlanController planC = new ArkuszDataBase.Controllers.PlanController();
			//NowyPlan plan = new NowyPlan
			//{
			//	Miesiąc = DateTime.Parse("2019-09-12"),
			//	ZalozonaKwota = 1500,
			//	FaktycznaKwota = 0,
			//	IdUzytkownika = 1011
			//};

			//int x = planC.DodajPlan(plan);
			//Console.WriteLine(x.ToString());


			//AddTransactionToPlanController proced = new AddTransactionToPlanController();
			//proced.AddTransactionToPlan(10000, 4);
			//Console.WriteLine("Done");

			Console.ReadKey();
		}
	}
}
