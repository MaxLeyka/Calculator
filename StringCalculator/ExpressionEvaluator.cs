using System;
using System.Data;

namespace StringCalculator
{
    public class ExpressionEvaluator
    {
        public double Evaluate(string expression)
        {
            var dataTable = new DataTable();
            try
            {
                return Convert.ToDouble(dataTable.Compute(expression, string.Empty));
            }
            catch (Exception ex)
            {
                throw new FormatException("Недопустимое выражение", ex);
            }
        }
    }
}
