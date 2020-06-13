/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k) {
        var headWrapper = new ListNode(-1, head);
        
        var beforeGroup = headWrapper;
        while(beforeGroup != null){
            beforeGroup = ReverseGroup(beforeGroup, k);    
        }

        return headWrapper.next;
    }
    
    private ListNode ReverseGroup(ListNode prevNode, int groupSize) {
        var firstNodeOfGroup = prevNode.next;
        var current = firstNodeOfGroup;
        
        int n = 0;
        while(n++ < groupSize - 1){
            if(current == null)
                return null;
            
            current = current.next;
        }
        
        if(current == null){
            return null;
        }
        var last = current;
        var nextOfLast = last.next;
                
        n = 0;
        current = firstNodeOfGroup;
        var prev = nextOfLast;
        var next = current.next;
        var endOfReversedGroup = current;
        while(n++ < groupSize){
            
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }
        
        prevNode.next = prev;
        
        Console.WriteLine(endOfReversedGroup.val);
        return endOfReversedGroup;
    }
}