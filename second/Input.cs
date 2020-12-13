using System;
using System.Linq;

namespace HTTPClient
{   
    public class Input
    {
        public int K { get; set; }
        public decimal[] Sums { get; set; }
        public int[] Muls { get; set; }

        public decimal Summ()
        {
            return Sums.Sum();
        }

        public int Mul()
        {
            int mul = 1;
            for (int i = 0; i < Muls.Length; i++)
            {
                mul *= Muls[i];
            }

            return mul;
        }

        public decimal[] Sort()
        {
            decimal[] accum = new decimal[Sums.Length + Muls.Length];

            Array.ConvertAll(Muls, x => (decimal) x).CopyTo(accum, 0);
            Sums.CopyTo(accum, Muls.Length);

            Array.Sort(accum);

            return accum;
        }
    }
}
