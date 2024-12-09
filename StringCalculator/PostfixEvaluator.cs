using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class PostfixEvaluator
    {
        public double Evaluate(Queue<string> postfix)
        {
            var stack = new Stack<double>();

            while (postfix.Count > 0)
            {
                string token = postfix.Dequeue();
                if (double.TryParse(token, out double number))
                    stack.Push(number);
                else
                    ProcessOperator(token, stack);
            }

            return stack.Pop();
        }

        private void ProcessOperator(string token, Stack<double> stack)
        {
            if (token == "u-")
            {
                stack.Push(-stack.Pop());
            }
            else
            {
                double b = stack.Pop();
                double a = stack.Pop();
                stack.Push(ApplyOperator(token[0], a, b));
            }
        }

        private double ApplyOperator(char op, double a, double b) =>
            op switch
            {
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,
                '/' => a / b,
                _ => throw new InvalidOperationException($"Недопустимый оператор: {op}")
            };
    }
}
