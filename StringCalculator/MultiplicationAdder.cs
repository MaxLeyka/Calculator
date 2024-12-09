using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class MultiplicationAdder
    {
        public string AddMultiplicationSign(string expression)
        {
            expression = Regex.Replace(expression, @"(\d)(\()", "$1*$2");

            expression = Regex.Replace(expression, @"\)(\d)", ")*$1");

            return expression;
        }
    }
}