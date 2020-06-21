public class Solution {
    public int Search(int[] nums, int target) {
        if(nums.Length == 0){
            return -1;
        }
        
        if(nums.Length == 1){
            return nums[0] == target ? 0 : -1;
        }
        
        var pivot = GetPivot(nums);
        Console.WriteLine(pivot);
        
        var l = 0;
        var r = nums.Length - 1;
        while(l < r) {
            var middle = (l + r) / 2;
            var midNumber = nums[PivotedIndex(middle, pivot, nums.Length)];
            if(midNumber == target) {
                return PivotedIndex(middle, pivot, nums.Length);
            }
            else if(midNumber < target) {
                
                l = middle + 1;
            }
            else {
                r = middle - 1;
            }
        }
        
        int realIndex = PivotedIndex(l, pivot, nums.Length);
        return nums[realIndex] == target ? realIndex : -1;
    }
    
    private int PivotedIndex(int i, int pivot, int length) {
        return (i + pivot) % length;
    }
    
    private int GetPivot(int[] nums) {
        if(nums[nums.Length - 1] > nums[0]){
            return 0;
        }
        
        int l = 0;
        int r = nums.Length - 1;
        while(l + 1 != r) 
        {
            var middle = (l + r) / 2;
            if(nums[middle-1] > nums[middle]){
                return middle;
            }
            else {
                if(nums[middle] > nums[0]){
                    l = middle;
                }
                else {
                    r = middle;
                }
            }
        }
        
        return r;
    }
}