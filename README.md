# DependencyInjection in .NET

Take a look at the following code snippet, it shows an implementation of CustomerService making use of the CustomerDataAccess class features.
There is nothing wrong in this kind of implementation, but you can see that CustomerService class is heavily depends on CustomerDataAccess class for data access

```
public class CustomerService
{
	private CustomerDataAccess custDA;
	
	public CustomerService(connectionString)
	{
		custDA = new CustomerDataAccess(connectionString);
	}
	
	public IEnumerable<Customer> GetCustomers()
	{
		return custDA.GetCustomers()
	}
}

public class CustomerDataAccess
{
	public CustomerDataAccess(string connectionString)
	{
		// ToDo
	}
}

```

So the CustomerService is tightly coupled with CustomerDataAccess. In these type of implementation, there are many issues, some of them are listed below

1. If you have different teams work on HigherLevel Objects ( in this case its CustomerService) and some other team works on Lower level modules ( CustomerDataAccess in this scenario) , because of the tight coupling
   it is very difficult to work in parallel
2. If you change the name of the class CustomerDataAccess , then then you have to go and change the CustomerService class as well and recompile the higherlevel module code , so the `maintainability` is not good
3. Say the CustomerDataAccess class going with a file system based dataaccess , and later you want to create a CustomerDataAccess class to query database , say `CustomerDataAccessSQL`, then we have to change the code in      the  CustomerService class to make use of the CustomerDataAccessSQL, so the `Extensibilty` is also not good

`Dependency Inversion ` Pricioe says, higher level modules does not depend on lower level modules, both should be depend on abstraction.
`Abstraction` means the functionality of both classes ( in this case GetCustomers() is one of the functionality) 

in C#. we can abstract the functionality by using `Inteface`

See the modified version of above code snippet using DI
In this example we are using Parametized Constructor to Inject the dependency, we can also use Property to inject the dependency
```

// From Outside we instantiate CustomerDataAccess
ICustomerDataAccess _custDA = new CustomerDataAccess(connectionString);

CustomerService custService = new CustomerService(_custDA);// We call the CustomerService

public class CustomerService
{
	private ICustomerDataAccess custDA;
	
	public CustomerService(ICustomerDataAccess custDA ) // And this is the Dependency Injection
	{
		_custDA = custDA; // This is the inversion of control
	}
	
	public IEnumerable<Customer> GetCustomers()
	{
		return custDA.GetCustomers()
	}
}

// This is the abstration , this means I have a way to get customers
public interface ICustomerDataAccess
{
	IEnumerable<Customer> GetCustomers();
}

public class CustomerDataAccess : ICustomerDataAccess
{
	public CustomerDataAccess(string connectionString)
	{
		// ToDo
	}
	
	public IEnumerable<Customer> GetCustomers()
	{
		// TODO 
	}
}

```
