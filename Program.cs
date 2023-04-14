using System;

namespace RomanCalculator
{
    class Program
    {
        static void Main()
        {
            Calculator calculator = new Calculator();
            String romanExpression = "(III + V - IV) * III";
            String result = calculator.Evaluate(romanExpression);

            Console.WriteLine(result);
            return;
        }
    }
}
