using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class MazeUI
    {
        private static Maze maze;
        private static List<String> corridors;
        private static bool playing;

        static void Main()
        {
            corridors = new List<string>();
            explore();
        }

        private static void explore()
        {
            playing = true;

            while (playing)
            {
                maze = new Maze();
                Console.WriteLine("Oh no! An evil wizard has trapped you in a maze.\r\nYou must escape!");
                bool escaped = false;

                while (escaped == false)
                {
                    corridors = maze.getCorridors();
                    switch (corridors.Count)
                    {
                        case 1:
                            Console.WriteLine("You are at a dead end. Will you go back?");
                            break;
                        case 2:
                            Console.WriteLine("You are in a corridor leading "+corridors.ElementAt(0)+" and "+corridors.ElementAt(1)+".\r\nWhich way will you go?");
                            break;
                        case 3:
                            Console.WriteLine("You are in a room with corridors leading " + corridors.ElementAt(0) + ", " + corridors.ElementAt(1) + ", and " + corridors.ElementAt(2) + ".\r\nWhich way will you go?");
                            break;
                        case 4:
                            Console.WriteLine("You are in a room with corridors leading " + corridors.ElementAt(0) + ", " + corridors.ElementAt(1) + corridors.ElementAt(2) + ", and " + corridors.ElementAt(3) + ".\r\nWhich way will you go?");
                            break;
                    }

                    String input = Console.ReadLine().ToLower();

                    if (((input != "forward") && (input != "right") && (input != "back") && (input != "left") && (input != "yes") && (input != "no")) || (((input == "yes") || (input == "no")) && (corridors.Count != 1)))
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                    }

                    else if (input == "yes")
                    {
                        maze.move(2);
                    }

                    else if (input == "no")
                    {
                        Console.WriteLine("Well, enjoy yourself.");
                    }

                    else if (!corridors.Contains(input))
                    {
                        Console.WriteLine("You can't go that way. Please try again.");
                    }

                    else
                    {
                        switch (input)
                        {
                            case "forward":
                                maze.move(0);
                                escaped = maze.escaped();
                                break;
                            case "right":
                                maze.move(1);
                                escaped = maze.escaped();
                                break;
                            case "back":
                                maze.move(2);
                                escaped = maze.escaped();
                                break;
                            case "left":
                                maze.move(3);
                                escaped = maze.escaped();
                                break;
                        }
                    }
                }

                Console.WriteLine("You have finally escaped!\r\nAs your eyes adjust to the light of day, you begin to make out a figure.");
                Console.WriteLine("Oh no! It's the evil wizard.\r\nHe calls down a mighty thunderbolt and you are reduced to ash in an instant.\r\nToo bad!");
                Console.WriteLine("Play again?");
                String playInput = "";
                while (playInput!="yes"&&playInput!="no")
                {
                    playInput = Console.ReadLine().ToLower();
                    if (playInput == "yes")
                        playing = true;
                    else if (playInput == "no")
                        playing = false;
                    else
                        Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
    }
}
