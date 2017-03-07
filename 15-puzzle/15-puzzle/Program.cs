using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _15_puzzle
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] numberedSquare = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
            Puzzle game;
           
            try
            {
                   
                Range.Check(numberedSquare);
                game = new Puzzle(numberedSquare);
                Console.WriteLine("Исходное поле");
                Console.WriteLine(game);
                try
                {
                    game.Shift(12);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine(game);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine(Puzzle.FromCSV("input.csv"));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            var game2 = new Game2(numberedSquare);
            Console.WriteLine(game2);
            game2.Randomize();
            Console.WriteLine(game2.Victory);
            Console.WriteLine(game2);

            var game3 = new Game3(numberedSquare);
            game3.Shift(12);
          



            for (int i = 0; i < game3.GetAllHistory().Count; i++)
            {
                Console.WriteLine(game3.GetAllHistory()[i]);
            }
            game3.GetAllHistory();

            game3.Randomize();
            Console.WriteLine(game3.GetStep(1));


            Console.WriteLine(Game2.CreateRandom(5));

        }
     }
}
