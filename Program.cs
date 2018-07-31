using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sea_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Player p = new Player("Serejka");


            GameEngine.DrawPlayerMap();
            GameEngine.DrawEnemyMap();
            GameEngine.ShowInstructions();
            
            p.CreatingBoats();

            
            //enemy.CreatingBoats
            //ShowInst_2


            //  Main game loop

            //while (!gameover)
            //p.Step(); enemy.Step();

            Console.ReadLine();
        }

        public static string ChengeSymb(int position, string str)

        {
            string t = str;
            char[] chars = t.ToCharArray();
            chars[position] = '#';
            str = new string(chars);
            return str;
        }
    }
}
