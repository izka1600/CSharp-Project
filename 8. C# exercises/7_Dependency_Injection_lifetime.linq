<Query Kind="Program" />

void Main()
{
	var container = new DependencyContainer();
	container.AddTransient<ServiceConsumer>();
	container.AddTransient<HelloService>();
	container.AddSingleton<MessageService>();
	
	var resolver = new DependencyResolver(container);
	
	var service1 = resolver.GetService<ServiceConsumer>(); // so this part take Type of HelloService and initialize it through Reflection	
	var service2 = resolver.GetService<ServiceConsumer>();
	var service3 = resolver.GetService<ServiceConsumer>();
	
	service1.Print();
	service2.Print();
	service3.Print();
}

public class DependencyResolver
{
	DependencyContainer _container;

	public DependencyResolver(DependencyContainer container)
	{
		_container = container;
	}
	
	public T GetService<T>()
	{
		return (T) GetService(typeof(T));
	}
	
	public object GetService(Type type)
	{
		var dependency = _container.GetDependency(type);
		var constructor = dependency.Type.GetConstructors().Single(); // because when we run program we can have only one used constructor during runtime
		var parameters = constructor.GetParameters().ToArray();
		
		if(parameters.Length > 0)
		{
			var parameterImplementations = new object[parameters.Length];
			
			for(int i = 0; i < parameters.Length;i++)
			{
				parameterImplementations[i] = GetService(parameters[i].ParameterType);
			}
			return CreateImplementation(dependency, t => Activator.CreateInstance(t,parameterImplementations));	
		}
		
		return CreateImplementation(dependency, t => Activator.CreateInstance(t));		
	}
	
	public object CreateImplementation(Dependency dependency, Func<Type, object> factory)
	{
		if(dependency.Implemented)
		{
			return dependency.Implementation;
		}
		
		var implementation = factory(dependency.Type);
		
		if(dependency.LifeTime == DependencyLifeTime.Singleton)
		{
			dependency.AddImplementation(implementation);
		}		
		
		return implementation;
	}
}

public class DependencyContainer
{
	List<Dependency> _dependencies; 
	
	public DependencyContainer()
	{
		_dependencies = new List<Dependency>();
	}
	
	public void AddSingleton<T>()
	{
		_dependencies.Add(new Dependency(typeof(T), DependencyLifeTime.Singleton));
	}
	
	public void AddTransient<T>()
	{
		_dependencies.Add(new Dependency(typeof(T), DependencyLifeTime.Transient));
	}
	
	public Dependency GetDependency(Type type)
	{
		return _dependencies.First(x=>x.Type.Name == type.Name);
	}
}

public class HelloService
{
	MessageService _message;
	int _random;
	public HelloService(MessageService message)
	{
		_message = message;
		_random = new Random().Next();
	}
	
	public void Print()
	{
		$"Hello #{_random} world {_message.Message()}".Dump();
	}
}

public class ServiceConsumer
{
	HelloService _hello;

	public ServiceConsumer(HelloService hello)
	{
		_hello = hello;
	}

	public void Print()
	{
		_hello.Print();
	}
}

public class MessageService
{
	int _random;
	
	public MessageService()
	{
		_random = new Random().Next();
	}
	public string Message()
	{
		return $"yo #{_random}";
	}
}

public class Dependency
{
	public Dependency(Type t, DependencyLifeTime l)
	{
		Type = t;
		LifeTime = l;
	}
	
	public Type Type {get; set;}
	public DependencyLifeTime LifeTime{get;set;}
	public object Implementation {get;set;}
	public bool Implemented {get;set;}
	public void AddImplementation(object i)
	{
		Implementation = i;
		Implemented = true;
	}
}

public enum DependencyLifeTime
{
	Singleton = 0,
	Transient = 1, // it's gonna be refreshed instance every time
}


