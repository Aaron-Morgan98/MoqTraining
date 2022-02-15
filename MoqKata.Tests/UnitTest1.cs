using Xunit;

namespace MoqKata.Tests;

public class UnitTest1
{

    [Fact]
    public void Method1_Returns_Input_As_String()
    {
        //TODO - #1 - Verify that when the 'Method1' is called with an int, that it returns the string representation of the input
    }

    [Fact]
    public void Method2_Returns_Property1_Of_Dependency1()
    {
        //TODO - #2 - Verify that the result of calling sut.Method2() returns the value of 'Property1' of the IDependency1


    }

    [Fact]
    public void Method3_Returns_Property2_Of_Dependency1()
    {
        //TODO - #3 - Verify that the result of calling sut.Method3() returns the value of 'Property2' of the IDependency1


    }

    [Fact]
    public void Method4_Returns_Result_of_Calling_Calculate_On_Dependency1()
    {
        //TODO - #4 - Verify that the result of calling sut.Method4(int, int) returns the result of calling 'Calculate()' of the IDependency1


    }

    [Fact]
    public void Method4_Verify_Dependency1_Calculate_Is_Called_With_Correct_Parameters()
    {
        //TODO - #5 - Verify that Idependency1.Calculate(int,int) is invoked with the same values passed to sut.Method4


    }

    [Fact]
    public void Method5_Returns_Odd_When_Dependency1_Calculate_Returns_Even_Number()
    {
        //TODO - #6 - Verify that method5() returns 'Even' when IDependency1.Calculate returns an even number


    }

    [Fact]
    public void Method6_Returns_NestedProperty1_Of_Dependency2_Property1()
    {
        //TODO - #7 - Verify that method6() - Returns a string which is equal to IDependency2.Property1.NestedProperty1


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