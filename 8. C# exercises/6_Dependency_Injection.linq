<Query Kind="Program" />

void Main()
{
	var container = new DependencyContainer();
	container.AddDependency(typeof(HelloService));
	container.AddDependency<ServiceConsumer>();
	container.AddDependency<MessageService>();
	
	var resolver = new DependencyResolver(container);
	
	var service = resolver.GetService<HelloService>(); // so this part take Type of HelloService and initialize it through Reflection
	
	var service1 = resolver.GetService<ServiceConsumer>();
	
	service.Print();
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
		var constructor = dependency.GetConstructors().Single(); // because when we run program we can have only one used constructor during runtime
		var parameters = constructor.GetParameters().ToArray();
		
		if(parameters.Length > 0)
		{
			var parameterImplementations = new object[parameters.Length];
			
			for(int i = 0; i < parameters.Length;i++)
			{
				parameterImplementations[i] = GetService(parameters[i].ParameterType);
			}
			return Activator.CreateInstance(dependency, parameterImplementations); 
		}
		
		return Activator.CreateInstance(dependency); 
	}
}

public class DependencyContainer
{
	List<Type> _dependencies; 
	
	public void AddDependency(Type type)
	{
		_dependencies = new List<Type>();
		_dependencies.Add(type);
	}
	
		public void AddDependency<T>()
	{
		_dependencies.Add(typeof(T));
	}
	
	public Type GetDependency(Type type)
	{
		return _dependencies.First(x=>x.Name == type.Name);
	}
}

public class HelloService
{
	MessageService _message;
	public HelloService(MessageService message)
	{
		_message = message;
	}
	
	public void Print()
	{
		$"Hello world {_message.Message()}".Dump();
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
	public string Message()
	{
		return "yo";
	}
}


