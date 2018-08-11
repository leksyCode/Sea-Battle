using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sea_Wars
{
    class AI
    {
        public AI () { }

        public void CreatingAIMapAlgorithm()
        {
            Random rand = new Random();
            int typeOfBoats = 4;
          
          
            while (typeOfBoats != 0)
            {
                for (int k = 0; k < (5 - typeOfBoats); k++)
                {

                    bool verticall = Convert.ToBoolean(rand.Next(0, 2));
                    int randX = rand.Next(2, Board.width);
                    int randY = rand.Next(1, Board.EnemyField.Length - 1);
                    while (randX % 2 != 0)
                    {
                        randX = rand.Next(2, Board.width);
                    }

                    if (verticall == false && randX >= 10) // horizontal
                    {
                        for (int i = 0; i < typeOfBoats; i++)
                        {
                            if (CheckBesideCell(randX - (i * 2), randY) == false)
                            {
                                Board.EnemyField[randY] = Program.ChengeSymb(randX - (i * 2), Board.EnemyField[randY], '#');
                            }
                            else 
                            {
                                Board.EnemyField[randY] = Program.ChengeSymb(randX + (i * 2), Board.EnemyField[randY], '#');
                            }
                           
                            GameEngine.DrawEnemyMap();
                            Thread.Sleep(500);
                        }
                    }
                    else if (verticall == false && randX < 10)
                    {
                        for (int i = 0; i < typeOfBoats; i++)
                        {
                            if (CheckBesideCell(randX + (i * 2), randY) == false)
                            {
                                Board.EnemyField[randY] = Program.ChengeSymb(randX + (i * 2), Board.EnemyField[randY], '#');
                            }
                            else 
                            {
                                Board.EnemyField[randY] = Program.ChengeSymb(randX - (i * 2), Board.EnemyField[randY], '#');
                            }
                            GameEngine.DrawEnemyMap();
                            Thread.Sleep(500);
                        }
                    }
                    else if (verticall == true && randY >= 4) // verticall
                    {
                       

                        for (int i = 0; i < typeOfBoats; i++)
                        {
                            if (CheckBesideCell(randX, randY - i) == false)
                            {
                                Board.EnemyField[randY - i] = Program.ChengeSymb(randX, Board.EnemyField[randY - i], '#');
                            }
                            else 
                            {
                                Board.EnemyField[randY + i] = Program.ChengeSymb(randX, Board.EnemyField[randY + i], '#');
                            }
                            GameEngine.DrawEnemyMap();
                            Thread.Sleep(500);
                        }
                    }
                    else if (verticall == true && randY < 4)
                    {
                        for (int i = 0; i < typeOfBoats; i++)
                        {
                            if (CheckBesideCell(randX, randY + i) == false)
                            {
                                Board.EnemyField[randY - i] = Program.ChengeSymb(randX, Board.EnemyField[randY - i], '#');
                            }
                            else 
                            {
                                Board.EnemyField[randY + i] = Program.ChengeSymb(randX, Board.EnemyField[randY + i], '#');
                            }
                            GameEngine.DrawEnemyMap();
                            Thread.Sleep(500);
                        }
                    }
                   
                }
                typeOfBoats--;
               
            }

           
        }



        public bool CheckBesideCell(int x, int y)
        {
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
