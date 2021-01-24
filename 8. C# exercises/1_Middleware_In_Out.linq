<Query Kind="Program" />

void Main()
{
	//1. We can treat a function like a variable - in first approach we use parameters
	
			//"start".Dump();
			//FirstFunction();
			//"end".Dump();	
			Wrap(FirstFunction);
			
			// "start".Dump();
			// SecondFunction();
			// "end".Dump();	
			Wrap(SecondFunction); 
	
	//2. Newer approach is to use Action. Action don't return anything, so this is for void functions
	
			A_Wrap(FirstFunction);
			A_Wrap(SecondFunction);
			
		// Action with input parameters
			AA_Wrap(ThirdFunction);
}

public void FirstFunction()
{
	"executing first function".Dump();
}

public void SecondFunction()
{
	"executing second function".Dump();
}

public void ThirdFunction(int i)
{
	"executing second function".Dump();
}

public delegate void ToWrap(); //A delegate is some interface for the function. This delegate tells us that we excepting a function which is void and has no input parameters 

public void Wrap(ToWrap function)
{
	"start".Dump();
	function();
	"end".Dump();
}

public void A_Wrap(Action function)
{
	"start".Dump();
	function();
	"end".Dump();
}

public void AA_Wrap(Action<int> function)
{
	"start".Dump();
	function(1);
	"end".Dump();
}