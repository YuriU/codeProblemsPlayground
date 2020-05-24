using System;

namespace LongestPalindromeSubstring
{
    public class UsingCountersArray
    {
        public static string LongestPalindrome(string s)
        {
            var stringWithSubstitutors = string.Join('$', s.ToCharArray());
            stringWithSubstitutors = $"${stringWithSubstitutors}$";

            int maxLength = 0;
            int maxPalindromeIndex = -1;
            for (int i = 0; i < stringWithSubstitutors.Length; i++)
            {
                var length = GetPalindromeLength(stringWithSubstitutors, i);
                if (length > maxLength)
                {
                    maxPalindromeIndex = i;
                    maxLength = length;
                }
            }

            // Palindrome is always odd sized
            var startIndex = maxPalindromeIndex - (maxLength / 2);
            var resultWithSubstitutors = stringWithSubstitutors.Substring(startIndex, maxLength);
            
            return resultWithSubstitutors.Replace("$", null);
        }
        
        private static int GetPalindromeLength(string s, int centerIndex)
        {
            int prev = centerIndex - 1;
            int next = centerIndex + 1;

            int length = 1;
            while(prev >= 0 
                  && next < s.Length
                  && s[prev] == s[next])
            {
                prev--;
                next++;
                
                length += 2;
            }

            return length;
        }
    }
}