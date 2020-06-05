using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {

    class Node {

        public int Value;

        public Node Left;

        public Node Right;
    }

    /*
     * Complete the swapNodes function below.
     */
    static int[][] swapNodes(int[][] indexes, int[] queries) {
  
        var tree = ReadTree(indexes);

        var queriesLength = queries.Length;
        var results = new int[queriesLength][];
        for(int i = 0; i < queriesLength; i++){
            var query = queries[i];
            SwapTree(tree, 1, query);
            var list = new List<int>();
            PrintTree(tree, list);
            results[i] = list.ToArray();
        }

        return results;
    }

    private static void PrintTree(Node n, List<int> toPrint){
        if(n.Left != null) {
            PrintTree(n.Left, toPrint);
        }
        toPrint.Add(n.Value);
        if(n.Right != null) {
            PrintTree(n.Right, toPrint);
        }
    }

    private static void SwapTree(Node n, int depth, int depthForSwap){
        if(n.Left != null) {
            SwapTree(n.Left, depth + 1, depthForSwap);
        }

        if(n.Right != null){
            SwapTree(n.Right, depth + 1, depthForSwap);
        }

        if((depth % depthForSwap) == 0) {
            Console.WriteLine($"Depth is {depth}, Query is {depthForSwap}, Swapping {n.Left == null ? -1 : n.Left.Value} and {n.Right == null ? -1 : n.Right.Value}");

            var temp = n.Left;
            n.Left = n.Right;
            n.Right = temp;
        }
    }

    private static Node ReadTree(int[][] nodes) 
    {
        int nodeToReadCursor = 0;
        var root = new Node() { Value = 1 };
        Queue<Node> toRead = new Queue<Node>();
        toRead.Enqueue(root);

        while(toRead.Count() > 0) {
            var node = toRead.Dequeue();
            var nextToRead = nodes[nodeToReadCursor++];
            var left = nextToRead[0];
            var right = nextToRead[1];

            if(left != -1) {
                node.Left = new Node() { Value = left };
                toRead.Enqueue(node.Left);
            }

            if(right != -1) {
                node.Right = new Node() { Value = right };
                toRead.Enqueue(node.Right);
            }
        }

        return root;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[][] indexes = new int[n][];

        for (int indexesRowItr = 0; indexesRowItr < n; indexesRowItr++) {
            indexes[indexesRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), indexesTemp => Convert.ToInt32(indexesTemp));
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine());

        int[] queries = new int [queriesCount];

        for (int queriesItr = 0; queriesItr < queriesCount; queriesItr++) {
            int queriesItem = Convert.ToInt32(Console.ReadLine());
            queries[queriesItr] = queriesItem;
        }

        int[][] result = swapNodes(indexes, queries);

        textWriter.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));

        textWriter.Flush();
        textWriter.Close();
    }
}
