using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Node
    {
        private string data;

        private Node son;
        private Node sibling;

        public string Data { get => data; set => data = value; }
        public Node Son { get => son; set => son = value; }
        public Node Sibling { get => sibling; set => sibling = value; }

        public Node()
        {
            data = "";
            son = null;
            sibling = null;
        }
    }
}
