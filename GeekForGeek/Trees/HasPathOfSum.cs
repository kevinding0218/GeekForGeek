using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Trees
{
    /// <summary>
    /// Given a tree and a sum, return true if there is a path from the root
    /// down to a leaf, such that adding up all the values along the path equals the given sum.
    /// 
    /// Strategy: subtract the node value from the sum when recurring down, and check to see if the sum is 0 when you run out of tree.
    /// https://www.geeksforgeeks.org/root-to-leaf-path-sum-equal-to-a-given-number/
    /// </summary>
    public class HasPathOfSum
    {
        public static bool haspathSum(BinaryNodeInt node, int sum)
        {
            if (node == null)
                return (sum == 0);
            else
            {
                bool ans = false;

                /* otherwise check both subtrees */
                int subsum = sum - node.Value;
                if (subsum == 0 && node.Left == null && node.Right == null)
                    return true;
                if (node.Left != null)
                    ans = ans || haspathSum(node.Left, subsum);
                if (node.Right != null)
                    ans = ans || haspathSum(node.Right, subsum);
                return ans;
            }
        }
    }
}
