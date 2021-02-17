using System;
using Xunit;
using Calculator.Logic;

namespace Calculator.Tests
{
    public class SubtractionTests
    {
        private readonly Operations _operation;

        public SubtractionTests()
        {
            _operation = new Operations();
        }

        [Theory]
        [InlineData(10, 6, 4)]
        [InlineData(9.6, 2.01, 7.59)]
        [InlineData(974357809, 53224560, 921133249)]
        [InlineData(0, 7, -7)]
        public void ShouldSubtractToGive(double a, double b, double expected)
        {
            double actual = _operation.SubtractNumbers(a, b);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 6, 16)]
        [InlineData(9.6, 2.11, 7.59)]
        [InlineData(974357809, 53234560, 921133249)]
        [InlineData(7, 8, 1)]
        public void ShouldNotSubtractToGive(double a, double b, double expected)
        {
            double actual = _operation.SubtractNumbers(a, b);

            Assert.NotEqual(expected, actual);
        }

        [Theory]
        [InlineData(9.74357809, 0.53224560, 9.2113325)]
        public void DifferenceGreaterThanSevenDecimalPlaces(double a, double b, double expected)
        {
            double actual = _operation.SubtractNumbers(a, b);

            Assert.Equal(expected, actual);
        }
    }
}
