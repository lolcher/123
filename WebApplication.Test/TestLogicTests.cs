using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WebApplication1.API.Logic;

namespace WebApplication.Test
{
    [TestFixture]
    public class TestLogicTests
    {
        [Test]
        public void GetProcessedValue_ValueProvided_ReturnsProcessed()
        {
            //Arrange
            var input = 10;
            var expected = 20;

            var dependencyMock = new Mock<ITestDependency>();
            dependencyMock.Setup(x => x.GetValue(input)).Returns(expected);

            var logic = new TestLogic(dependencyMock.Object);

            //Act
            var result = logic.GetProcessedValue(input);

            //Assert
            result.Should().Be(expected);
        }

        [TestCase(-1, ExpectedResult = -1)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        public int GetProcessedValue_DifferentValuesProvided_ReturnsProcessed(int value)
        {
            //Arrange
            var dependencyMock = new Mock<ITestDependency>();
            dependencyMock.Setup(x => x.GetValue(value)).Returns(value);

            var logic = new TestLogic(dependencyMock.Object);

            //Act
            var result = logic.GetProcessedValue(value);

            //Assert
            return result;
        }

        [Test]
        [Combinatorial]
        public void GetProcessedValue_Combinatorial_ReturnsProcessed([Values(0, 1, 2, 3)] int value1,
            [Values(4, 5)] int value2)
        {
            //Arrange
            var value = value1 * value2;

            var dependencyMock = new Mock<ITestDependency>();
            dependencyMock.Setup(x => x.GetValue(value)).Returns(value);

            var logic = new TestLogic(dependencyMock.Object);

            //Act
            var result = logic.GetProcessedValue(value);

            //Assert
            result.Should().Be(value);
        }
    }
}