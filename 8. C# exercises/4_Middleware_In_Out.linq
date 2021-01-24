<Query Kind="Program" />

void Main()
{	
  
}

public void FirstFunction(string msg)
{
	$"executing {msg}".Dump("first function");
}

public void SecondFunction(string msg)
{
	$"executing {msg}".Dump("second function");
}

public class PipeBuilder
{
	Action<string>_mainAction;
	List<Type> _pipeTypes;
	
	public PipeBuilder(Action<string> mainAction)
	{
		_mainAction = mainAction;
		_pipeTypes = new List<Type>();
	}
	
	public void AddPipe(Type pipeType)
	{
		if(!pipeType.GetTypeInfo().IsInstanceOfType(typeof(Pipe)))
		{
			throw new Exception();
		}
		_pipeTypes.Add(pipeType);
	}
}

public abstract class Pipe  //I want to abstract class not interface because I want to fill my constructor;
{
	protected Action<string> _action;
	public Pipe(Action<string> action)
	{
		_action = action;
	}
	
	public abstract void Handle(string msg);
}

public class Wrap : Pipe
{
	public Wrap(Action<string> action) :base(action){}
	
	public override void Handle(string msg)
	{
		msg.Dump("starting");
		_action(msg);
		"end".Dump();
	}
}

public class Try : Pipe
{
	public Try(Action<string> action) :base(action){}
	
	public override void Handle(string msg)
	{
		try
		{
			msg.Dump("trying");
			_action(msg);
		}
		catch(Exception)
		{
		}
	}
}

