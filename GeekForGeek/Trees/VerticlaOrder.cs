using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Trees
{
    /// <summary>
    ///         1
    ///        / \
    ///       2   3
    ///      / \  
    ///     4   5
    /// VerticlaOrder: [[4][2][15][3]]
    /// https://www.geeksforgeeks.org/level-order-tree-traversal/
    /// </summary>
    public static class VerticlaOrder
    {
        private class NodeWithHorizontalDistance
        {
            public BinaryNodeExpression root { get; set; }
            public int horizontalDistnace { get; set; }

            public NodeWithHorizontalDistance(BinaryNodeExpression root, int horizontalDistnace)
            {
                this.root = root;
                this.horizontalDistnace = horizontalDistnace;
            }
        }
        public static List<List<int>> verticalOrder(BinaryNodeExpression root)
        {
            List<List<int>> result = new List<List<int>>();
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            int minHorizontalDistnace = int.MaxValue;
            int maxHorizontalDistnace = int.MinValue;

            Queue<NodeWithHorizontalDistance> q = new Queue<NodeWithHorizontalDistance>();
            q.Enqueue(new NodeWithHorizontalDistance(root, 0));

            while(q.Count > 0)
            {
                NodeWithHorizontalDistance cur = q.Dequeue();
                dic.Add(cur.horizontalDistnace, new List<int> { Convert.ToInt32(cur.root.Value) });
                minHorizontalDistnace = Math.Min(minHorizontalDistnace, cur.horizontalDistnace);
                maxHorizontalDistnace = Math.Max(maxHorizontalDistnace, cur.horizontalDistnace);

                if (cur.root.Left != null)
                    q.Enqueue(new NodeWithHorizontalDistance(cur.root.Left, cur.horizontalDistnace - 1));

                if (cur.root.Right != null)
                    q.Enqueue(new NodeWithHorizontalDistance(cur.root.Right, cur.horizontalDistnace + 1));
            }

            for (int i = minHorizontalDistnace; i <= maxHorizontalDistnace; i++)
            {
                result.Add(dic.GetValueOrDefault(i));
            }
            return result;
        }
    }
}
