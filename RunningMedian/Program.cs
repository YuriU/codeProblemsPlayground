using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {

    abstract class Heap {
        private int[] _heap;
        private int _heap_size;


        public int Top => _heap[0];

        protected Heap(int[] array, int size){
            _heap = array;
            _heap_size = size;
        }

        public int Size => _heap_size;

        public int ExtractTop() {
            var top = _heap[0];
            _heap[0] = _heap[_heap_size - 1];
            _heap_size--;
            if(_heap_size > 0) {
                Heapify(0);
            }
            return top;
        }

        public void Insert(int value) {
            _heap_size++;
            if(_heap_size > _heap.Length){
                var newArray = new int[_heap.Length*2];
                Array.Copy(_heap, newArray, _heap.Length);
                _heap = newArray;
            }

            _heap[_heap_size - 1] = GetLowestRankElement();
            Promote(_heap_size - 1, value);

        }

        private void Promote(int index, int value){
            if(IsAPriorB(_heap[index], value)){
                throw new ArgumentException("value");
            }

            _heap[index] = value;
            var parent = (index + 1) / 2 -1;
            
            while(index != 0 && IsAPriorB(_heap[index], _heap[parent])){
                Swap(index, parent);
                index = parent;
                parent = (index + 1) / 2 -1;
            }
        }

        private void Heapify(int index){
            var prior = index;
            var left = ((index + 1) * 2) - 1;
            var right = ((index + 1) * 2 + 1) - 1;

            if(left < _heap_size && IsAPriorB(_heap[left], _heap[prior])){
                prior = left;
            }

            if(right < _heap_size && IsAPriorB(_heap[right], _heap[prior])){
                prior = right;
            }

            if(prior != index) {
                Swap(prior, index);
                Heapify(prior);
            }
        }

        private void Swap(int a, int b){
            var temp = _heap[a];
            _heap[a] = _heap[b];
            _heap[b] = temp;
        }

        protected abstract bool IsAPriorB(int a, int b);

        protected abstract int GetLowestRankElement();
        
    }

    class MaxHeap : Heap {

        public MaxHeap() : base(new int[1], 0) {
        }
        protected override bool IsAPriorB(int a, int b) {
            return a > b;
        }

        protected override int GetLowestRankElement() {
            return int.MinValue;
        }
    }

    class MinHeap : Heap {

        public MinHeap() : base(new int[1], 0) {
        }
        protected override bool IsAPriorB(int a, int b) {
            return a < b;
        }

        protected override int GetLowestRankElement() {
            return int.MaxValue;
        }
    }

    /*
     * Complete the runningMedian function below.
     */
    static double[] runningMedian(int[] a) {

        double[] results = new double[a.Length];

        if(a.Length == 0){
            return results;
        }

        results[0] = a[0];

        var lowestPart = new MaxHeap();
        var biggestPart = new MinHeap();

        int oddMedian = a[0];

        for(int i = 1; i < a.Length; i++){

            int median = a[i]; 
            median = SwapWithMin(median, biggestPart);
            median = SwapWithMax(median, lowestPart);

            if(i%2 == 1)
            {
                results[i] = ((double)median + oddMedian) / 2;

                // Push medians to min and max trees respectivele
                if(median < oddMedian) {
                    lowestPart.Insert(median);
                    biggestPart.Insert(oddMedian);
                } else {
                    lowestPart.Insert(oddMedian);
                    biggestPart.Insert(median);
                }
            }
            else {
                results[i] = (double)median;
                oddMedian = median;
            }
        }

        return results;
    }

    private static int SwapWithMin(int number, MinHeap heap) {
        if(heap.Size > 0 && number > heap.Top){
            var result = heap.ExtractTop();
            heap.Insert(number);
            return result;
        }
        else {
            return number;
        }
    }

    private static int SwapWithMax(int number, MaxHeap heap) {
        if(heap.Size > 0 && number < heap.Top){
            var result = heap.ExtractTop();
            heap.Insert(number);
            return result;
        }
        else {
            return number;
        }
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int aCount = Convert.ToInt32(Console.ReadLine());

        int[] a = new int [aCount];

        for (int aItr = 0; aItr < aCount; aItr++) {
            int aItem = Convert.ToInt32(Console.ReadLine());
            a[aItr] = aItem;
        }

        double[] result = runningMedian(a);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
