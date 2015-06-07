using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Room
    {
        private bool exit;
        private bool visited;
        private Room[] neighbors;
        private bool[] walls;
        int x, y;

        public Room(int x, int y)
        {
            this.x = x;
            this.y = y;
            exit = false;
            visited = false;
            neighbors = new Room[] { this, this, this, this };
            walls = new bool[] { true, true, true, true };
        }

        public void addNeighbor(Room neighbor,int dir)
        {
            neighbors[dir] = neighbor;
        }

        public void setExit()
        {
            exit = true;
        }

        public void setVisited()
        {
            visited = true;
        }

        public Room getNeighbor(int dir)
        {
            return neighbors[dir];
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public void carveWall(int dir)
        {
            walls[dir] = false;
        }

        public bool isWall(int dir)
        {
            return walls[dir];
        }

        public bool isVisited()
        {
            return visited;
        }

        public bool isExit()
        {
            return exit;
        }

        public bool neighborExists(int dir)
        {
            if (neighbors[dir].Equals(this))
                return false;
            else
                return true;
        }
    }
}
