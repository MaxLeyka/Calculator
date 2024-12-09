using Xunit;
using StringCalculator;
using System;

namespace StringCalculator.Tests
{
    public class ExpressionValidatorTests
    {
        private readonly ExpressionValidator _expressionValidator = new ExpressionValidator();

        [Fact]
        public void Test_InvalidExpression_WithInvalidCharacters()
        {
            var expression = "2+3*a";
            Assert.Throws<FormatException>(() => _expressionValidator.Validate(expression));
        }

        [Fact]
        public void Test_InvalidExpression_WithUnmatchedParentheses()
        {
            var expression = "(2+3*(4-1)";
            Assert.Throws<FormatException>(() => _expressionValidator.Validate(expression));
        }

        [Fact]
        public void Test_InvalidExpression_WithConsecutiveOperators()
        {
            var expression = "2++2";
            Assert.Throws<FormatException>(() => _expressionValidator.Validate(expression));
        }

        [Fact]
        public void Test_ValidExpression_WithAllowedCharacters()
        {
            var expression = "2+3*(4-1)";
            _expressionValidator.Validate(expression);
        }

        [Fact]
        public void Test_ValidExpression_WithDecimalPoints()
        {
            var expression = "3.5+2.1*(4.2-1)";
            _expressionValidator.Validate(expression);
        }

        [Fact]
        public void Test_InvalidExpression_WithExtraOperators()
        {
            var expression = "2*-*3";
            Assert.Throws<FormatException>(() => _expressionValidator.Validate(expression));
        }

        [Fact]
        public void Test_InvalidExpression_WithConsecutiveMinusOperators()
        {
            var expression = "2--3";
            Assert.Throws<FormatException>(() => _expressionValidator.Validate(expression));
        }

        [Fact]
        public void Test_ValidExpression_WithValidParentheses()
        {
            var expression = "(2+3)*(4-1)";
            _expressionValidator.Validate(expression);
        }
        [Fact]
        public void Test_InvalidExpression_WithEmptyExpression()
        {
            var expression = "()";
            Assert.Throws<FormatException>(() => _expressionValidator.Validate(expression));
        }
    }
}
