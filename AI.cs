using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sea_Wars
{
    class AI
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public AI(string name)
        {
            Name = name;
            Health = 20;
        }

        public void CreatingAIMapAlgorithm()
        {
            Random rand = new Random();
            int typeOfBoats = 4;

            while (typeOfBoats != 0)           
            {
                bool buildSuccessful = true;
                for (int k = 0; k < (5 - typeOfBoats); k++)  // Change count of type of ships on each iteration
                {
                   // random
                    bool verticall = Convert.ToBoolean(rand.Next(0, 2));
                    int randX = rand.Next(2, Board.width);
                    int randY = rand.Next(1, Board.EnemyField.Length - 1);
                    while (randX % 2 != 0)
                    {
                        randX = rand.Next(2, Board.width);
                    }

                    int dir = 0; //1 - left, 2 - right, 3 - up, 4 - down

                    if (verticall == false && randX >= 10) // horizontal
                    {
                        for (int i = 0; i < typeOfBoats; i++) 
                        {
                            dir = 1;
                            if (CheckBesideCell(randX - (i * 2), randY, dir) == false)
                            {
                                Board.EnemyField[randY] = Program.ChengeSymb(randX - (i * 2), Board.EnemyField[randY], '#');
                                buildSuccessful = true;
                            }
                            else 
                            {                               
                                DeleteUnfinishedBoats(dir, i, randX - (i * 2), randY);
                                buildSuccessful = false;
                                break;
                            }

                        }
                    }
                    else if (verticall == false && randX < 10)
                    {
                        for (int i = 0; i < typeOfBoats; i++)
                        {
                            dir = 2;
                            if (CheckBesideCell(randX + (i * 2), randY, dir) == false)
                            {
                                Board.EnemyField[randY] = Program.ChengeSymb(randX + (i * 2), Board.EnemyField[randY], '#');
                                buildSuccessful = true;
                            }
                            else
                            {
                                DeleteUnfinishedBoats(dir, i, randX + (i * 2), randY);
                                buildSuccessful = false;
                                break;
                            }
                        }
                    }
                    else if (verticall == true && randY >= 4) // verticall
                    {
                        for (int i = 0; i < typeOfBoats; i++)
                        {
                            dir = 3;
                            if (CheckBesideCell(randX, randY - i, dir) == false)
                            {
                                Board.EnemyField[randY - i] = Program.ChengeSymb(randX, Board.EnemyField[randY - i], '#');
                                buildSuccessful = true;
                            }
                            else
                            {
                                DeleteUnfinishedBoats(dir, i, randX, randY - i);
                                buildSuccessful = false;
                                break;
                            }
                        }
                    }
                    else if (verticall == true && randY < 4)
                    {
                        for (int i = 0; i < typeOfBoats; i++)
                        {
                            dir = 4;
                            if (CheckBesideCell(randX, randY + i, dir) == false)
                            {
                                Board.EnemyField[randY + i] = Program.ChengeSymb(randX, Board.EnemyField[randY + i], '#');  
                                buildSuccessful = true;
                            }
                            else
                            {
                                DeleteUnfinishedBoats(dir, i, randX, randY + i);
                                buildSuccessful = false;
                                break;
                            }
                        }
                    }
                    if (!buildSuccessful)
                    {
                        k--;
                    }
                }
                if (buildSuccessful)
                {
                    typeOfBoats--; // change type
                }
            }           
        }

        private void DeleteUnfinishedBoats(int dir, int i, int x, int y)
        {
            for (int j = 0; j < i; j++) // delete unfinished boat
            {
                switch (dir)
                {
                    case 1:
                        Board.EnemyField[y] = Program.ChengeSymb(x + (i * 2), Board.EnemyField[y], '.'); break;
                    case 2:
                        Board.EnemyField[y] = Program.ChengeSymb(x - (i * 2), Board.EnemyField[y], '.'); break;
                    case 3:
                        Board.EnemyField[y + i] = Program.ChengeSymb(x, Board.EnemyField[y + i], '.'); break;
                    case 4:
                        Board.EnemyField[y - i] = Program.ChengeSymb(x, Board.EnemyField[y - i], '.'); break;
                    default:
                        break;
                }
            }
        }

        private static bool CheckBesideCell(int x, int y, int dir)
        {
            if (Board.EnemyField[y][x] == '#')
            {
                return true;
            }
            else if (Board.EnemyField[y + 1][x] == '#' && dir != 3)
            {
                return true;
            }
            else if (Board.EnemyField[y - 1][x] == '#' && dir != 4)
            {
                return true;
            }
            else if (Board.EnemyField[y][x - 2] == '#' && dir != 2)
            {
                return true;
            }
            else if (Board.EnemyField[y][x + 2] == '#' && dir != 1)
            {
                return true;
            }
            else if (Board.EnemyField[y + 1][x - 2] == '#' || Board.EnemyField[y + 1][x + 2] == '#')
            {
                return true;
            }
            else if (Board.EnemyField[y - 1][x - 2] == '#' || Board.EnemyField[y - 1][x + 2] == '#')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        int i = 0;
        public int MakeStep(int playerHealth)
        {
            
            Console.SetCursorPosition(0, 13);
            Console.WriteLine($"Steps: { i }, Player Health: {playerHealth},  EnemyHEalth: {Health}.");
            i++;
            return playerHealth;
        }
    }
}


