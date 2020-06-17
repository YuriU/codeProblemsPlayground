using System;
using System.Collections.Generic;

namespace NextPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3 };
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if(j == i)
                        continue;
                    
                    for (int k = 0; k < array.Length; k++)
                    {
                        if(k == j || k == i)
                            continue;
                        
                        Console.WriteLine($"{array[i]} {array[j]} {array[k]}");
                    }
                }
            }
        }
    }
}
