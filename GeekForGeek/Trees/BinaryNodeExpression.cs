using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Trees
{
    public class BinaryNodeExpression
    {
        public string Value { get; set; }
        public BinaryNodeExpression Left { get; set; }
        public BinaryNodeExpression Right { get; set; }

        public BinaryNodeExpression(string value)
        {
            this.Value = value;
            this.Left = this.Right = null;
        }
    }
}
