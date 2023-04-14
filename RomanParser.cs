using System;
using System.Linq;
using System.Collections.Generic;

namespace RomanCalculator
{
    public class RomanParser
    {
        private readonly Dictionary<Char, Int32> RomanInt32Map = new Dictionary<Char, Int32>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        private readonly String[] RomanLetters = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        private readonly Int32[] RomanLettersNumbers = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

        public Int32 RomanToInt32(String romanNumber)
        {
            Int32 number = 0;
            for (Int32 index = 0; index < romanNumber.Length; index++)
            {
                if (index + 1 < romanNumber.Length && RomanInt32Map[romanNumber[index]] < RomanInt32Map[romanNumber[index + 1]])
                    number -= RomanInt32Map[romanNumber[index]];
                else
                    number += RomanInt32Map[romanNumber[index]];
            }

            return number;
        }

        public String Int32ToRoman(Int32 number)
        {
            String result = String.Empty;
            Int32 index = 0;
            while (number != 0)
            {
                if (number >= RomanLettersNumbers[index])
                {
                    number -= RomanLettersNumbers[index];
                    result += RomanLetters[index];
                } else
                    index++;
            }

            return result;
        }

        public String RomanExpressionToInt32Expression(String romanExpression)
        {
            Char[] delimiters = new Char[] { '(', ')', '+', '-', '*' };
            String[] romanNumbers = romanExpression.Split(delimiters);

            String trimmedNumber = String.Empty;
            String romanToInt32String = String.Empty;
            String result = romanExpression;
            RomanParser parser = new RomanParser();
            foreach (String number in romanNumbers.Where(number => !String.IsNullOrWhiteSpace(number)))
            {
                trimmedNumber = String.Concat(number.Where(letter => !Char.IsWhiteSpace(letter)));
                romanToInt32String = parser.RomanToInt32(trimmedNumber).ToString();
                result = result.ReplaceFirst(trimmedNumber, romanToInt32String);
            }

            return result;
        }
    }
}
