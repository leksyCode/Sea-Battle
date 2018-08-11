using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sea_Wars
{
    class Player
    {
        string Name { get; set; }
        int[] coordinatesX = new int[20], coordinatesY = new int[20];

        public Player(string name)
        {
            Name = name;
        }

        public void CreatingBoats()
        {
            int currentCell_X = 2, currentCell_Y = 1;
            bool fixSharp = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(currentCell_X, currentCell_Y);
            Console.Write("@");

            int currentBoats = 0;
            int stage = 0;

            while (currentBoats <= 19)
            {
                
                GameEngine.ShowInfo(currentBoats, stage);

                ConsoleKey direction = Console.ReadKey(true).Key;

                if (direction == ConsoleKey.LeftArrow || direction == ConsoleKey.A)
                {
                    if (currentCell_X > 2)
                    {
                        if (!fixSharp)
                        {
                            Console.SetCursorPosition(currentCell_X, currentCell_Y);
                            Console.Write('.');
                        }
                        currentCell_X -= 2;
                        Console.SetCursorPosition(currentCell_X, currentCell_Y);
                        Console.Write("@");
                        fixSharp = false;
                        stage = 0;
                    }

                }
                else if (direction == ConsoleKey.RightArrow || direction == ConsoleKey.D)
                {
                    if (currentCell_X < 20)
                    {
                        if (!fixSharp)
                        {
                            Console.SetCursorPosition(currentCell_X, currentCell_Y);
                            Console.Write('.');
                        }
                        currentCell_X += 2;
                        Console.SetCursorPosition(currentCell_X, currentCell_Y);
                        Console.Write("@");
                    }
                    fixSharp = false;
                    stage = 0;
                }
                else if (direction == ConsoleKey.UpArrow || direction == ConsoleKey.W)
                {
                    if (currentCell_Y > 1)
                    {
                        if (!fixSharp)
                        {
                            Console.SetCursorPosition(currentCell_X, currentCell_Y);
                            Console.Write('.');
                        }
                        currentCell_Y--;
                        Console.SetCursorPosition(currentCell_X, currentCell_Y);
                        Console.Write("@");
                    }
                    fixSharp = false;
                    stage = 0;
                }
                else if (direction == ConsoleKey.DownArrow || direction == ConsoleKey.S)
                {
                    if (currentCell_Y < 9)
                    {
                        if (!fixSharp)
                        {
                            Console.SetCursorPosition(currentCell_X, currentCell_Y);
                            Console.Write('.');
                        }
                        currentCell_Y++;
                        Console.SetCursorPosition(currentCell_X, currentCell_Y);
                        Console.Write("@");
                    }
                    fixSharp = false;
                    stage = 0;
                }
                else if (direction == ConsoleKey.Enter)
                {
                        if (CheckBesideCell(currentCell_X, currentCell_Y, currentBoats, out int phaze))
                        {

                        stage = phaze;                        
                        continue;
                        }                        
                    fixSharp = true;
                    Console.SetCursorPosition(currentCell_X, currentCell_Y);
                    Console.Write('#');
                    coordinatesX[currentBoats] = currentCell_X;
                    coordinatesY[currentBoats] = currentCell_Y;
                    Board.PlayerField[coordinatesY[currentBoats]] = Program.ChengeSymb(coordinatesX[currentBoats], Board.PlayerField[coordinatesY[currentBoats]], '#');
                    currentBoats++;
                    GameEngine.DrawPlayerMap();
                }
            }
        }


        public bool CheckBesideCell(int x, int y, int countShips, out int phaze)
        {
                phaze = 4;
                try
                {
                    if (Board.PlayerField[y][x] == '#')
                    {
                        return true;
                    }
                    else if (Board.PlayerField[y + 1][x] == '#' || Board.PlayerField[y - 1][x] == '#')
                    {
                        return true;
                    }
                    else if (Board.PlayerField[y][x - 2] == '#' || Board.PlayerField[y][x + 2] == '#')
                    {
                        return true;
                    }
                    else if (Board.PlayerField[y + 1][x - 2] == '#' || Board.PlayerField[y + 1][x + 2] == '#')
                    {
                        return true;
                    }
                    else if (Board.PlayerField[y - 1][x - 2] == '#' || Board.PlayerField[y - 1][x + 2] == '#')
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    phaze = 4;
                    if (Board.PlayerField[y][x - 2] == '#' || Board.PlayerField[y + 1][x - 2] == '#')
                    {
                        return true;
                    }
                    else if (Board.PlayerField[y - 1][x - 2] == '#')
                    {
                        return true;
                    }
                }
            
            
            return false;

        }
       
    }
}
