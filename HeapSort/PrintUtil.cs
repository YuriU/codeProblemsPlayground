using System.Linq;
using System.Text;
using System.Collections.Generic;
using System;

public static class PrintUtil {
    public static void PrintHeap(int[] heap) {
            var height = (int)Math.Log2(heap.Length);
            var lastLevel = (int)Math.Pow(2, height);            
            var maxWidth = lastLevel * 4;

            int length = 1;
            int index = 0;
            for(int h = 0; h <= height; h++){

                List<int> list = new List<int>();
                for(int i = 0; i < length; i++){
                    if(index < heap.Length){
                        list.Add(heap[index++]);
                    }
                    else {
                        list.Add(-1);
                    }
                }

                PrintHeapLine(list.ToArray(), maxWidth);
                maxWidth/=2;
                
                Console.WriteLine();
                length*=2;
            }
        }

        static void PrintHeapLine(int[] items, int width)
        {
            var sb = new StringBuilder();
            foreach(var item in items) {
                if(item != -1){
                    sb.Append(FormatNumber(item, width));
                }
                else{
                    sb.Append(NSpaces(width));
                }
                
            }
            Console.WriteLine(sb.ToString());
        }

        static string FormatNumber(int number, int width){
            var str = number.ToString();
            var spacesToAdd = width - str.Length;

            var spacesToAddBefore = spacesToAdd / 2;
            var spacesToAddAfter = spacesToAdd / 2;

            if(spacesToAdd % 2 != 0){
                spacesToAddBefore++;
            }

            var sb = new StringBuilder();
            sb.Append(NSpaces(spacesToAddBefore));
            sb.Append(str);
            sb.Append(NSpaces(spacesToAddAfter));

            return sb.ToString();
        }

        static string NSpaces(int spaces) {
            var sb = new StringBuilder();
            for(int i = 0; i < spaces; i++){
                sb.Append(' ');
            }
            return sb.ToString();
        }
}