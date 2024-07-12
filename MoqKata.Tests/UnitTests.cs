using System;
using System.Collections.Generic;
using Moq;
using MoqKata.Main;
using MoqKata.Main.Interfaces;
using MoqKata.Main.Models;
using Xunit;

namespace MoqKata.Tests
{
    public class UnitTest1
    {
        private readonly SystemUnderTest _sut;
        private readonly Mock<IDependency1> _testDependency1;
        private readonly Mock<IDependency2> _testDependency2;
        private readonly Mock<IDependency3> _testDependency3;

        public UnitTest1()
        {
            // Initialize mocks for dependencies
            _testDependency1 = new Mock<IDependency1>();
            _testDependency2 = new Mock<IDependency2>();
            _testDependency3 = new Mock<IDependency3>();

            // Create an instance of the SystemUnderTest, injecting mocks
            _sut = new SystemUnderTest(_testDependency1.Object, _testDependency2.Object);
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

            string expectedPropertyValue = "TestValue";
            _testDependency1.Setup(d => d.Property1).Returns(expectedPropertyValue);

            var result = _sut.Method2();

            // verify that the result matches the expected Property1 value
            Assert.Equal(expectedPropertyValue, result);
        }

        [Fact]
        public void Method3_Returns_Property2_Of_Dependency1()
        {
            //TODO - #3 - Verify that the result of calling sut.Method3() returns the value of 'Property2' of the IDependency1

            var expectedPropertyValue = new List<string> { "Value1", "Value2", "Value3" };
            _testDependency1.Setup(d => d.Property2).Returns(expectedPropertyValue);

            var result = _sut.Method3();
            Assert.Equal(expectedPropertyValue, result);
        }

        [Fact]
        public void Method4_Returns_Result_of_Calling_Calculate_On_Dependency1()
        {
            //TODO - #4 - Verify that the result of calling sut.Method4(int, int) returns the result of calling 'Calculate()' of the IDependency1

            int firstValue = 4;
            int secondValue = 6;
            int expectedCalculateResult = 10;
            _testDependency1.Setup(d => d.Calculate(firstValue, secondValue)).Returns(expectedCalculateResult);

            var result = _sut.Method4(firstValue, secondValue);
            Assert.Equal(expectedCalculateResult, result);
        }

        [Fact]
        public void Method4_Verify_Dependency1_Calculate_Is_Called_With_Correct_Parameters()
        {
            //TODO - #5 - Verify that Idependency1.Calculate(int,int) is invoked with the same values passed to sut.Method4

            int firstValue = 15;
            int secondValue = 10;


            _sut.Method4(firstValue, secondValue);
            _testDependency1.Verify(d => d.Calculate(firstValue, secondValue), Times.Once);
        }

        [Fact]
        public void Method5_Returns_Odd_When_Dependency1_Calculate_Returns_Even_Number()
        {
            //TODO - #6 - Verify that method5() returns 'Even' when IDependency1.Calculate returns an even number

            int firstValue = 10;
            int secondValue = 10;
            int evenValue = 20;
            _testDependency1.Setup(d => d.Calculate(firstValue, secondValue)).Returns(evenValue);

            var result = _sut.Method5(firstValue, secondValue);
            Assert.Equal("Even", result);
        }

        [Fact]
        public void Method6_Returns_NestedProperty1_Of_Dependency2_Property1()
        {
            //TODO - #7 - Verify that method6() - Returns a string which is equal to IDependency2.Property1.NestedProperty1

            string expectedNestedPropertyValue = "NestedValue";
            _testDependency2.Setup(d => d.Property1.NestedProperty1).Returns(expectedNestedPropertyValue);


            var result = _sut.Method6();
            Assert.Equal(expectedNestedPropertyValue, result);
        }

        #region NestedDependencies

        [Fact]
        public void Method7_Returns_NestedProperty2_Of_Dependency2_Property1()
        {
            //TODO - #8 - Verify that method7() - Returns an IEnumerable<string> which is equal to IDependency2.Property1.NestedProperty2
            _testDependency2.Setup(d => d.Property1.NestedProperty2)
                .Returns(new List<string> { "Value 1", "Value 2" });

            var result = _sut.Method7();
            Assert.Equal(new List<string>{"Value 1", "Value 2"}, result);

        }

