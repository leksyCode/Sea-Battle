﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Wars
{
    public class Board
    {    	
        public const int countOfBoats = 20;
        public static readonly int width = 21; 
        public static string[] PlayerField = new string[]
        {
           //012 4 6 8   
           // Empty Field
            "*[A_B_C_D_E_F_G_H_I_J]",
            "1 . . . . . . . . . .|",
            "2 . . . . . . . . . .|", 
            "3 . . . . . . . . . .|",
            "4 . . . . . . . . . .|",
            "5 . . . . . . . . . .|",
            "6 . . . . . . . . . .|",
            "7 . . . . . . . . . .|",
            "8 . . . . . . . . . .|",
            "9 . . . . . . . . . .|",
            "*^^^^^^^^^^^^^^^^^^^^*",
        };
        public static string[] EnemyField = new string[]
        {
            "*[A_B_C_D_E_F_G_H_I_J]",
            "1 . . . . . . . . . .|",
            "2 . . . . . . . . . .|",
            "3 . . . . . . . . . .|",
            "4 . . . . . . . . . .|",
            "5 . . . . . . . . . .|",
            "6 . . . . . . . . . .|",
            "7 . . . . . . . . . .|",
            "8 . . . . . . . . . .|",
            "9 . . . . . . . . . .|",
            "*^^^^^^^^^^^^^^^^^^^^*",
        };



    }
}
