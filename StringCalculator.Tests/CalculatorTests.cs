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

        [Fact]
        public void Test_Calculate_ValidExpression_With_Parentheses()
        {
            var expression = "2 * (3 + 4)";
            var result = Calculator.Calculate(expression);
            Assert.Equal(14, result);
        }

        [Fact]
        public void Test_Calculate_ValidExpression_Complex()
        {
            var expression = "2 + 3 * (4 - 1)";
            var result = Calculator.Calculate(expression);
            Assert.Equal(11, result);
        }

        [Fact]
        public void Test_Calculate_ValidExpression_Division()
        {
            var expression = "10 / 2";
            var result = Calculator.Calculate(expression);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Test_Calculate_ValidExpression_NegativeNumbers()
        {
            var expression = "-2 + 3 * (-4 - 1)";
            var result = Calculator.Calculate(expression);
            Assert.Equal(-17, result);
        }

        [Fact]
        public void Test_Calculate_InvalidExpression_TwoPlusSigns()
        {
            var expression = "2 + + 2";
            Assert.Throws<FormatException>(() => Calculator.Calculate(expression));
        }

        [Fact]
        public void Test_Calculate_InvalidExpression_With_Characters()
        {
            var expression = "2 + a";
            Assert.Throws<FormatException>(() => Calculator.Calculate(expression));
        }

        [Fact]
        public void Test_Calculate_EmptyExpression()
        {
            var expression = "";
            Assert.Throws<FormatException>(() => Calculator.Calculate(expression));
        }

        [Fact]
        public void Test_Calculate_ValidExpression_WithMultipleOperators()
        {
            var expression = "2 + 3 * (4 - 1)";
            var result = Calculator.Calculate(expression);
            Assert.Equal(11, result);
        }

        [Fact]
        public void Test_Calculate_InvalidExpression_DivideByZero()
        {
            var expression = "10 / 0";
            Assert.Throws<FormatException>(() => Calculator.Calculate(expression));
        }

        [Fact]
        public void Test_Calculate_ValidExpression_WithNestedParentheses()
        {
            var expression = "((2 + 3) * (4 + 5))";
            var result = Calculator.Calculate(expression);
            Assert.Equal(45, result);
        }

        [Fact]
        public void Test_Calculate_InvalidExpression_UnmatchedParentheses()
        {
            var expression = "(3 + 5";
            Assert.Throws<FormatException>(() => Calculator.Calculate(expression));
        }
    }
}
