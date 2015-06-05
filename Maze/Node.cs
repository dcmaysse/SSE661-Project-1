using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Node
    {
        private int data;
        private Node parent;
        private Node[] children;

        public Node(int data)
        {
            this.data = data;
            parent = null;
            children = new Node[3];
        }

        public void addLeftChild(Node child)
        {
            children[0] = child;
            child.setParent(this);
        }

        public void addMiddleChild(Node child)
        {
            children[1] = child;
            child.setParent(this);
        }

        public void setParent(Node parent)
        {
            this.parent = parent;
        }
    }
}
