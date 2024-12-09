using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class ExpressionEvaluator
    {
        public double Evaluate(string expression)
        {
            var postfix = ConvertToPostfix(expression);
            return CalculatePostfix(postfix);
        }
        private Queue<string> ConvertToPostfix(string expression)
        {
            var output = new Queue<string>();
            var operators = new Stack<string>();

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (char.IsDigit(c) || c == '.')
                {
                    string number = ReadNumber(expression, ref i);
                    output.Enqueue(number);
                }
                else if (c == '(')
                {
                    operators.Push(c.ToString());
                }
                else if (c == ')')
                {
                    while (operators.Count > 0 && operators.Peek() != "(")
                    {
                        output.Enqueue(operators.Pop());
                    }
                    operators.Pop();
                }
                else if (IsOperator(c))
                {
                    if (c == '-' && (i == 0 || expression[i - 1] == '(' || IsOperator(expression[i - 1])))
                    {
                        operators.Push("u-");
                    }
                    else
                    {
                        while (operators.Count > 0 && operators.Peek() != "(" && Precedence(c.ToString()) <= Precedence(operators.Peek()))
                        {
                            output.Enqueue(operators.Pop());
                        }
                        operators.Push(c.ToString());
                    }
                }
            }

            while (operators.Count > 0)
            {
                output.Enqueue(operators.Pop());
            }

            return output;
        }

        private double CalculatePostfix(Queue<string> postfix)
        {
            var stack = new Stack<double>();

            while (postfix.Count > 0)
            {
                string token = postfix.Dequeue();

                if (double.TryParse(token, out double number))
                {
                    stack.Push(number);
                }
                else if (token == "u-")
                {
                    double a = stack.Pop();
                    stack.Push(-a);
                }
                else if (IsOperator(token[0]))
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    stack.Push(ApplyOperator(token[0], a, b));
                }
            }

            return stack.Pop();
        }

        private string ReadNumber(string expression, ref int index)
        {
            int start = index;

            while (index < expression.Length && (char.IsDigit(expression[index]) || expression[index] == '.'))
            {
                index++;
            }

            index--;
            return expression.Substring(start, index - start + 1);
        }

        private bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        private int Precedence(string op)
        {
            return op switch
            {
                "+" => 1,
                "-" => 1,
                "*" => 2,
                "/" => 2,
                "u-" => 3,
                _ => throw new InvalidOperationException($"Неизвестный оператор: {op}")
            };
        }

        private double ApplyOperator(char op, double a, double b)
        {
            return op switch
            {
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,
                '/' => a / b,
                _ => throw new InvalidOperationException($"Недопустимая операция: {op}")
            };
        }
    }
}
