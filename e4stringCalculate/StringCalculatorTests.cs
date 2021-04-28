using System;
using Xunit;

namespace e4stringCalculate
{
    public class StringCalutatorTests
    {
        //The method must accept a string of 0, 1 or 2 numbers
        //for example “” or “1” or “1,2” and will
        //return their sum(for an empty string it will return 0)
        [Fact]
        public void AnEmptyStringReturnsZero()
        {
           
            var expects = 0;
            Assert.Equal(expects, StringCalculator.Add(string.Empty));
        }
        [Fact]
        public void ASingleNumberReturnsSameNumber()
        {
           
            var expects = 1;
            Assert.Equal(expects, StringCalculator.Add("1"));
        }
        [Fact]
        public void TwoNumbersReturnsSumofBothNumbers()
        {
           
            var expects = 3;
            Assert.Equal(expects, StringCalculator.Add("1,2"));
        }
        //Allow the Add method to handle an unknown amount of numbers
        [Fact]
        public void UnknownAmountOfNumbersReturnsSumoFAllNumbers()
        {
         
            var expects = 11;
            Assert.Equal(expects, StringCalculator.Add("1,2,3,5"));
        }
        //Allow the Add method to handle new lines between numbers (instead of commas).
        [Fact]
        public void NewLinesBetweenNumbersReturnsSumOfAllNumbers()
        {
        
            var expects = 14;
            Assert.Equal(expects, StringCalculator.Add("1\n2,3\n8"));
        }
        //To change a delimiter, the beginning of the string will contain a separate line that looks like
        //this: “//[delimiter]\n[numbers...]” for example “//;\n1;2” should return three where the
        //default delimiter is ‘;’ .
        [Fact]
        public void ChangeOfDelimiterReturnsSumOfAllNumbers()
        {
            
            var expects = 6;
            Assert.Equal(expects, StringCalculator.Add("//;\n1,2,3"));
        }

        //Calling Add with a negative number will throw an exception “negatives not allowed”
        [Fact]
        public void CallingAddWithNegativeNumbersThrowsException()
        {
         
            Assert.Throws<ArgumentOutOfRangeException>(() => StringCalculator.Add("-1,2"));
        }
    }
}
