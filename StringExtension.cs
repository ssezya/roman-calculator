using System;

namespace RomanCalculator
{
    public static class StringExtension
    {
        public static String ReplaceFirst(this String value, String oldValue, String newValue)
        {
            Int32 startIndex = value.IndexOf(oldValue);
            if (startIndex == -1)
                return value;

            return value.Remove(startIndex, oldValue.Length).Insert(startIndex, newValue);
        }
    }
}
