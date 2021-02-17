using System;
using Xunit;
using Calculator.Logic;

namespace Calculator.Tests
{
    public class AdditionTests
    {
        private readonly Operations _operation;
        public AdditionTests()
        {
            _operation = new Operations();
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(6.7, 0.9, 7.6)]
        [InlineData(5000000, 23456654, 28456654)]
        public void ShouldSumTo(double a, double b, double expected)
        {
            double actual = _operation.AddNumbers(a, b);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, 62, 123)]
        [InlineData(3.1, 0.9, 8.6)]
        [InlineData(5000000, 234654, 1006654)]
        public void ShouldNotSumTo(double a, double b, double expected)
        {
            double actual = _operation.AddNumbers(a, b);
            Assert.NotEqual(expected, actual);
        }

        [Theory]
        [InlineData(5.375432976, 2.3456654, 7.7210984)]
        public void SumGreaterThanSevenDecimalPlaces(double a, double b, double expected)
        {
            double actual = _operation.AddNumbers(a, b);
            Assert.Equal(expected, actual);
        }
    }
}
