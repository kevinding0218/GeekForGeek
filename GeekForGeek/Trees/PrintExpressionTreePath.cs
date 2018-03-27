using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Trees
{
    /// <summary>
    /// Expression tree is a binary tree in which each internal node corresponds to operator 
    /// and each leaf node corresponds to operand so for example expression tree for 3 + ((5+9)*2) would be:
    ///         +
    ///        / \
    ///       3  *
    ///         / \
    ///        +   2 
    ///       / \
    ///      5   9
    /// expression: 3 + ((5+9)*2)
    /// https://www.geeksforgeeks.org/expression-tree/
    /// </summary>
    public static class EvaluatingExpressionTree
    {
        // A utility function to check if 'c'
        // is an operator
        private static bool IsOperator(string c)
        {
            if (c == "+" || c == "-"
                    || c == "*" || c == "/"
                    || c == "^")
            {
                return true;
            }
            return false;
        }

        // Utility function to do inorder traversal
        private static void PrintExpressionTreeInOrder(BinaryNodeExpression t)
        {
            if (t != null)
            {
                PrintExpressionTreeInOrder(t.Left);
                Console.Write(t.Value + " ");
                PrintExpressionTreeInOrder(t.Right);
            }
        }

        // Returns root of constructed tree for given
        // postfix expression
        /// <summary>
        /// Construction of Expression Tree:
        /// Now For constructing expression tree we use a stack.We loop through input expression and do following for every character.
        /// 1) If character is operand push that into stack
        /// 2) If character is operator pop two values from stack make them its child and push current node again.
        /// At the end only element of stack will be root of expression tree.
        /// </summary>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public static BinaryNodeExpression ConstructTree(string postfix)
        {
            Stack<BinaryNodeExpression> st = new Stack<BinaryNodeExpression>();
            BinaryNodeExpression t, t1, t2;

            // Traverse through every character of
            // input expression
            var postFixCharArray = postfix.ToCharArray();
            for (int i = 0; i < postFixCharArray.Length; i++)
            {

                // If operand, simply push into stack
                if (!IsOperator(postFixCharArray[i].ToString()))
                {
                    t = new BinaryNodeExpression(postFixCharArray[i].ToString());
                    st.Push(t);
                }
                else // operator
                {
                    t = new BinaryNodeExpression(postFixCharArray[i].ToString());

                    // Pop two top nodes
                    // Store top
                    t1 = st.Pop();      // Remove top
                    t2 = st.Pop();

                    //  make them children
                    t.Right = t1;
                    t.Left = t2;

                    st.Push(t);
                }
            }

            //  only element will be root of expression
            // tree
            t = st.Peek();
            st.Pop();

            return t;
        }

        /// <summary>
        ///      -
        ///    /   \
        ///   +     *
        ///  / \   / \ 
        /// a   b *   g
        ///      / \
        ///     e   f 
        /// infix expression is
        /// a + b - e* f * g
        /// </summary>
        public static void PrintExpression()
        {
            String postfix = "ab+ef*g*-";
            BinaryNodeExpression root = ConstructTree(postfix);
            Console.WriteLine("infix expression is");
            PrintExpressionTreeInOrder(root);
        }
    }
}
