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

        private int currentBoats = 0;
        private bool verticall = false;

        public Player(string name)
        {
            Name = name;
        }

        public void CreatingPlayerMap()
        {
            int currentCell_X = 2, currentCell_Y = 1;
            bool fixSharp = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(currentCell_X, currentCell_Y);
            Console.Write("@");


            int stage = 4;

            while (currentBoats <= 19)
            {
                if (currentBoats >= 4 && currentBoats < 10)
                    stage = 3;
                else if (currentBoats >= 10 && currentBoats < 16)
                    stage = 2;
                else if (currentBoats >= 16)
                    stage = 1;


                GameEngine.ShowInfo(stage);

                ConsoleKey direction = Console.ReadKey(true).Key;

                if (direction == ConsoleKey.LeftArrow || direction == ConsoleKey.A)
                {
                    if (currentCell_X > 2)
                    {
                        GameEngine.DrawPlayerMap();
                        if (!fixSharp)
                        {
                            Console.SetCursorPosition(currentCell_X, currentCell_Y);
                            Console.Write('.');
                        }
                        currentCell_X -= 2;
                        Console.SetCursorPosition(currentCell_X, currentCell_Y);
                        Console.Write("@");
                        fixSharp = false;
                    }

                }
                else if (direction == ConsoleKey.RightArrow || direction == ConsoleKey.D)
                {
                    if (currentCell_X < 20)
                    {
                        GameEngine.DrawPlayerMap();
                        if (!fixSharp)
                        {
                            Console.SetCursorPosition(currentCell_X, currentCell_Y);
                            Console.Write('.');
                        }
                        currentCell_X += 2;
                        Console.SetCursorPosition(currentCell_X, currentCell_Y);
                        Console.Write("@");
                        fixSharp = false;
                    }

                }
                else if (direction == ConsoleKey.UpArrow || direction == ConsoleKey.W)
                {
                    if (currentCell_Y > 1)
                    {
                        GameEngine.DrawPlayerMap();
                        if (!fixSharp)
                        {
                            Console.SetCursorPosition(currentCell_X, currentCell_Y);
                            Console.Write('.');
                        }
                        currentCell_Y--;
                        Console.SetCursorPosition(currentCell_X, currentCell_Y);
                        Console.Write("@");
                        fixSharp = false;
                    }
                }
                else if (direction == ConsoleKey.DownArrow || direction == ConsoleKey.S)
                {
                    if (currentCell_Y < 9)
                    {
                        GameEngine.DrawPlayerMap();
                        if (!fixSharp)
                        {
                            Console.SetCursorPosition(currentCell_X, currentCell_Y);
                            Console.Write('.');
                        }
                        currentCell_Y++;
                        Console.SetCursorPosition(currentCell_X, currentCell_Y);
                        Console.Write("@");
                        fixSharp = false;
                    }
                }
                else if (direction == ConsoleKey.Enter)
                {
                    fixSharp = true;
                    SetShip(stage, currentCell_X, currentCell_Y, false);

                }
            }
        }

        public void SetShip(int deck, int x, int y, bool verticall)
        {
            int canSetRight = 0, canSetLeft = 0;
            bool locationRight = false, locationUp = false;

            if (x < (Board.width / 2) + 2)
            {
                locationRight = true;
            }
            if (y > (9 / 2))
            {
                locationUp = true;
            }


            if (locationRight == true)
            {
                for (int i = 0; i < deck; i++)
                {
                    if (CheckBesideCell(x + (i * 2), y))
                    {
                        canSetRight++;
                    }
                }
            }
            else if (locationRight == false)
            {
                for (int i = 0; i < deck; i++)
                {
                    if (CheckBesideCell(x - (i * 2), y))
                    {
                        canSetLeft++;
                    }
                }
            }

            if (canSetRight == deck)
            {
                for (int i = 0; i < deck; i++)
                {
                    Console.SetCursorPosition(x + (i * 2), y);
                    Console.Write('#');
                    Board.PlayerField[y] = Program.ChengeSymb(x + (i * 2), Board.PlayerField[y], '#');
                    currentBoats++;
                }
            }
            else if (canSetLeft == deck)
            {
                for (int i = 0; i < deck; i++)
                {
                    Console.SetCursorPosition(x - (i * 2), y);
                    Console.Write('#');
                    Board.PlayerField[y] = Program.ChengeSymb(x - (i * 2), Board.PlayerField[y], '#');
                    currentBoats++;
                }
            }
            else
            {
                return;
            }

        }



        public bool CheckBesideCell(int x, int y)
        {
            if (Board.PlayerField[y][x] == '#')
            {
                return false;
            }
            else if (Board.PlayerField[y + 1][x] == '#' || Board.PlayerField[y - 1][x] == '#')
            {
                return false;
            }
            else if (Board.PlayerField[y][x - 2] == '#' || Board.PlayerField[y][x + 2] == '#')
            {
                return false;
            }
            else if (Board.PlayerField[y + 1][x - 2] == '#' || Board.PlayerField[y + 1][x + 2] == '#')
            {
                return false;
            }
            else if (Board.PlayerField[y - 1][x - 2] == '#' || Board.PlayerField[y - 1][x + 2] == '#')
            {
                return false;
            }
            return true;
        }

    }
}
