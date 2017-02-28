using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15Puzzle
{
    public static class Print
    {              
        public static void PrintInfo(int[,] array, int Side)
        {
            Console.WriteLine("Игровое поле");
            for (int i = 0; i < Side; i++)
            {
                for (int j = 0; j < Side; j++)
                {
                    Console.Write("{0}\t", array[i, j]);
                }
                Console.WriteLine();                
            }
            Console.WriteLine();
        }       
    }
}
