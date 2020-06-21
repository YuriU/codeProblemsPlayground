public class Solution {
    public int LongestValidParentheses(string s) {
        var stack = new Stack<char>();
        var siblingsSumsStack = new Stack<int>();
        
        int maxSum = 0;
        
        int sum = 0;
        foreach(var ch in s) {
            if(ch == ')' && stack.Count > 0 && stack.Peek() == '(') {
                stack.Pop();
                sum+=2;
                sum += siblingsSumsStack.Pop();
                
                if(sum > maxSum){
                    maxSum = sum;
                }
            }
            else {
                stack.Push(ch);
                if(ch == '(') {
                    siblingsSumsStack.Push(sum);
                }
                sum = 0;
            }
        }
        
        return maxSum;
    }

}