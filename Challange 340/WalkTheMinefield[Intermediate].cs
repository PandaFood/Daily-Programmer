using System;
using System.Text.RegularExpressions;

namespace Challenge_340
{
    class WalkTheMinefield
    {

        static string minefield, robotInstruction;
        static int width, robotPosition;
        static bool started, victory, dead = false;


        static void Main(string[] args)
        {
            minefield = args[0];
            robotInstruction = args[1];
            width = GetMinefieldWidth(minefield);
            robotPosition = Regex.Match(minefield, @"M").Index;

            do
            {
                Console.Clear();
                Console.WriteLine("ESCAPE THE MINEFIELD!");
                Console.WriteLine("Instructions: " + robotInstruction);

                char instruction = robotInstruction[0];
                robotInstruction = robotInstruction.Remove(0, 1);


                if (started && instruction != '-')
                    Walk(robotPosition, instruction);
                else if (instruction == 'I')
                    started = true;
                else if (started && instruction == '-')
                    if ((robotPosition + 1) % width == 0)
                    {
                        victory = true;
                    }
                    else
                        started = false;

                for (int i = 0; i < minefield.Length / width; i++)
                {
                    Console.WriteLine(minefield.Substring(i * width, width));
                }
                System.Threading.Thread.Sleep(500);
            } while (robotInstruction.Length > 0 && !victory && !dead);


            if (victory) {
                Console.WriteLine("YOU WON!");
            }
            else if (dead) {
                Console.WriteLine("You died at position: " + robotPosition);
            }
            else
            {
                Console.WriteLine("No more instructions.");
            }
                Console.ReadKey();
        }

        private static int GetMinefieldWidth(string s)
        {
            int i = 0;
            while (s[i] == '+')
                i++;

            return i - 1;
        }

        private static void Walk(int start, char direction)
        {
            char[] field = minefield.ToCharArray();
            int nextPos = start;
            char route = '-';

            switch (direction)
            {
                case 'N':             //Up
                    nextPos = start - width;
                    route = '|';
                    break;
                case 'E':             //Right
                    nextPos = start + 1;
                    route = '-';
                    break;
                case 'S':             //Down
                    nextPos = start + width;
                    route = '|';
                    break;
                case 'O':             //Left
                    nextPos = start - 1;
                    route = '-';
                    break;         
            }


            if (ValidMove(nextPos))
            {
                field[nextPos] = 'M';
                field[start] = route;
                robotPosition = nextPos;

                minefield = new string(field);
            }
            else
                return;

            
        }

        private static bool ValidMove(int position)
        {
            if (minefield[position] == '*')
            {
                dead = true;
                return false;
            }
            else if (minefield[position] == '+')
                return false;
            else
                return true;
        }
    }

}
