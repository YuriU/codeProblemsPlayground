using System;
using System.Linq;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7, 4, 3, 19, 8, 33, 45 };

            PrintUtil.PrintHeap(array);

            HeapSort(array);

            PrintUtil.PrintHeap(array);

            foreach(var item in array){
                Console.Write(item);
                Console.Write(' ');
            }
        }

        public static void HeapSort(int[] array) {

            BuildHeap(array, array.Length);

            for(int i = array.Length - 1; i >= 0; i--){
                
                var temp = array[i];
                array[i] = array[0];
                array[0] = temp;

                MaxHeapify(array, 0, i);
            }
        }

        public static void BuildHeap(int[] heap, int heap_size){
            for(int i = heap_size / 2; i >= 0; i--){
                MaxHeapify(heap, i, heap_size);
            }
        }

        public static void MaxHeapify(int[] heap, int index, int heap_size)
        {   
            var left = Left(index);
            var right = Right(index);

            int biggest = index;
            if(left < heap_size && heap[left] > heap[biggest]){
                biggest = left;
            }

            if(right < heap_size && heap[right] > heap[biggest]){
                biggest = right;
            }

            if(biggest != index){
                var temp = heap[biggest];
                heap[biggest] = heap[index];
                heap[index] = temp;

                MaxHeapify(heap, biggest, heap_size);
            }
        }

        public static int Parent(int index){
            int oneBasedIndex = index + 1;
            return (oneBasedIndex / 2) - 1;
        }
        public static int Left(int index) {
            int oneBasedIndex = index + 1;
            return (oneBasedIndex * 2) - 1;
        }

        public static int Right(int index) {
            int oneBasedIndex = index + 1;
            return (oneBasedIndex * 2 + 1) - 1;
        }
    }
}
