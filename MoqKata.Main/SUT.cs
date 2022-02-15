namespace MoqKata.Main;

using Interfaces;
using Models;

public class SystemUnderTest
{

	private readonly IDependency1 _dependency1;
	private readonly IDependency2 _dependency2;

	public SystemUnderTest(IDependency1 dep1, IDependency2 dep2)
	{
		_dependency1 = dep1;
		_dependency2 = dep2;
	}

	/// <summary>
	/// No reliance on any dependency
	/// </summary>
	public string Method1(int i)
	{
		return i.ToString();
	}

	/// <summary>
	/// Returns the Property1 value of the IDependency1
	/// </summary>
	public string Method2()
    {
        return _dependency1.Property1;
    }

	/// <summary>
	/// Returns the Property2 value of the IDependency1 : IEnumerable<string>
	/// </summary>
	public IEnumerable<string> Method3()
    {
        return _dependency1.Property2;
    }

	/// <summary>
	/// Returns the result of calling calculate on the IDependency1
	/// </summary>
	public int Method4(int a, int b)
	{
		return _dependency1.Calculate(a, b);
	}

    /// <summary>
	/// If the IDependency1.Calculate returns an even number, return 'EVEN'
	/// If the IDependency1.Calculate returns an even number, return 'ODD'
	/// </summary>
	public string Method5(int a, int b)
	{
		var result = _dependency1.Calculate(a, b);

		if (result % 2 == 0)
		{
			return "Even";
		}

		return "Odd";
	}
	
	public string Method6()
	{
		return _dependency2.Property1.NestedProperty1;
	}

    /// <summary>
	/// Returns the Property2 value of the IDependency2 : IEnumerable<string>
	/// </summary>
	public IEnumerable<string> Method7()
	{
		return _dependency2.Property1.NestedProperty2;
	}

    /// <summary>
	/// Returns the result of calling calculate on the IDependency2.Property1
	/// </summary>
	public int Method8(int a, int b)
	{
		return _dependency2.Property1.NestedCalculate(a, b);
	}
	
	/// <summary>
	/// If the IDependency2.Property1.Calculate returns an even number, return 'EVEN'
	/// If the IDependency2.Property1.Calculate returns an even number, return 'ODD'
	/// </summary>
	public string Method9(int a, int b)
	{
		var result = _dependency2.Property1.NestedCalculate(a, b);

		if (result % 2 == 0)
		{
			return "Even";
		}

		return "Odd";
	}
	
	public void Method10(IPoco1 poco)
	{
		var newObject = new Message
		{
			Id = poco.MessageId,
			MyGuid = Guid.NewGuid()
		};

		_dependency1.SendMessage(newObject);
	}

}
