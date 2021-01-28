<Query Kind="Program" />

void Main()
{
	//var service = new HelloService();
	//var consumer = new ServiceConsumer(service);
	
	
	//This way we can create instance of a class without using new 
	var service = (HelloService) Activator.CreateInstance(typeof(HelloService)); //Activator is a static class which is a part of Reflection API
	var consumer = (ServiceConsumer) Activator.CreateInstance(typeof(ServiceConsumer), service);
	service.Print();
	consumer.Print();
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


