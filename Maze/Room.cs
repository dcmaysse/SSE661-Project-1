using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Room
    {
        private Boolean exit;
        private Boolean visited;
        private Room parent;
        private Room[] children;

        public Room(Boolean exit)
        {
            this.exit = exit;
            visited = false;
            parent = null;
            children = new Room[3];
        }

        public void addChild(Room child,int pos)
        {
            children[pos] = child;
            child.setParent(this);
        }

        public void setParent(Room parent)
        {
            this.parent = parent;
        }

        public void visit()
        {
            visited = true;
        }

        public Room getParent()
        {
            return parent;
        }

        public Room getChild(int pos)
        {
            children[pos].visit();
            return children[pos];
        }

        public Boolean isVisited()
        {
            return visited;
        }

        public Boolean isExit()
        {
            return exit;
        }
    }
}
