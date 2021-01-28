<Query Kind="Program" />

void Main()
{
//24 min

	var container = new DependencyContainer();
	container.AddDependency(typeof(HelloService));
	container.AddDependency<ServiceConsumer>();
	
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
		var dependency = _container.GetDependency(typeof(T));
		var constructor = dependency.GetConstructors().Single();
		var parameters = constructor.GetParameters().ToArray();
		
		if(parameters.Length > 0)
		{
			var parameterImplementations = new object[parameters.Length];
			
			for(int i = 0; i < parameters.Length;i++)
			{
				parameterImplementations[i] = Activator.CreateInstance(parameters[i].ParameterType);
			}
			return (T) Activator.CreateInstance(dependency, parameterImplementations); 
		}
		
		return (T) Activator.CreateInstance(dependency); 
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
	public void Print()
	{
		"Hello world".Dump();
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


