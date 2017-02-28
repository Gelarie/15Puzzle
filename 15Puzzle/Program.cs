using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1, 4, 2, 5, 3, 6, 7, 8,0);
            game.GetLocation(0);            
            game.Shift(8);
            game.Shift(5);
           
        }
    }
}
