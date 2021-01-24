<Query Kind="Program" />

void Main()
{	
	//Wrap("2", SecondFunction); 
	
	Action<string> pipe = (msg)=>
		Try2(msg, (msg1)=>
			Try(msg1,(msg2)=>
				Wrap(msg2,SecondFunction)));
				
	pipe("1");
}

public void FirstFunction(string msg)
{
	$"executing {msg}".Dump("first function");
}

public void SecondFunction(string msg)
{
	$"executing {msg}".Dump("second function");
}

public void Wrap(string msg, Action<string> function)
{
	msg.Dump("starting");
	function(msg);
	"end".Dump();
}

public void Try(string msg, Action<string> function)
{
	try
	{
		msg.Dump("trying");
		function(msg);
	}
	catch(Exception)
	{
	}
}

public void Try2(string msg, Action<string> function)
{
	try
	{
		msg.Dump("trying");
		function(msg);
	}
	catch(Exception)
	{
	}
}
