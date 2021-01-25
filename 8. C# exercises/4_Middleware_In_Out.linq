<Query Kind="Program" />

void Main()
{	
  var pipe = new PipeBuilder(FirstFunction)
  				.AddPipe(typeof(Try))
				.AddPipe(typeof(Wrap))
				.Build();
  pipe("Hello");
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
	
	public PipeBuilder AddPipe(Type pipeType)
	{
		_pipeTypes.Add(pipeType);
		return this;
	}
	
	private Action<string> CreatePipe(int index) //First we want to initialize the child pipe and then a parent pipe
	{
		if(index < _pipeTypes.Count() - 1) 
		{
			var childPipeHandle = CreatePipe(index+1);
			var pipe = (Pipe) Activator.CreateInstance(_pipeTypes[index], childPipeHandle);
			return pipe.Handle;
		}
		else //else Im reaching a last pipe
		{
			var finalPipe = (Pipe)Activator.CreateInstance(_pipeTypes[index], _mainAction);
			return finalPipe.Handle;
		}
	}
	
	public Action<string> Build()
	{
		return CreatePipe(0);
	}
}

public abstract class Pipe  //I want to abstract class not interface because I want to fill my constructor;
{
	protected Action<string> _action; //protected means that everything that inherit from this class can use _action
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

