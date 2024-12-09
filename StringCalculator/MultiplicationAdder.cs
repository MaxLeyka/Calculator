using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class MultiplicationAdder
    {
        public string AddMultiplicationSign(string expression)
        {
            return Regex.Replace(expression, @"(\d)(\()", "$1*$2")
                         .Replace(@")(\d)", ")*$1");
        }
    }
}
