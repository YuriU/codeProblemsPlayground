using System;
using System.Collections.Generic;
using System.Linq;

namespace _4SumsInArray
{
    public class Solution {
        public IList<IList<int>> FourSum(int[] nums, int target) {
            
        IList<IList<int>> results = new List<IList<int>>();
        nums = nums.OrderBy(n => n).ToArray();
        HashSet<string> used = new HashSet<string>();
            
            
        for(int f = 0; f < nums.Length-3; f++) {
                for(int t = f + 1; t < nums.Length-2; t++)   {
                    
                    var key = $"{nums[f]}_{nums[t]}";
                    if(used.Contains(key))
                        continue;
                    
                    used.Add(key);
                    
                    var rest = target - nums[f] - nums[t];
                    
                    var twosums = twoSum(nums, t+1, nums.Length-1, rest);
                    
                    if(twosums.Count > 0){
                        foreach(var twoSum in twosums){
                            twoSum[0] = nums[f];
                            twoSum[1] = nums[t];
                            
                            results.Add(twoSum);
                        }
                    }
                }
        }
            
            return results;
        }
        
        public List<IList<int>> twoSum(int[] nums, int from, int to, int number) {
            
            List<IList<int>> result = new List<IList<int>>();
            while(from < to) {
                
                var sum = nums[from] + nums[to];
                if(sum == number){
                    result.Add(new List<int> { 0, 0, nums[from], nums[to] });
                    from++;
                    to--;
                    
                    // Removing duplicates
                    while(from < to && nums[from] == nums[from - 1]) { from++; }
                    while(from < to && nums[to] == nums[to + 1]) { to--; }
                }
                else if(sum < number) {
                    from++;
                }
                else {
                    to--;
                }
            }
            
            return result;
        }
    }
}
