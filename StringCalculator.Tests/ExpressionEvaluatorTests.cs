using Xunit;

namespace StringCalculator.Tests
{
    public class ExpressionEvaluatorTests
    {
        private readonly ExpressionEvaluator _expressionEvaluator = new ExpressionEvaluator();

        [Fact]
        public void Test_Evaluate_Addition()
        {
            var expression = "2 + 2";
            var result = _expressionEvaluator.Evaluate(expression);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Test_Evaluate_Subtraction()
        {
            var expression = "5 - 3";
            var result = _expressionEvaluator.Evaluate(expression);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test_Evaluate_Multiplication()
        {
            var expression = "3 * 4";
            var result = _expressionEvaluator.Evaluate(expression);
            Assert.Equal(12, result);
        }

        [Fact]
        public void Test_Evaluate_Division()
        {
            var expression = "10 / 2";
            var result = _expressionEvaluator.Evaluate(expression);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Test_Evaluate_CombinedOperations()
        {
            var expression = "2 + 3 * 4";
            var result = _expressionEvaluator.Evaluate(expression);
            Assert.Equal(14, result);
        }

        [Fact]
        public void Test_Evaluate_Parentheses()
        {
            var expression = "(2 + 3) * 4";
            var result = _expressionEvaluator.Evaluate(expression);
            Assert.Equal(20, result);
        }

        [Fact]
        public void Test_Evaluate_MixedOperations()
        {
            var expression = "(2 + 3) * (4 - 1)";
            var result = _expressionEvaluator.Evaluate(expression);
            Assert.Equal(15, result);
        }
    }
}
