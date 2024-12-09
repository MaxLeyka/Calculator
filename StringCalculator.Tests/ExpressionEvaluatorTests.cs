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
    }
}
