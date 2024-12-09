using System;
using Xunit;

namespace StringCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Test_Calculate_ValidExpression_Addition()
        {
            var expression = "2 + 2";
            var result = Calculator.Calculate(expression);
            Assert.Equal(4, result);
        }
    }
}
