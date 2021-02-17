using System;
using Xunit;
using Calculator.Logic;

namespace Calculator.Tests
{
    public class MultiplicationTests
    {
        private readonly Operations _operation;

        public MultiplicationTests()
        {
            _operation = new Operations();
        }

        [Theory]
        [InlineData(11, 12, 132)]
        [InlineData(0.5, 12, 6)]
        [InlineData(4565334, 9054327, 41336026900218)]
        [InlineData(100, 0, 0)]
        public void ShouldMultiplyToGive(double a, double b, double expected)
        {
            double actual = _operation.MultiplyNumbers(a, b);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(11, 12, 1212)]
        [InlineData(1.5, 12, 62)]
        [InlineData(4565334, 9054327, 41336023200218)]
        [InlineData(3, 0, 3)]
        public void ShouldNotMultiplyToGive(double a, double b, double expected)
        {
            double actual = _operation.MultiplyNumbers(a, b);

            Assert.NotEqual(expected, actual);
        }

        [Theory]
        [InlineData(9.3809, 4.5614, 42.7900373)]
        public void ProductGreaterThanSevenDecimalPlaces(double a, double b, double expected)
        {
            double actual = _operation.MultiplyNumbers(a, b);

            Assert.Equal(expected, actual);
        }
    }
}
