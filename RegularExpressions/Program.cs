using System;

namespace RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var isMatch = solution.IsMatch("mississipi", "mis*is*p*.");
            Console.WriteLine(isMatch);

            var isMatch2 = solution.IsMatch("mississipi", "mis*is*ip*.");
            Console.WriteLine(isMatch2);
        }
    }
}
