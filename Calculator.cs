using System;
using System.Data;

namespace RomanCalculator
{
    public class Calculator
    {
        public String Evaluate(String expression)
        {
            RomanParser parser = new RomanParser();
            String int32ExpressionString = parser.RomanExpressionToInt32Expression(expression);

            DataTable dataTable = new DataTable();
            Int32 result = Convert.ToInt32(dataTable.Compute(int32ExpressionString, null));

            return parser.Int32ToRoman(result);
        }
    }
}
