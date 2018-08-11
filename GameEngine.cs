using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sea_Wars
{
    abstract class GameEngine
    {
        private static int displayPosition_X = 0, displayPosition_Y = 0;

        public static void DrawPlayerMap()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < Board.PlayerField.Length; i++)
            {
                Console.WriteLine(Board.PlayerField[i]);
            }
        }
         
        public static void DrawEnemyMap()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            displayPosition_X += 30;
           
            for (int i = 0; i < Board.EnemyField.Length; i++)
            {
                Console.SetCursorPosition(displayPosition_X, displayPosition_Y + i);
                Console.Write(Board.EnemyField[i]);
            }
            displayPosition_X -= 30;
        }

        public static void ShowInstructions()
        {
            Console.SetCursorPosition(0,14);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t   Instructions ");
            Console.WriteLine("Creat your sea flot. U can write coordinates of boats like (D4) or use navigation buttons");
        }

        public static void ShowInfo(int i, int stage)
        {
            Console.SetCursorPosition(0, 11);
            Console.Write("U must creat another: " + (20 - i));
            if (i < 10)
            {
                Console.WriteLine(" ");
            }
            switch (stage)
            {
                case 0:
                    {
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\n\t\t\t\t\t\t\t\t\t\t\t\t");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("U must create a major ship");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("stage 2");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("stage 3");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("U must creat yet " + (4 - i) + " single ships. They cant touch each other");
                        break;
                    }
                default:
                    break;
            }

                
        }       
    }
}
