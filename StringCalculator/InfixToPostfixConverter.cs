using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class InfixToPostfixConverter
    {
        public Queue<string> Convert(string expression)
        {
            var output = new Queue<string>();
            var operators = new Stack<string>();

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (char.IsDigit(c) || c == '.')
                {
                    output.Enqueue(ReadNumber(expression, ref i));
                }
                else if (c == '(')
                {
                    operators.Push("(");
                }
                else if (c == ')')
                {
                    while (operators.Peek() != "(")
                        output.Enqueue(operators.Pop());
                    operators.Pop(); // Удаляем '('
                }
                else if (IsOperator(c))
                {
                    if (IsUnaryMinus(expression, i))
                        operators.Push("u-");
                    else
                        ProcessOperator(c.ToString(), operators, output);
                }
            }

            while (operators.Count > 0)
                output.Enqueue(operators.Pop());

            return output;
        }

        private void ProcessOperator(string op, Stack<string> operators, Queue<string> output)
        {
            while (operators.Count > 0 && operators.Peek() != "(" && Precedence(op) <= Precedence(operators.Peek()))
                output.Enqueue(operators.Pop());
            operators.Push(op);
        }

        private string ReadNumber(string expression, ref int index)
        {
            int start = index;
            while (index < expression.Length && (char.IsDigit(expression[index]) || expression[index] == '.'))
                index++;
            index--; // Откат на последний символ числа
            return expression.Substring(start, index - start + 1);
        }

        private bool IsOperator(char c) => "+-*/".Contains(c);

        private int Precedence(string op) =>
            op switch
            {
                "+" or "-" => 1,
                "*" or "/" => 2,
                "u-" => 3,
                _ => throw new InvalidOperationException($"Неизвестный оператор: {op}")
            };

        private bool IsUnaryMinus(string expression, int index) =>
            expression[index] == '-' && (index == 0 || "()+-*/".Contains(expression[index - 1]));
    }
}
