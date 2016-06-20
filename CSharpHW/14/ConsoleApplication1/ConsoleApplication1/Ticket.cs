using System;

namespace ConsoleApplication1
{
    
    class Ticket
    {
        private const int maxN = 6;
        private int[] combo = new int[maxN];

        public Ticket(params int[] winCombo)
        {
            combo = winCombo;
        }

        public int this[int index]
        {
            get
            {
                if (ValidInd(index)) return combo[index];
                return -1;
            }

            set
            {
                if (ValidInd(index))
                {
                    combo[index] = value;
                }
                else
                {
                    Console.WriteLine("Invalid index");
                }
            }
        }
        
        private bool ValidInd(int index)
        {
            if (index < 0 || index > maxN) return false;
            return true;
        }

        public int[] GetCombination()
        {
            return combo;
        }

    }
}
