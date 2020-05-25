using System;
using System.Linq;

namespace LongestPalindromeSubstring
{
    public class Manachers_Algorithm
    {
        public static string LongestPalindrome(string s)
        {
            var stringWithSubstitutors = string.Join('$', s.ToCharArray());
            stringWithSubstitutors = $"${stringWithSubstitutors}$";
            
            int[] palindromeLenghts = new int[stringWithSubstitutors.Length];

            int left = 0;
            int right = 0;
            int mirrorLine = 0;
            
            for (int i = 0; i < stringWithSubstitutors.Length; i++)
            {
                // Calculating the index of element on the other side of mirror
                int positionFromMirror = i - mirrorLine;
                int mirroredElementIndex = mirrorLine - positionFromMirror;

                if (right > i) // We are inside palindrome
                {
                    // Length of palindrome with center in mirrored element
                    int mirroredElementPalindromeLength = palindromeLenghts[mirroredElementIndex];
                    
                    // Adding threshold (right - i) in case if mirrored element had longest palindrome
                    palindromeLenghts[i] = Math.Min(right - i, mirroredElementPalindromeLength);
                }
                else // We are outside of our known palindrome
                {
                    palindromeLenghts[i] = 0;
                }

                // Iterating both directions assuming palindromeLenghts[i] elements are the same
                int indexLeft = i - 1 - palindromeLenghts[i];
                int indexRight = i + 1 + palindromeLenghts[i];
                
                while (indexLeft >= 0 && indexRight < stringWithSubstitutors.Length 
                       && stringWithSubstitutors[indexLeft] == stringWithSubstitutors[indexRight])
                {
                    palindromeLenghts[i]++;
                    indexLeft = i - 1 - palindromeLenghts[i];
                    indexRight = i + 1 + palindromeLenghts[i];
                }


                if (i + palindromeLenghts[i] > right) // Palindrome starting from i is longer than our known bounds
                {
                    mirrorLine = i; // Setting current position as new mirror line
                    right = i + palindromeLenghts[i];
                }
            }

            int maxLength = 0;
            int maxLengthCenterIndex = 0;
            for (int i = 0; i < stringWithSubstitutors.Length; i++)
            {
                int lenght = palindromeLenghts[i];
                if (lenght > maxLength)
                {
                    maxLength = lenght;
                    maxLengthCenterIndex = i;
                }
            }

            var maxLenghtStart = maxLengthCenterIndex - maxLength;
            var maxLengthEnd = maxLengthCenterIndex + maxLength;
            
            var maxLengthPalindrome = stringWithSubstitutors.Substring(maxLenghtStart, maxLengthEnd - maxLenghtStart + 1);
            
            
            return maxLengthPalindrome.Replace("$", null);
        }
    }
}