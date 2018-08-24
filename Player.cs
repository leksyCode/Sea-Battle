using System;

namespace Sea_Wars
{
    class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }

        private int currentBoats = 0;
        private string message = null;

        public Player(string name)
        {
            Name = name;
            Health = 20;
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

                GameEngine.ShowInfo(stage, message);
                message = null;

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
                        GameEngine.DrawPlayerMap();
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
                        if (!fixSharp)
                        {
                            Console.SetCursorPosition(currentCell_X, currentCell_Y);
                            Console.Write('.');
                        }
                        GameEngine.DrawPlayerMap();
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
                        if (!fixSharp)
                        {
                            Console.SetCursorPosition(currentCell_X, currentCell_Y);
                            Console.Write('.');
                        }
                        GameEngine.DrawPlayerMap();
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
                        if (!fixSharp)
                        {
                            Console.SetCursorPosition(currentCell_X, currentCell_Y);
                            Console.Write('.');
                        }
                        GameEngine.DrawPlayerMap();
                        currentCell_Y++;
                        Console.SetCursorPosition(currentCell_X, currentCell_Y);
                        Console.Write("@");
                        fixSharp = false;
                    }
                }
                else if (direction == ConsoleKey.Enter)
                {
                    ConsoleKey location = 0;
                    if (stage != 1)
                    {
                        location = Console.ReadKey(true).Key;
                    }

                    SetShip(stage, currentCell_X, currentCell_Y, location);
                    fixSharp = true;
                    GameEngine.DrawPlayerMap();
                }
            }
        }

        private void SetShip(int deck, int x, int y, ConsoleKey location)
        {
            int canSetRight = 0, canSetLeft = 0, canSetUp = 0, canSetDown = 0;

            if (location == ConsoleKey.RightArrow || location == ConsoleKey.D)
            {
                for (int i = 0; i < deck; i++)
                {
                    if (CheckBesideCell(x + (i * 2), y))
                    {
                        canSetRight++;
                    }
                }
            }
            else if (location == ConsoleKey.LeftArrow || location == ConsoleKey.A)
            {
                for (int i = 0; i < deck; i++)
                {
                    if (CheckBesideCell(x - (i * 2), y))
                    {
                        canSetLeft++;
                    }
                }
            }
            else if (location == ConsoleKey.UpArrow || location == ConsoleKey.W)
            {
                for (int i = 0; i < deck; i++)
                {
                    if (CheckBesideCell(x, y - i))
                    {
                        canSetUp++;
                    }
                }
            }
            else if (location == ConsoleKey.DownArrow || location == ConsoleKey.S)
            {
                for (int i = 0; i < deck; i++)
                {
                    if (CheckBesideCell(x, y + i))
                    {
                        canSetDown++;
                    }
                }
            }


            try
            {
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
                else if (canSetUp == deck)
                {
                    for (int i = 0; i < deck; i++)
                    {
                        Console.SetCursorPosition(x, y - i);
                        Console.Write('#');
                        Board.PlayerField[y - i] = Program.ChengeSymb(x, Board.PlayerField[y - i], '#');
                        currentBoats++;
                    }
                }
                else if (canSetDown == deck)
                {
                    for (int i = 0; i < deck; i++)
                    {
                        Console.SetCursorPosition(x, y + i);
                        Console.Write('#');
                        Board.PlayerField[y + i] = Program.ChengeSymb(x, Board.PlayerField[y + i], '#');
                        currentBoats++;
                    }
                }
                else if (location == 0)
                {
                    if (CheckBesideCell(x, y))
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write('#');
                        Board.PlayerField[y] = Program.ChengeSymb(x, Board.PlayerField[y], '#');
                        currentBoats++;
                    }
                    else
                    {
                        message = "U can't create a ship here \n";
                        return;
                    }
                }
                else
                {
                    message = "U can't create a ship in this direction \n";
                    return;
                }
            }
            catch (Exception)
            {
                message = "U can't create a ship in this direction \n";
                return;
            }
        }



        private bool CheckBesideCell(int x, int y)
        {
            try
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
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        int currentCell_X = 32, currentCell_Y = 1;
        public int MakeStep(int enemyHealth)
        {
            
            bool fixSharp = false;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(currentCell_X, currentCell_Y);
            Console.Write("@");
            message = "Choose enemy cell and tap Enter";


            bool choice = false;

            while (!choice)
            {
                
                GameEngine.ShowInfo(0, message);
                message = null;

                ConsoleKey direction = Console.ReadKey(true).Key;

                if (direction == ConsoleKey.LeftArrow || direction == ConsoleKey.A)
                {
                    if (currentCell_X > 32)
                    {                   
                        if (!fixSharp)
                        {
                            Console.SetCursorPosition(currentCell_X, currentCell_Y);
                            Console.Write('.');
                        }
                        GameEngine.DrawHiddenEnemyMap();
                        currentCell_X -= 2;
                        Console.SetCursorPosition(currentCell_X, currentCell_Y);
                        Console.Write("@");
                        fixSharp = false;
                    }
                }
                else if (direction == ConsoleKey.RightArrow || direction == ConsoleKey.D)
                {
                    if (currentCell_X < 50)
                    {
                        if (!fixSharp)
                        {
                            Console.SetCursorPosition(currentCell_X, currentCell_Y);
                            Console.Write('.');
                        }
                        GameEngine.DrawHiddenEnemyMap();
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
                        if (!fixSharp)
                        {
                            Console.SetCursorPosition(currentCell_X, currentCell_Y);
                            Console.Write('.');
                        }
                        GameEngine.DrawHiddenEnemyMap();
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
                        if (!fixSharp)
                        {
                            Console.SetCursorPosition(currentCell_X, currentCell_Y);
                            Console.Write('.');
                        }
                        GameEngine.DrawHiddenEnemyMap();
                        currentCell_Y++;
                        Console.SetCursorPosition(currentCell_X, currentCell_Y);
                        Console.Write("@");
                        fixSharp = false;
                    }
                }
                else if (direction == ConsoleKey.Enter)
                {
                    
                    if (Board.EnemyField[currentCell_Y][currentCell_X - 30] == '#' && Board.EmtyField[currentCell_Y][currentCell_X - 30] != 'X')
                    {
                        Board.EmtyField[currentCell_Y] = Program.ChengeSymb(currentCell_X - 30, Board.EmtyField[currentCell_Y], 'X');
                        enemyHealth--;                        
                        choice = true;
                    }
                    else if (Board.EmtyField[currentCell_Y][currentCell_X - 30] != '*' && Board.EnemyField[currentCell_Y][currentCell_X - 30] == '.')
                    {
                        Board.EmtyField[currentCell_Y] = Program.ChengeSymb(currentCell_X - 30, Board.EmtyField[currentCell_Y], '*');
                        choice = true;
                    }
                    else
                    {
                        choice = false;
                        message = "U were already been on this cell";                       
                    }
                }
            }
            return enemyHealth;
        }
    }

}
