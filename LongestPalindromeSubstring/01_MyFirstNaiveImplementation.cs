namespace LongestPalindromeSubstring
{
    /// <summary>
    /// My first naive O(n**2) implementation
    /// </summary>
    public static class MyFirstNaiveImplementation
    {
        public static string LongestPalindrome(string s) {
        
            string longestPalindrome = string.Empty;
        
            // Check every position for palindrome, starting from this position length
            for(int i = 0; i < s.Length; i++) {
            
                // There are 2 cases:
                // Odd palindrome: aba
                // Even palindrome: bb
                // We need to check both cases:
                
                // Odd palindrome always exists, as current character is center of it
                var oddPalindrome = GetPalindrome(s, i - 1, i + 1);
                var evenPalindrome = string.Empty;
            
                // Even palindrome exists only if prev character is equal to current one
                if(i - 1 >= 0 && s[i-1] == s[i]) {
                    evenPalindrome = GetPalindrome(s, i - 2, i + 1);
                }
            
                // Determine the longest one
                var longestIPalindrome = oddPalindrome.Length > evenPalindrome.Length 
                    ? oddPalindrome
                    : evenPalindrome;
                
                // Swap if we found better
                if(longestIPalindrome.Length > longestPalindrome.Length)
                {
                    longestPalindrome = longestIPalindrome;
                }
            }
        
        
            return longestPalindrome;
        }
    
        // Go forward and backward directions, as far as characters are the same
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