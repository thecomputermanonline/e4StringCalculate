using System;
using System.Linq;

namespace e4stringCalculate
{
    class StringCalculator
    {
        
        public static int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
                return 0;
            var delimiter = ",\n";
            var changeDelimiter = "//";

            if (numbers.StartsWith(changeDelimiter))
            {
                delimiter += numbers[2];
                numbers = numbers.Substring(4, numbers.Length - 4);
            }
            var items = numbers.Split(delimiter.ToCharArray());
            if (items.Any(x => string.IsNullOrEmpty(x)))
                throw new ArgumentException();
            var integers = items.Select(x => int.Parse(x));
            var negatives = integers.Where(x => x < 0);
            if (negatives.Count() > 0)
            {
                var message = "Negatives not allowed: {0}";
                throw new ArgumentOutOfRangeException(string.Format(message, negatives.Select(x => x.ToString())));
            }
            return items.Select(x => int.Parse(x)).Sum();
        }
    }
}
