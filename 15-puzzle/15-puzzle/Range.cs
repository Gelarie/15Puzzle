using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_puzzle
{
    static class Range
    {
        public static void Check(int[] range)
        {
            double rangesqrt = Math.Sqrt(range.Length);
          
                if (range.Length == 1 || Math.Pow(rangesqrt, 2) != range.Length)
                throw new ArgumentException("You entered an incorrect number");

            for (int i = 0; i < range.Length; i++)
            {
                if (!range.Contains(i))
                    throw new ArgumentException("Wrong number");
            }
        }
    }
}
