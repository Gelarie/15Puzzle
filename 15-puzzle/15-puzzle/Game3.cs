using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_puzzle
{
    class Game3 : Game2
    {
        private List<History> history;
        private int countStep;
        public Game3(params int[] numberedSquare) : base(numberedSquare)
        {
            history = new List<History>();
            countStep = 0;
        }
        public override void Shift(int value)
        {
            base.Shift(value);
            if (countStep < history.Count)
            {
                for (int i = history.Count - 1; i > countStep - 1; i--)
                    history.RemoveAt(i);
            }
            history.Add(new History(value, GetLocation(0), GetLocation(value)));
            countStep++;
        }
             
        public List<string> GetAllHistory()
        {
            List<string> steps = new List<string>();
            for (int i = 0; i < countStep; i++)
            {
                steps.Add(history[i].ToString());
            }
            return steps;
        }
        public string GetStep(int value)
        {
            if (value <= countStep)
            {
                return history[value - 1].ToString();
            }
            else return "Не существует шага";
        }

        public override void Randomize()
        {
            base.Randomize();
            countStep = 0;
            history.Clear();
        }

    }
}
