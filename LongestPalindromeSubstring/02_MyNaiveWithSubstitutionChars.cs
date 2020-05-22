using System.Linq;

namespace LongestPalindromeSubstring
{
    public class MyNaiveWithSubstitutionChars
    {
        public static string LongestPalindrome(string s)
        {
            var stringWithSubstitutors = string.Join('$', s.ToCharArray());
            stringWithSubstitutors = $"${stringWithSubstitutors}$";

            string longestPalindrome = string.Empty;
            for (int i = 0; i < stringWithSubstitutors.Length; i++)
            {
                var paindrome = GetPalindrome(stringWithSubstitutors, i - 1, i + 1);
                if ((paindrome.Length > longestPalindrome.Length && paindrome.StartsWith(""))
                    || (paindrome.Length != longestPalindrome.Length && longestPalindrome.StartsWith("$") && !paindrome.StartsWith("$")))
                {
                    longestPalindrome = paindrome;
                }
            }

            return longestPalindrome.Replace("$", null);
        }
        
        private static string GetPalindrome(string s, int prev, int next){      
            while(prev >= 0 
                  && next < s.Length
                  && s[prev] == s[next])
            {
                prev--;
                next++;
            }
        
            int from = prev + 1;
            int to = next - 1;

            return s.Substring(from, to - from + 1);
        }
    }
}