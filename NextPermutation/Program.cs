using System;
using System.Collections.Generic;

namespace NextPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3 };
            PrintArray(array);
            Console.WriteLine();

            PrintPermutations(array, 0, array.Length - 1);
            return;
            for (int i = 0; i < array.Length; i++)
            {
                Swap(array, 0, i);
                for (int j = 1; j < array.Length; j++)
                {
                    Swap(array, 1, j);
                    PrintArray(array);    
                    Swap(array, j, 1);
                }
                
                Swap(array, i, 0);
            }
        }


        static void PrintPermutations(int[] array, int from, int to)
        {
            if (from == to)
            {
                PrintArray(array);
            }
            else
            {
                for (int i = from; i <= to; i++)
                {
                    Swap(array, from, i);
                    PrintPermutations(array, from+1, to);
                    Swap(array, i, from);
                }
            }
        }
        
        static void Swap(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static void PrintFixedPermutation(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (j == i)
                        continue;

                    for (int k = 0; k < array.Length; k++)
                    {
                        if (k == j || k == i)
                            continue;

                        Console.WriteLine($"{array[i]} {array[j]} {array[k]}");
                    }
                }
            }
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                Console.Write(' ');
            }
            Console.WriteLine();
        }
        
        
    }
}
