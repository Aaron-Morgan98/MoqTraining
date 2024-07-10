using System.Collections.Generic;
using FluentAssertions.Equivalency;
using Moq;
using MoqKata.Main;
using MoqKata.Main.Interfaces;
using NuGet.Frameworks;
using Xunit;

namespace MoqKata.Tests;

public class UnitTest1
{
    private readonly SystemUnderTest _sut;

    public UnitTest1()
    {
        var testDependency1 = new Mock<IDependency1>();
        var testDependency2 = new Mock<IDependency2>();

        _sut = new SystemUnderTest(testDependency1.Object, testDependency2.Object);
    }

    [Fact]
    public void Method1_Returns_Input_As_String()
    {
        //TODO - #1 - Verify that when the 'Method1' is called with an int, that it returns the string representation of the input
        //arrange
        var input = 25;
        //act
        var result = _sut.Method1(input);
        //assert
        Assert.Equal("25", result);
    }

    [Fact]
    public void Method2_Returns_Property1_Of_Dependency1()
    {
        //TODO - #2 - Verify that the result of calling sut.Method2() returns the value of 'Property1' of the IDependency1
        
        var mockDependency1 = new Mock<IDependency1>();
        
        mockDependency1.Setup(d => d.Property1).Returns("test");

    }

    [Fact]
    public void Method3_Returns_Property2_Of_Dependency1()
    {
        //TODO - #3 - Verify that the result of calling sut.Method3() returns the value of 'Property2' of the IDependency1
        
        var mockDependency1 = new Mock<IDependency1>();
        var expectedResult = new List<string> { "test1", "test2" };

        mockDependency1.Setup(d => d.Property2).Returns(expectedResult);
    }

    [Fact]
    public void Method4_Returns_Result_of_Calling_Calculate_On_Dependency1()
    {
        //TODO - #4 - Verify that the result of calling sut.Method4(int, int) returns the result of calling 'Calculate()' of the IDependency1
        
        var mockDependency1 = new Mock<IDependency1>();

        mockDependency1.Setup(d => d.Calculate(1, 2)).Returns(3);
    }

    [Fact]
    public void Method4_Verify_Dependency1_Calculate_Is_Called_With_Correct_Parameters()
    {
        //TODO - #5 - Verify that Idependency1.Calculate(int,int) is invoked with the same values passed to sut.Method4
        
        
        //TODO: this may be wrong - check again
        var mockDependency1 = new Mock<IDependency1>();
        var dependencyResult = mockDependency1.Setup(d => d.Calculate(1, 2)).Returns(3);
        
        var inputA = 1;
        var inputB = 2;

        var methodResult = _sut.Method4(inputA, inputB);

        Assert.Equal(3, methodResult);
    }

    [Fact]
    public void Method5_Returns_Odd_When_Dependency1_Calculate_Returns_Even_Number()
    {
        //TODO - #6 - Verify that method5() returns 'Even' when IDependency1.Calculate returns an even number
        
        var inputA = 2;
        var inputB = 2;

        var result = _sut.Method5(inputA, inputB);

        Assert.Equal("Even", result);


    }

    [Fact]
    public void Method6_Returns_NestedProperty1_Of_Dependency2_Property1()
    {
        //TODO - #7 - Verify that method6() - Returns a string which is equal to IDependency2.Property1.NestedProperty1
        
        //TODO: FIX
        var mockDependency2 = new Mock<IDependency2>();
        //var mockDependency3 = new Mock<IDependency3>();

        mockDependency2.Setup(d => d.Property1.NestedProperty1).Returns("test");

        var result = _sut.Method6();
        
        Assert.Equal("test", result);


    }

    #region NestedDependencies

    [Fact]
    public void Method7_Returns_NestedProperty2_Of_Dependency2_Property1()
    {
        //TODO - #8 - Verify that method7() - Returns an IEnumerable<string> which is equal to IDependency2.Property1.NestedProperty2


    }

    [Fact]
    public void Method8_Returns_Result_of_Calling_NestedCalculate_On_Dependency2_Property1()
    {
        //TODO - #9 - Verify that the result of calling sut.Method8(int, int) returns the result of calling 'NestedCalculate()'
        //of the IDependency2.Property1


    }

    [Fact]
    public void Method8_Verify_Dependency2_Property1_NestedCalculate_Is_Called_With_Correct_Parameters()
    {
        //TODO - #10 - Verify that Idependency2.Property1.NestedCalculate(int,int) is invoked with the same values passed to sut.Method8()


    }

    [Fact]
    public void Method9_Returns_Even_When_Dependency2_Property1_NestedCalculate_Returns_Even_Number()
    {
        //TODO - #11 - Verify that method9() returns 'Even' when IDependency2.Property1.NestedCalculate returns an even number


    }

    [Fact]
    public void Method9_Returns_Odd_When_Dependency2_Property1_NestedCalculate_Returns_Odd_Number()
    {
        //TODO - #12 - Verify that method9() returns 'Even' when IDependency2.Property1.NestedCalculate returns an even number


    }

    #endregion

    [Fact]
    public void Method10_Calls_Dependency1_SendMessage_With_Correct_Parameters()
    {
        //TODO - #13 - Verify that method10() invokes the SendMessage method of IDependency1
        //with an ID equal to the MessageId of the input parameter


    }

    [Fact]
    public void Method10_Calls_Dependency1_SendMessage_With_New_Guid_Each_Time()
    {
        //TODO - #14 - Verify that method10() invokes the SendMessage method of IDependency1
        //and uses a different guid as the 'MyGuid' property of the message every time


    }
}