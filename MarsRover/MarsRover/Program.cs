using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        // x = l/r top rows y = up/down = left row
        static void Main(string[] args)
        {
            try
            {
                string[] rover = System.IO.File.ReadAllLines("Input.txt");
                string[] upperRightCo = rover.First().Split(' ');
                int uppery = Convert.ToInt32(upperRightCo[0]);
                int upperx = Convert.ToInt32(upperRightCo[1]);

                //do logic to throw if not int
                int numberOfRovers = (rover.Count() - 1) / 2;
                int roverPos = 1;
                for (int k = 0; k < numberOfRovers; k++)
                {



                    int roverposy = 0;
                    int roverposx = 0;
                    string roverDirection = "";


                    string[] roverdetails = rover[roverPos].Split(' ');
                    roverposx = Convert.ToInt32(roverdetails[0].ToString());
                    roverposy = Convert.ToInt32(roverdetails[1].ToString());
                    CheckInputInBounds(uppery, upperx, roverposy, roverposx);
                    roverDirection = roverdetails[2].ToString();

                    char[] roverMoves = rover[roverPos + 1].ToCharArray();


                    for (int i = 0; i < roverMoves.Length; i++)
                    {

                        if (roverMoves[i].ToString() == "R")
                        {
                            roverDirection = RoverDirection(roverDirection, "R");
                        }
                        else if (roverMoves[i].ToString() == "L")
                        {
                            roverDirection = RoverDirection(roverDirection, "L");
                        }
                        else if (roverMoves[i].ToString() == "M")
                        {
                            RoverMovemenets(uppery, upperx, ref roverposy, ref roverposx, roverDirection);
                        }
                    }

                    Console.WriteLine(roverposx.ToString() + " " + roverposy.ToString() + " " + roverDirection);
                    roverPos += 2;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        private static void CheckInputInBounds(int uppery, int upperx, int roverposy, int roverposx)
        {
            if (roverposx > upperx || roverposx < 0 || roverposy > uppery || roverposy < 0)
            {
                throw new Exception("Oh dear. Looks like the rover has fallen off the side of Mars and now is going to be scrap metal. Seriously though... The current position of The Rover is outside of the bounds.");
            }
        }

        private static string RoverDirection(string roverDirection, string direction)
        {
            if (direction == "R")
            {
                if (roverDirection == "N")
                {
                    roverDirection = "E";
                }
                else if (roverDirection == "E")
                {
                    roverDirection = "S";
                }
                else if (roverDirection == "S")
                {
                    roverDirection = "W";
                }
                else if (roverDirection == "W")
                {
                    roverDirection = "N";
                }
            }
            if (direction == "L")
            {
                if (roverDirection == "N")
                {
                    roverDirection = "W";
                }
                else if (roverDirection == "W")
                {
                    roverDirection = "S";
                }
                else if (roverDirection == "S")
                {
                    roverDirection = "E";
                }
                else if (roverDirection == "E")
                {
                    roverDirection = "N";
                }
            }
            return roverDirection;
        }

        private static void RoverMovemenets(int uppery, int upperx, ref int roverposy, ref int roverposx, string roverDirection)
        {
            if (roverDirection == "N")
            {
                if (roverposy + 1 > uppery)
                {
                    throw new Exception("The input does pass. The rover will fall over the side of Mars and disappear. This will be found and sold when I decide to give up on earth and rent a space ship. I'm pretty certain that a Mars Rover could be worth some real Moola in Space! :-) ");
                }
                else
                {
                    roverposy = roverposy + 1;
                }
            }
            else if (roverDirection == "S")
            {
                if (roverposy - 1 < 0)
                {
                    throw new Exception("The input does pass. The rover will fall over the side of Mars and disappear. This will be found and sold when I decide to give up on earth and rent a space ship. I'm pretty certain that a Mars Rover could be worth some real Moola in Space! :-) ");
                }
                else
                {
                    roverposy = roverposy - 1;
                }
            }
            else if (roverDirection == "W")
            {
                if (roverposx - 1 < 0)
                {
                    throw new Exception("The input does pass. The rover will fall over the side of Mars and disappear. This will be found and sold when I decide to give up on earth and rent a space ship. I'm pretty certain that a Mars Rover could be worth some real Moola in Space! :-) ");

                }
                else
                {
                    roverposx = roverposx - 1;
                }
            }
            else if (roverDirection == "E")
            {
                if (roverposx + 1 > upperx)
                {
                    throw new Exception("The input does pass. The rover will fall over the side of Mars and disappear. This will be found and sold when I decide to give up on earth and rent a space ship. I'm pretty certain that a Mars Rover could be worth some real Moola in Space! :-) ");
                
                }
                else
                {
                    roverposx = roverposx + 1;
                }
            }
        }
    }
}
