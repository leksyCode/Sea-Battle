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

            Player p = new Player("Human");
            AI a = new AI("Bot");
            
            GameEngine.DrawPlayerMap();
            GameEngine.DrawHiddenEnemyMap();
            
            GameEngine.ShowInstructions();


            a.CreatingAIMapAlgorithm(); // works almost always (95%)   
            p.CreatingPlayerMap();


        
            while (p.Health > 0 && a.Health > 0)
            {
                a.Health = p.MakeStep(a.Health);
                GameEngine.DrawHiddenEnemyMap();
                p.Health = a.MakeStep(p.Health);
                GameEngine.DrawPlayerMap();
                GameEngine.ShowInfo(0, $"Player HP: {p.Health}\t\t AI HP {a.Health}");
            }

            if (p.Health > 0)  
                Console.WriteLine("\n Player winn!");
            else
                Console.WriteLine("\n AI winn!");

            GameEngine.DrawEnemyMap();
            // TO DO NEXT11

            Console.ReadLine();
        }

        public static string ChengeSymb(int position, string str, char symb)
        {
            string t = str;
            char[] chars = t.ToCharArray();
            chars[position] = symb;
            str = new string(chars);
            return str;
        }
    }
}
