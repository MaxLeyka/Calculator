using System;
using Xunit;

namespace StringCalculator.Tests
{
    public class ExpressionValidatorTests
    {
        private readonly ExpressionValidator _expressionValidator = new ExpressionValidator();

        [Fact]
        public void Test_ValidExpression()
        {
            var expression = "2+3*(4-1)";
            _expressionValidator.Validate(expression);
        }

        [Fact]
        public void Test_InvalidExpression()
        {
            var expression = "2++2";
            Assert.Throws<FormatException>(() => _expressionValidator.Validate(expression));
        }
    }
}
