namespace LongestPalindromeSubstring
{
    public static class MyFirstNaiveImplementation
    {
        public static string LongestPalindrome(string s) {
        
            string longestPalindrome = string.Empty;
        
            for(int i = 0; i < s.Length; i++) {
            
                var oddPalindrome = GetPalindrome(s, i - 1, i + 1);
                var evenPalindrome = string.Empty;
            
                if(i - 1 >= 0 && s[i-1] == s[i]){
                    evenPalindrome = GetPalindrome(s, i - 2, i + 1);
                }
            
                var longestIPalindrome = oddPalindrome.Length > evenPalindrome.Length 
                    ? oddPalindrome
                    : evenPalindrome;
            
                if(longestIPalindrome.Length > longestPalindrome.Length)
                {
                    longestPalindrome = longestIPalindrome;
                }
            }
        
        
            return longestPalindrome;
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