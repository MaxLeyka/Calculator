using System;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class ExpressionValidator
    {
        public void Validate(string expression)
        {
            if (expression.Contains("/0"))
            {
                throw new FormatException("Деление на ноль невозможно.");
            }

            if (expression == "()")
            {
                throw new FormatException("Выражение не может содержать пустые скобки.");
            }
            if (!Regex.IsMatch(expression, @"^[0-9\+\-\*/\(\)\.]+$"))
            {
                throw new FormatException("Выражение содержит недопустимые символы.");
            }

            int openParenthesesCount = 0;
            foreach (char c in expression)
            {
                if (c == '(') openParenthesesCount++;
                if (c == ')') openParenthesesCount--;
                if (openParenthesesCount < 0)
                {
                    throw new FormatException("Закрывающая скобка появляется без соответствующей открывающей.");
                }
            }

            if (openParenthesesCount != 0)
            {
                throw new FormatException("Несовпадающие круглые скобки.");
            }

            if (Regex.IsMatch(expression, @"[\+\-\*/]{2,}"))
            {
                throw new FormatException("Выражение содержит последовательные операторы.");
            }
            if (Regex.IsMatch(expression, @"^[\+\*/]"))
            {
                throw new FormatException("Выражение не может начинаться с оператора * , / или +.");
            }
            if (Regex.IsMatch(expression, @"\([\/\*\+](?=\d)"))
            {
                throw new FormatException("Выражение не может содержать операторы перед числом внутри скобок.");
            }
            if (expression.StartsWith(")"))
            {
                throw new FormatException("Выражение не может начинаться с закрывающей скобки.");
            }
            if (Regex.IsMatch(expression, @"\)\d|\d\("))
            {
                throw new FormatException("Выражение не может содержать скобки в неверной последовательности, например ')1' или '2('.");
            }
            if (Regex.IsMatch(expression, @"[\+\-\*/]\)"))
            {
                throw new FormatException("Выражение не может содержать оператор перед закрывающей скобкой.");
            }
            if (Regex.IsMatch(expression, @"\(\)"))
            {
                throw new FormatException("Выражение не может содержать пустые скобки.");
            }
        }
    }
}
