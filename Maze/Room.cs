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

        public Room()
        {
            exit = false;
            visited = false;
            neighbors = new Room[4];
            walls = new bool[] { true, true, true, true };
        }

        public void addNeighbor(Room neighbor,int dir)
        {
            neighbors[dir] = neighbor;
            switch (dir)
            {
                case 0:
                    neighbor.addNeighbor(this, 2);
                    break;
                case 1:
                    neighbor.addNeighbor(this, 3);
                    break;
                case 2:
                    neighbor.addNeighbor(this, 0);
                    break;
                case 3:
                    neighbor.addNeighbor(this, 1);
                    break;
            }
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

        public void carveWall(int dir)
        {
            walls[dir] = false;
            switch (dir)
            {
                case 0:
                    neighbors[dir].carveWall(2);
                    break;
                case 1:
                    neighbors[dir].carveWall(3);
                    break;
                case 2:
                    neighbors[dir].carveWall(0);
                    break;
                case 3:
                    neighbors[dir].carveWall(1);
                    break;
            }
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
            if (neighbors[dir] == null)
                return false;
            else
                return true;
        }
    }
}
