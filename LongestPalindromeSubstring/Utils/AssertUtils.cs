using System;

namespace LongestPalindromeSubstring.Utils
{
    public static class AssertUtils
    {
        public static string ShouldBe(this string val, string expected)
        {
            if (val != expected)
            {
                throw new Exception($"{val} != {expected}");
            }
            else
            {
                Console.WriteLine("OK");
            }

            return val;
        }
    }
}