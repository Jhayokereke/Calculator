using System;
using Xunit;
using Calculator.Logic;

namespace Calculator.Tests
{
    public class DivisionTests
    {
        private readonly Operations _operation;

        public DivisionTests()
        {
            _operation = new Operations();
        }

        [Theory]
        [InlineData(126, 6, 21)]
        [InlineData(2.5, 1.25, 2)]
        [InlineData(41336026900218, 4565334, 9054327)]
        public void ShouldDivideToGive(double a, double b, double expected)
        {
            double actual = _operation.DivideNumbers(a, b);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(126, 16, 2)]
        [InlineData(25, 2.75, 4)]
        [InlineData(413360260218, 4565334, 905427)]
        public void ShouldNotDivideToGive(double a, double b, double expected)
        {
            double actual = _operation.DivideNumbers(a, b);

            Assert.NotEqual(expected, actual);
        }

        [Theory]
        [InlineData(6, 17, 0.3529412)]
        public void QuotientGreaterThanSevenDecimalPlaces(double a, double b, double expected)
        {
            double actual = _operation.DivideNumbers(a, b);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(53, 0)]
        [InlineData(-2, 0)]
        [InlineData(8.432, 0)]
        [InlineData(-0.003, 0)]
        public void WhenDividedByZero(double a, double b)
        {
            DivideByZeroException ex = Assert.Throws<DivideByZeroException>(() => _operation.DivideNumbers(a, b));

            Assert.Equal("Math Error!", ex.Message);
        }
    }
}
