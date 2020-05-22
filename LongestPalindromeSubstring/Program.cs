using System;
using LongestPalindromeSubstring.Utils;

namespace LongestPalindromeSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string> implemetation = MyNaiveWithSubstitutionChars.LongestPalindrome;

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
