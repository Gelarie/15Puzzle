using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_puzzle
{
    class History
    {
        public int Value;
        public Coordinate ShiftTo;
        public Coordinate ShiftFrom;
        public History(int value, Coordinate position1, Coordinate position2)
        {
            Value = value;
            ShiftFrom = position1;
            ShiftTo = position2;
        }
    }
}
