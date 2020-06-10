using System;
using System.Text;

namespace SortedArraysMedian
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayA = new int[] { 1, 2 };
            var arrayB = new int[] { 3, 4 };

            Get2SortedArraysMedian(arrayA, arrayB);

        
        }

        static double Get2SortedArraysMedian(int[] array1, int[] array2) {

            // A - shortest array
            var a = array1.Length < array2.Length ? array1 : array2;

            // B longest
            var b = a == array1 ? array2 : array1;

            int aLength = a.Length;
            int bLength = b.Length;

            int min_index = 0;
            int max_index = aLength; // Length of the smaller array

            int aIndex = 0;
            int bIndex = 0;

            int median = -1;
            while(min_index <= max_index) {

                aIndex = (max_index + min_index) / 2;
                bIndex = (aLength + bLength + 1) / 2 - aIndex;


                PrintArrays(a, b, min_index, max_index, aIndex, bIndex);

                Console.WriteLine();

                if(aIndex > 0 && bIndex < b.Length && a[aIndex] < b[bIndex-1]){
                    min_index = aIndex + 1;
                } 
                else if(bIndex > 0 && aIndex < a.Length && b[bIndex] < a[aIndex-1]){
                    max_index = aIndex - 1;
                }
                else {

                    Console.WriteLine("Found");
                    if(aIndex == 0){
                        median = b[bIndex - 1];
                    }
                    else if(bIndex == 0){
                        median = a[aIndex - 1];
                    }
                    else{
                        median = Math.Max(a[aIndex -1], b[bIndex-1]);
                    }

                    break;
                }
            }

            

            Console.WriteLine($"Median {median}");

            if((aLength + bLength) % 2 == 0){

                Console.WriteLine("Hello");

            }

            return 0.0;
        }


        static void PrintArrays(int[] a, int[] b, int min, int max, int aIndex, int bIndex) {

            PrintIndexes(a, min, max, aIndex);
            PrintArray(a);

            Console.WriteLine();

            PrintArray(b);
            PrintIndexes(b, min, max, bIndex);
        }


        private static void PrintIndexes(int[] array, int min, int max, int median){

            var oldBackground = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            for(int i = 0; i < array.Length; i++) {

                var oldColor = Console.ForegroundColor;
                if(i == min) {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if(i == max) {    
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if(i == median) {    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write(PrintNumber(i, 8));
                Console.ForegroundColor = oldColor;
            }
            Console.BackgroundColor = oldBackground;
            Console.WriteLine();
        }

        private static void PrintArray(int[] array) {
            for(int i = 0; i < array.Length; i++){
                Console.Write(PrintNumber(array[i], 8));
            }
            Console.WriteLine();
        }

        private static string PrintNumber(int number, int width) {
            var str = number.ToString();
            var rightMargin = (width - str.Length) / 2;
            var leftMargin = str.Length + 2* rightMargin == width ? rightMargin : rightMargin + 1;
            return $"{NSpaces(leftMargin)}{str}{NSpaces(rightMargin)}";
        }

        private static string NSpaces(int n){
            var sb = new StringBuilder();

            for(int i = 0; i < n; i++) {
                sb.Append(' ');
            }

            return sb.ToString();
        }
    }
}
