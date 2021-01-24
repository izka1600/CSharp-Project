using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DBClassMapper_Reflection
{
				//https://stackoverflow.com/questions/47767871/dynamically-create-c-sharp-class-or-object
	public class Program
	{
		public class FirstClass
		{
			public List<Foo> FooList { get; set; }
		}

		public class Foo
		{
			//Ex:
			//public string Name{ get; set; }  
		}

		public static void Main(string[] args)
		{

			var bar1Code =  @"
                                public class Bar1 : Foo
                                {
                                    public Bar1(int value)
                                    {
                                        NewProperty = value;
                                    }
                                    public int NewProperty {get; set; }
                                }" ;

			var csc = new CSharpCodeProvider(
				new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });

			var referencedAssemblies =
					AppDomain.CurrentDomain.GetAssemblies()
					.Where(a => !a.FullName.StartsWith("mscorlib", StringComparison.InvariantCultureIgnoreCase))
					.Where(a => !a.IsDynamic) //necessary because a dynamic assembly will throw and exception when calling a.Location
					.Select(a => a.Location)
					.ToArray();

			var parameters = new CompilerParameters(
				referencedAssemblies);

			var result = csc.CompileAssemblyFromSource(parameters, bar1Code);
			var bar1Type = result.CompiledAssembly.GetType("Bar1");

			//var firstClass = new FirstClass
			//{
			//	FooList = new List<Foo>
			//		{
			//			(Foo)Activator.CreateInstance(bar1Type, 56),
			//		}
			//};

			//var dynamicFoo = (dynamic)firstClass.FooList[0];
			//int i = dynamicFoo.NewProperty; // should be 56
			Console.WriteLine();
			Console.ReadKey();


		}
	}
}
