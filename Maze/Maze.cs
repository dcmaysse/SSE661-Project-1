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
        Room currRoom;
        Random rng;
        int sizeX,sizeY;
        int facing;

        public Maze(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            rooms = new Room[sizeX,sizeY];
            rng = new Random();
            createMaze();
            carveMaze();
            currRoom = rooms[rng.Next(0, sizeX), rng.Next(0, sizeY)];
            setExit();
            int tempFacing = 0;
            int wallCount = 0;
            for (int i = 0; i < 4; i++)
            {
                if (currRoom.isWall(i))
                    wallCount++;
                else
                    tempFacing = i;
            }
            if (wallCount == 3)
                facing = tempFacing;
            else
                facing = 2;
        }

        private void createMaze()
        {
            for (int i=0; i < sizeX; i++)
            {
                for (int j=0; j < sizeY; j++)
                {
                    rooms[i, j] = new Room(i, j);
                }
            }

            for (int i = 0; i < sizeX - 1; i++)
            {
                for (int j = 0; j < sizeY - 1; j++)
                {
                    rooms[i, j].addNeighbor(rooms[i + 1, j], 1);
                    rooms[i + 1, j].addNeighbor(rooms[i, j], 3);
                    rooms[i, j].addNeighbor(rooms[i, j + 1], 2);
                    rooms[i, j + 1].addNeighbor(rooms[i, j], 0);
                }
                rooms[i, sizeY - 1].addNeighbor(rooms[i + 1, sizeY - 1], 1);
                rooms[i + 1, sizeY - 1].addNeighbor(rooms[i, sizeY - 1], 3);
                rooms[sizeX - 1, i].addNeighbor(rooms[sizeX - 1, i + 1], 2);
                rooms[sizeX - 1, i + 1].addNeighbor(rooms[sizeX - 1, i], 0);
            }
        }

        private void carveMaze()
        {
            List<Room> temp = new List<Room>();
            temp.Add(rooms[rng.Next(0, sizeX), rng.Next(0, sizeY)]);
            Room curr;
            int neighborDir,currIndex;
            int[] disqualified;

            while (temp.Count>0)
            {
                currIndex = rng.Next((temp.Count) / 2, temp.Count);
                curr = temp.ElementAt(currIndex);
                neighborDir = rng.Next(0, 4);
                disqualified =new int[] { 0, 0, 0, 0 };

                while (((curr.getX()==0&&neighborDir==3)||(curr.getX()==(sizeX-1)&&neighborDir==1)||(curr.getY()==0&&neighborDir==0)||(curr.getY()==(sizeY-1)&&neighborDir==2))
                    ||(curr.getNeighbor(neighborDir).getVisited())
                    &&(disqualified.Sum()!=4))
                {
                    disqualified[neighborDir] = 1;
                    neighborDir = rng.Next(0, 4);
                }

                if (disqualified.Sum()==4)
                {
                    temp.RemoveAt(currIndex);
                }
                else
                {
                    curr.carveWall(neighborDir);
                    curr.getNeighbor(neighborDir).carveWall((neighborDir + 2) % 4);
                    temp.Add(curr.getNeighbor(neighborDir));
                    temp.ElementAt(temp.Count - 1).setVisited();
                }
            }
        }

        private void setExit()
        {
            List<Room> temp=new List<Room>();

            if (sizeX == 1 && sizeY==1)
                rooms[0, 0].setExit();
            else
            { 
                for (int i = 1; i < sizeX - 1; i++)
                {
                    temp.Add(rooms[i, 0]);
                    temp.Add(rooms[i, sizeX - 1]);
                }

                for (int i = 1; i < sizeY - 1; i++)
                {
                    temp.Add(rooms[0, i]);
                    temp.Add(rooms[sizeY - 1, i]);
                }

                temp.Add(rooms[0, 0]);
                temp.Add(rooms[sizeX - 1, 0]);
                temp.Add(rooms[0, sizeY - 1]);
                temp.Add(rooms[sizeX - 1, sizeY - 1]);
                int exitIndex = rng.Next(0, temp.Count);
                while ((currRoom.getX()==temp.ElementAt(exitIndex).getX())&&(currRoom.getY() == temp.ElementAt(exitIndex).getY()))
                    exitIndex = rng.Next(0, temp.Count);
                temp.ElementAt(rng.Next(0, temp.Count)).setExit();
            }
        }

        public void setSizeX(int size)
        {
            sizeX = size;
        }

        public void setSizeY(int size)
        {
            sizeY = size;
        }

        public void move(int dir)
        {
            currRoom=currRoom.getNeighbor((facing + dir) % 4);
            facing= (facing + dir) % 4;
        }

        public List<String> getCorridors()
        {
            List<String> corridors = new List<String>();
            for (int i = 0; i < 4; i++)
            {
                if (!(currRoom.isWall(i)))
                {
                    switch ((((i-facing)%4)+4) % 4)
                    {
                        case 0:
                            corridors.Add("forward");
                            break;
                        case 1:
                            corridors.Add("right");
                            break;
                        case 2:
                            corridors.Add("back");
                            break;
                        case 3:
                            corridors.Add("left");
                            break;
                    }
                }
            }
            return corridors;
        }

        public bool escaped()
        {
            if (currRoom.isExit())
                return true;
            else
                return false;
        }
    }
}
