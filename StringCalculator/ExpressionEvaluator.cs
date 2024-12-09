using System;

namespace StringCalculator
{
    public class ExpressionEvaluator
    {
        private readonly InfixToPostfixConverter _converter = new InfixToPostfixConverter();
        private readonly PostfixEvaluator _evaluator = new PostfixEvaluator();

        public double Evaluate(string expression)
        {
            var postfix = _converter.Convert(expression);
            return _evaluator.Evaluate(postfix);
        }
    }
}

