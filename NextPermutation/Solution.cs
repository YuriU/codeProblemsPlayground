public class Solution {
    public void NextPermutation(int[] nums) {
        if(IsLastPermutation(nums, 0, nums.Length-1)){
            Sort(nums, 0);
            return;
        }
        
        Rearange(nums, 0, nums.Length-1);
    }
    
    
    void Rearange(int[] nums, int from, int to) {
        var n = nums[from];
        if(IsLastPermutation(nums, from + 1, to)){
            var indexOfSmaller = IndexOfSmaller(nums, from + 1, n);
            Swap(nums, from, indexOfSmaller);
            Sort(nums, from + 1);
        }
        else {
            Rearange(nums, from+1, to);
        }
    }
    
    void Sort(int[] nums, int from){
        // Bubble Sort for start
        
        for(int i = from; i < nums.Length + 1; i++){
            for(int j = i + 1; j < nums.Length; j++){
                if(nums[i] > nums[j]) {
                    Swap(nums, i, j);
                }
            }
        }
    }
    
    bool IsLastPermutation(int[] nums, int from, int to) {
        if(from == to) {
            return true;
        }
        
        for(int i = from; i < to; i++){
            if(nums[i] < nums[i+1])
                return false;
        }
        
        return true;
    }
    
    private int IndexOfSmaller(int[] nums, int from, int biggerThan){
        int min = int.MaxValue;
        int minIndex = -1;
        for(int i = from; i < nums.Length; i++) {
            if(nums[i] <= biggerThan){
                continue;
            }
            else {
                if(nums[i] < min){
                    min = nums[i];
                    minIndex = i;
                }
            }
        }
        return minIndex;
    }
    
    private void Swap(int[] nums, int i, int j){
         var temp = nums[i];
         nums[i] = nums[j];
         nums[j] = temp;
    }
}