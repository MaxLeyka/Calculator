namespace StringCalculator
{
    public static class Calculator
    {
        private static readonly MultiplicationAdder _multiplicationAdder = new MultiplicationAdder();
        private static readonly ExpressionValidator _expressionValidator = new ExpressionValidator();
        private static readonly ExpressionEvaluator _expressionEvaluator = new ExpressionEvaluator();

        public static double Calculate(string expression)
        {
            string cleanedExpression = expression.Replace(" ", "");

            cleanedExpression = _multiplicationAdder.AddMultiplicationSign(cleanedExpression);

            _expressionValidator.Validate(cleanedExpression);

            return _expressionEvaluator.Evaluate(cleanedExpression);
        }
    }
}
