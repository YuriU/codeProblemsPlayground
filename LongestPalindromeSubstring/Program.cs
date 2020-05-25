using System;
using LongestPalindromeSubstring.Utils;

namespace LongestPalindromeSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxVal = int.MaxValue;
            var minVal = int.MinValue;
            
            Func<string, string> implemetation = Manachers_Algorithm.LongestPalindrome;

            TestImplementation(implemetation);
        }

        private static void TestImplementation(Func<string, string> implemetation)
        {
            implemetation("b").ShouldBe("b");
            implemetation("bb").ShouldBe("bb");
            implemetation("dbaba").ShouldBe("bab");
        }
    }
}
