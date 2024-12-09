using Xunit;

namespace StringCalculator.Tests
{
    public class MultiplicationAdderTests
    {
        private readonly MultiplicationAdder _multiplicationAdder = new MultiplicationAdder();

        [Fact]
        public void Test_AddMultiplicationSign_BetweenNumberAndOpeningParenthesis()
        {
            var expression = "2(3+5)";
            var result = _multiplicationAdder.AddMultiplicationSign(expression);
            Assert.Equal("2*(3+5)", result);
        }

        [Fact]
        public void Test_AddMultiplicationSign_BetweenClosingParenthesisAndNumber()
        {
            var expression = "(3+5)4";
            var result = _multiplicationAdder.AddMultiplicationSign(expression);
            Assert.Equal("(3+5)*4", result);
        }

        [Fact]
        public void Test_AddMultiplicationSign_WithMultipleOccurrences()
        {
            var expression = "2(3+5)4";
            var result = _multiplicationAdder.AddMultiplicationSign(expression);
            Assert.Equal("2*(3+5)*4", result);
        }

        [Fact]
        public void Test_AddMultiplicationSign_WithoutModification()
        {
            var expression = "2+3*(4-1)";
            var result = _multiplicationAdder.AddMultiplicationSign(expression);
            Assert.Equal("2+3*(4-1)", result);
        }

        [Fact]
        public void Test_AddMultiplicationSign_WithEmptyExpression()
        {
            var expression = "";
            var result = _multiplicationAdder.AddMultiplicationSign(expression);
            Assert.Equal("", result);
        }

        [Fact]
        public void Test_AddMultiplicationSign_WithSingleNumber()
        {
            var expression = "42";
            var result = _multiplicationAdder.AddMultiplicationSign(expression);
            Assert.Equal("42", result);
        }
    }
}
