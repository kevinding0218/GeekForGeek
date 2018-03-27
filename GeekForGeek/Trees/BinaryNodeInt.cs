using System;
using System.Collections.Generic;
using System.Text;

namespace GeekForGeek.Trees
{
    public class BinaryNodeInt
    {
        public int Value { get; set; }
        public BinaryNodeInt Left { get; set; }
        public BinaryNodeInt Right { get; set; }

        public BinaryNodeInt(int value)
        {
            this.Value = value;
            this.Left = this.Right = null;
        }
    }
}
