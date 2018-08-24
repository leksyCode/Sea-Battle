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

        public static void DrawHiddenEnemyMap()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            displayPosition_X += 30;

            for (int i = 0; i < Board.EmtyField.Length; i++)
            {
                Console.SetCursorPosition(displayPosition_X, displayPosition_Y + i);
                Console.Write(Board.EmtyField[i]);
            }
            displayPosition_X -= 30;
        }

        public static void ShowInstructions()
        {
            Console.SetCursorPosition(0, 14);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t   Instructions ");
            Console.WriteLine("Creat your sea flot. U can use navigation buttons!");
        }

        public static void ShowInfo(int stage, string message)
        {
            Console.SetCursorPosition(0, 11);
            if (!String.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t");
                Console.SetCursorPosition(0, 11);
                Console.Write(message);
            }
            else if (stage != 0)
            {
                Console.Write($"U must creat {5 - stage} ships with {stage}-deck\n");
            }


        }
    }
}
