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
                int XVal = -1;
                while (XVal==-1)
                {
                    Console.Write("Welcome to the Maze!\r\nPlease enter a width for the maze.\r\n>> ");
                    string inputX = Console.ReadLine();
                    try
                    {
                        XVal = Convert.ToInt32(inputX);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\r\nInvalid input. Please try again.\r\n");
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine("\r\nNumber too large. Please try again.\r\n");
                    }
                }

                int YVal = -1;
                while (YVal == -1)
                {
                    Console.Write("\r\nPlease enter a height for the maze.\r\n>> ");
                    string inputY = Console.ReadLine();
                    try
                    {
                        YVal = Convert.ToInt32(inputY);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\r\nInvalid input. Please try again.\r\n");
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine("\r\nNumber too large. Please try again.\r\n");
                    }
                }

                maze = new Maze(XVal, YVal);
                Console.WriteLine("\r\nOh no! An evil wizard has trapped you in a maze.\r\nYou must escape!\r\n");
                bool escaped = false;

                while (escaped == false)
                {
                    corridors = maze.getCorridors();
                    switch (corridors.Count)
                    {
                        case 1:
                            Console.Write("\r\nYou arrive at a dead end. Will you go back?\r\n>> ");
                            break;
                        case 2:
                            Console.Write("\r\nYou progress through the corridors of the maze. You can go " + corridors.ElementAt(0)+" or "+corridors.ElementAt(1)+ ".\r\nWhich way will you go?\r\n>> ");
                            break;
                        case 3:
                            Console.Write("\r\nYou arrive in a room with corridors leading " + corridors.ElementAt(0) + ", " + corridors.ElementAt(1) + ", and " + corridors.ElementAt(2) + ".\r\nWhich way will you go?\r\n>> ");
                            break;
                        case 4:
                            Console.Write("\r\nYou arrive in a room with corridors leading " + corridors.ElementAt(0) + ", " + corridors.ElementAt(1) + ", " + corridors.ElementAt(2) + ", and " + corridors.ElementAt(3) + ".\r\nWhich way will you go?\r\n>> ");
                            break;
                    }

                    String input = Console.ReadLine().ToLower();

                    if (((input != "forward") && (input != "right") && (input != "back") && (input != "left") && (input != "yes") && (input != "no")) || (((input == "yes") || (input == "no")) && (corridors.Count != 1)))
                    {
                        Console.WriteLine("\r\nInvalid input. Please try again.\r\n");
                    }

                    else if (input == "yes")
                    {
                        switch (corridors.ElementAt(0))
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

                    else if (input == "no")
                    {
                        Console.WriteLine("\r\nWell, enjoy yourself.\r\n");
                    }

                    else if (!corridors.Contains(input))
                    {
                        Console.WriteLine("\r\nYou can't go that way. Please try again.\r\n");
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

                Console.WriteLine("\r\nAs you walk down the long corridor, you begin to see a small light.\r\nYou rush headlong toward it and finally emerge from the dungeon into the outside world. You have escaped!\r\nAs your eyes adjust to the light of day, you begin to make out a figure.");
                Console.WriteLine("Oh no! It's the evil wizard.\r\nHe calls down a mighty thunderbolt and you are reduced to ash in an instant.\r\nToo bad!\r\n");
                Console.Write("\r\nPlay again?\r\n>> ");
                String playInput = "";
                while (playInput!="yes"&&playInput!="no")
                {
                    playInput = Console.ReadLine().ToLower();
                    if (playInput == "yes")
                        playing = true;
                    else if (playInput == "no")
                        playing = false;
                    else
                        Console.WriteLine("\r\nInvalid input. Please try again.\r\n");
                }
            }
        }
    }
}
