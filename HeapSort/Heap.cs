using System;

public abstract class Heap {
    protected int[] _heap;

    protected int _heap_size;

    protected Heap(int[] array, int heap_size) {
        _heap = array;
        _heap_size = heap_size;
    }

    protected abstract void Heapify(int index);

    public void BuildHeap() {
        for(int i = _heap_size / 2 - 1; i >= 0; i--){
            Heapify(i);
        }
    }

    public int Size => _heap_size;


    public int ExtractTop()
    {
        var topValue = _heap[0];
        _heap[0] = _heap[_heap_size - 1];
        _heap_size--;
        Heapify(0);
        return topValue;
    }

    protected int Parent(int index) {
        var oneBased = index + 1;
        var parent = oneBased / 2;
        return parent - 1;
    }

    protected int Left(int index){
        var oneBased = index + 1;
        var left = oneBased * 2;
        var zeroBased = left - 1;
        return zeroBased;
    }

    protected int Right(int index){
        var oneBased = index + 1;
        var left = oneBased * 2 + 1;
        var zeroBased = left - 1;
        return zeroBased;
    }

    protected void Swap(int a, int b){
        var temp = _heap[a];
        _heap[a] = _heap[b];
        _heap[b] = temp;
    }

    public void Print(){
        PrintUtil.PrintHeap(_heap, _heap_size);
    }

}

public class MinHeap : Heap {
    public MinHeap(int[] array) 
        : base(array, array.Length) { }

    public MinHeap() 
        : base(new int[100], 100) {}


    protected override void Heapify(int index) {

        var left = Left(index);
        var right = Right(index);

        var smallest = index;
        if(left < _heap_size && _heap[left] < _heap[smallest]) {
            smallest = left;
        }

        if(right < _heap_size && _heap[right] < _heap[smallest]) {
            smallest = right;
        }

        if(smallest != index) {
            Swap(index, smallest);
            Heapify(smallest);
        }
    }
}

public class MaxHeap : Heap {
    public MaxHeap(int[] array) 
        : base(array, array.Length) { }

    public MaxHeap() 
        : base(new int[100], 100) {}


    protected override void Heapify(int index) {

        var left = Left(index);
        var right = Right(index);

        var biggest = index;
        if(left < _heap_size && _heap[left] > _heap[biggest]) {
            biggest = left;
        }

        if(right < _heap_size && _heap[right] > _heap[biggest]) {
            biggest = right;
        }

        if(biggest != index) {
            Swap(index, biggest);
            Heapify(biggest);
        }
    }

    public void IncreaseKey(int i, int value){
        if(_heap[i] > value){
            throw new ArgumentException("value");
        }

        _heap[i] = value;
        
        while(i > 0) {
            var parent = Parent(i);
            if(_heap[parent] < _heap[i]){
                Swap(parent, i);
            }
            i = parent;
        }
    }
}