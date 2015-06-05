using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Maze
    {
        Room room;
        Random rng;
        int exitChance;
        int unvisitedCount;
        bool exitFound;

        public Maze()
        {
            room = new Room(false);
            rng = new Random();
            exitChance = 0;
            unvisitedCount = 0;
            exitFound = false;
            int rooms = rng.Next(1, 4);
            createCorridors(room,rooms);
        }

        private void createCorridors(Room room, int rooms)
        {
            for (int i = 0; i<rooms; i++)
            {
                int pos = rng.Next(0, 3);

                while (room.getChild(pos)!=null)
                {
                    pos = rng.Next(0, 3);
                }

                if (!exitFound)
                {
                    bool isExit = (rng.Next(0, 101) + exitChance) >= 100;
                    room.addChild(new Room(isExit), pos);
                    if (isExit)
                        exitFound = isExit;
                }

                else
                {
                    room.addChild(new Room(false), pos);
                }
            }

            unvisitedCount = unvisitedCount + rooms;
            if (!exitFound)
                exitChance = exitChance + 5;
        }
    }
}
