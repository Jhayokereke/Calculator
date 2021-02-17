using System;
using Xunit;
using Calculator.Logic;

namespace Calculator.Tests
{
    public class ValueUpdateTests
    {
        private readonly Operations _operation;

        public ValueUpdateTests()
        {
            _operation = new Operations();
        }

        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(12, 5, 125)]
        [InlineData(0, 0, 0)]
        [InlineData(7865432, 2, 78654322)]
        public void OnIntegerValueIncrease(int a, int b, int expected)
        {
            int actual = _operation.UpdateInt(a, b);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2.43, 1, 3, 2.431)]
        [InlineData(0, 5, 1, 0.5)]
        [InlineData(0, 0, 1, 0.0)]
        [InlineData(7.865432, 2, 7, 7.8654322)]
        public void OnDecimalValueIncrease(double a, int b, int decimalposition, double expected)
        {
            double actual = _operation.UpdateDouble(a, b, decimalposition);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-32, 32)]
        [InlineData(125, -125)]
        public void OnIntegerValueNegation(int a, int expected)
        {
            int actual = _operation.NegateInt(a);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0.004, -0.004)]
        [InlineData(-2.34, 2.34)]
        [InlineData(78.65432, -78.65432)]
        public void OnDecimalValueNegation(int a, int expected)
        {
            double actual = _operation.NegateDouble(a);

            Assert.Equal(expected, actual);
        }
    }
}
