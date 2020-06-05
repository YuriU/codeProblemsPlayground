using System;

public abstract class Heap {
    protected int[] _heap;

    protected int _heap_size;

    protected Heap(int[] array, int heap_size) {
        _heap = array;
        _heap_size = heap_size;
    }

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


    public void PromoteKey(int i, int value){
        if(!IsAPriorB(value, _heap[i])){
            throw new ArgumentException("value");
        }

        _heap[i] = value;
        
        while(i > 0) {
            var parent = Parent(i);
            if(IsAPriorB(_heap[i], _heap[parent])) {
                Swap(parent, i);
            }

            i = parent;
        }
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

    protected abstract bool IsAPriorB(int a, int b);

    public void Print(){
        PrintUtil.PrintHeap(_heap, _heap_size);
    }

    protected void Heapify(int index) {

        var left = Left(index);
        var right = Right(index);

        var prior = index;
        if(left < _heap_size && IsAPriorB(_heap[left], _heap[prior])) {
            prior = left;
        }

        if(right < _heap_size && IsAPriorB(_heap[right], _heap[prior])) {
            prior = right;
        }

        if(prior != index) {
            Swap(index, prior);
            Heapify(prior);
        }
    }
}

public class MinHeap : Heap {
    public MinHeap(int[] array) 
        : base(array, array.Length) { }

    public MinHeap() 
        : base(new int[100], 100) {}

    protected override bool IsAPriorB(int a, int b){
        return a < b;
    }
}

public class MaxHeap : Heap {
    public MaxHeap(int[] array) 
        : base(array, array.Length) { }

    public MaxHeap() 
        : base(new int[100], 100) {}


    protected override bool IsAPriorB(int a, int b){
        return a > b;
    }
}