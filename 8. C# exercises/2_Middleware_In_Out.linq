<Query Kind="Program" />

void Main()
{	
	//2. Newer approach is to use Action. Action don't return anything, so this is for void functions	
		Try(()=>Wrap(FirstFunction));
		Wrap(()=>Try(SecondFunction));		 //Using Lambda function we putting it on a cratch, so it is created another function like below. Another words lambda is always converted into local funtion :( and this is not efficient way to write c# programms
}

public void FirstFunction()
{
	"executing first function".Dump();
}

public void SecondFunction()
{
	"executing second function".Dump();
}

public void LambdaSecond() //so this is some unapropriate way that is running through program
{
	Wrap(FirstFunction);
}

public void Wrap(Action function)
{
	"start".Dump();
	function();
	"end".Dump();
}

public void Try(Action function)
{
	try
	{
		"trying".Dump();
		function();
	}
	catch(Exception)
	{
	}
}
