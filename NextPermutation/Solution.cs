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
    
    // Check if permutation [from:to] is last for it's size
    // e.g. 3-2-1, 4-3, 1
    // All elements are in descending order
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
    
    // Finding minimal elemente int the range bigget than N
    // For example for the permutatuin
    // 1 3 4 2  - We discovered that 4 2 is last permutation for length 2, so the range 1 3 is over
    // Looking for the new outer range bigget than 1 3
    // To do that, we need to find minimal value in array 4 2 which is bigger than 3. In our case 4
    // Then we can pick it for start new outer range 1 4 and have inner range 2 3
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