        [Fact]
        public void Method8_Returns_Result_of_Calling_NestedCalculate_On_Dependency2_Property1()
        {
            //TODO - #9 - Verify that the result of calling sut.Method8(int, int) returns the result of calling 'NestedCalculate()'
            //of the IDependency2.Property1
            int firstValue = 3;
            int secondValue = 3;
            int expectedValue = 6;

            _testDependency2.Setup(d => d.Property1.NestedCalculate(firstValue, secondValue)).Returns(expectedValue);

            var result = _sut.Method8(firstValue,secondValue);
            Assert.Equal(6,result);
            
        }

        [Fact]
        public void Method8_Verify_Dependency2_Property1_NestedCalculate_Is_Called_With_Correct_Parameters()
        {
            //TODO - #10 - Verify that Idependency2.Property1.NestedCalculate(int,int) is invoked with the same values passed to sut.Method8()
            int firstValue = 10;
            int secondValue = 10;
            
            _testDependency2.Setup(d => d.Property1).Returns(_testDependency3.Object);

            _sut.Method8(firstValue, secondValue);
            _testDependency2.Verify(d => d.Property1.NestedCalculate(firstValue,secondValue),Times.Once);
        }

        [Fact]
        public void Method9_Returns_Even_When_Dependency2_Property1_NestedCalculate_Returns_Even_Number()
        {
            //TODO - #11 - Verify that method9() returns 'Even' when IDependency2.Property1.NestedCalculate returns an even number
            int firstValue = 2;
            int secondValue = 4;
            int evenValue = 6;

            _testDependency2.Setup(d => d.Property1.NestedCalculate(firstValue, secondValue)).Returns(evenValue);

            var result = _sut.Method9(firstValue, secondValue);
            Assert.Equal("Even", result);
        }
        [Fact]
        public void Method9_Returns_Odd_When_Dependency2_Property1_NestedCalculate_Returns_Odd_Number()
        {
            //TODO - #12 - Verify that method9() returns 'Even' when IDependency2.Property1.NestedCalculate returns an even number
            int firstValue = 3;
            int secondValue = 4;
            int evenValue = 7;

            _testDependency2.Setup(d => d.Property1.NestedCalculate(firstValue, secondValue)).Returns(evenValue);

            var result = _sut.Method9(firstValue, secondValue);
            Assert.Equal("Odd", result);

        }

        #endregion

        [Fact]
        public void Method10_Calls_Dependency1_SendMessage_With_Correct_Parameters()
        {
            //TODO - #13 - Verify that method10() invokes the SendMessage method of IDependency1
            //with an ID equal to the MessageId of the input parameter

            //set up a mock for IPoco1 and define the expected MessageId
            var mockPoco = new Mock<IPoco1>();
            string expectedMessageId = "1";
            mockPoco.Setup(p => p.MessageId).Returns(expectedMessageId);


            _sut.Method10(mockPoco.Object);

            //check that SendMessage was called with a Message object where the Id matches the expected MessageId
            _testDependency1.Verify(d => d.SendMessage(It.Is<Message>(msg => msg.Id == expectedMessageId)), Times.Once);
        }

        [Fact]
        public void Method10_Calls_Dependency1_SendMessage_With_New_Guid_Each_Time()
        {
            //TODO - #14 - Verify that method10() invokes the SendMessage method of IDependency1
            //and uses a different guid as the 'MyGuid' property of the message every time

            var mockPoco = new Mock<IPoco1>();
            string messageId = "2";
            mockPoco.Setup(p => p.MessageId).Returns(messageId);

            //create a HashSet to store guids and set up the mock to capture guids
            var guids = new HashSet<Guid>();
            _testDependency1.Setup(d => d.SendMessage(It.IsAny<Message>()))
                .Callback<Message>(msg => guids.Add(msg.MyGuid));

            // call method multiple times to fulfil test conditions
            _sut.Method10(mockPoco.Object);
            _sut.Method10(mockPoco.Object);

            // check that our hashset is > 1 so we know that a different guid is used each time
            Assert.True(guids.Count > 1);
        }
    }
}
