using ArkuszDataBase.Class;
using System;
using Xunit;

namespace DataBaseTests
{
	public class UnitTest1

	{

		static NowaTransakcja newTrans = new NowaTransakcja()
		{
			IdKategorii = 1,
			IdPodkategorii = 2,
			IdUzytkownika = 1,
			PlanId=1,
			Kwota = 12.7
		};


	   [Fact]
		public void Test1()
		{
			Assert.Equal(2,newTrans.IdPodkategorii);
		}
	}
}
