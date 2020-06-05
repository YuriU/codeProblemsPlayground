using System;
using System.Linq;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7, 4, 3, 19, 8, 33, 45 };

            var minHeap = new MinHeap(array);

            minHeap.Print();

            minHeap.BuildHeap();

            minHeap.Print();

            var maxHeap = new MaxHeap(array);

            maxHeap.BuildHeap();

            maxHeap.Print();

            /*PrintUtil.PrintHeap(array);

            BuildMaxHeap(array, array.Length);

            PrintUtil.PrintHeap(array);

            BuildMinHeap(array, array.Length);

            PrintUtil.PrintHeap(array);

            var minValue = ExtractMin(array, array.Length);

            Console.WriteLine($"MinValue: {minValue}");

            PrintUtil.PrintHeap(array, array.Length - 1);

            minValue = ExtractMin(array, array.Length - 1);

            Console.WriteLine($"MinValue: {minValue}");

            PrintUtil.PrintHeap(array, array.Length - 2);*/
        }

        private static void BuildMaxHeap(int[] heap, int heap_size) {
            for(int i = heap_size / 2 -1; i >= 0; i--){
                MaxHeapify(heap, i, heap_size);
            }
        }

        private static void BuildMinHeap(int[] heap, int heap_size) {
            for(int i = heap_size / 2 -1; i >= 0; i--){
                MinHeapify(heap, i, heap_size);
            }
        }

        private static int ExtractMin(int[] heap, int heap_size) {
            var minValue = heap[0];
            heap[0] = heap[heap_size - 1];
            MinHeapify(heap, 0, heap_size - 1);
            return minValue;
        }


        private static void MaxHeapify(int[] heap, int index, int heap_size){
            int biggest = index;
            int left = Left(index);
            int right = Rigth(index);

            if(left < heap_size && heap[left] > heap[biggest]){
                biggest = left;
            }

            if(right < heap_size && heap[right] > heap[biggest]){
                biggest = right;
            }

            if(biggest != index) {
                var temp = heap[index];
                heap[index] = heap[biggest];
                heap[biggest] = temp;

                MaxHeapify(heap, biggest, heap_size);
            }
        }

        private static void MinHeapify(int[] heap, int index, int heap_size){
            int smallest = index;
            int left = Left(index);
            int right = Rigth(index);

            if(left < heap_size && heap[left] < heap[smallest]){
                smallest = left;
            }

            if(right < heap_size && heap[right] < heap[smallest]){
                smallest = right;
            }

            if(smallest != index) {
                var temp = heap[index];
                heap[index] = heap[smallest];
                heap[smallest] = temp;

                MinHeapify(heap, smallest, heap_size);
            }
        }

        private static int Parent(int i) {
            var oneBased = i + 1;
            return (oneBased / 2) -1;
        }

        private static int Left(int i) {
            var oneBased = i + 1;
            return (oneBased * 2) -1;
        }

        private static int Rigth(int i) {
            var oneBased = i + 1;
            return (oneBased * 2 + 1) -1;
        }
    }
}
