using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Maze
    {
        Room[,] rooms;
        Random rng;

        public Maze()
        {
            rooms = new Room[10,10];
            rng = new Random();
            createMaze();
            carveMaze();
        }

        private void createMaze()
        {
            for (int i=0; i<10; i++)
            {
                for (int j=0; j<10; j++)
                {
                    rooms[i, j] = new Room();
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    rooms[i, j].addNeighbor(rooms[i + 1, j], 1);
                    rooms[i, j].addNeighbor(rooms[i, j + 1], 2);
                }
            }
        }

        private void carveMaze()
        {
            List<Room> temp = new List<Room>();
            temp.Add(rooms[rng.Next(0, 10), rng.Next(0, 10)]);
            temp.ElementAt(0).setVisited();
            while (temp.Count>0)
            {
                Room curr = temp.ElementAt(rng.Next((temp.Count) / 2, temp.Count - 1));
                Room neighborDir = rng.Next(0, 4);
                while (curr.getNeighbor(neighbor)
            }
        }
    }
}
