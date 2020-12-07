using System;
using System.Xml.Serialization;

namespace Serializer
{   
    [XmlRoot(ElementName = "Input")]
    public class Input
    {
        [XmlElement(ElementName = "K")]
        public int K { get; set; }
        [XmlElement(ElementName = "Sums")]
        public decimal[] Sums { get; set; }
        [XmlElement(ElementName = "Muls")]
        public int[] Muls { get; set; }

        public decimal summ()
        {
            decimal sum = 0;
            for (int i = 0; i < Sums.Length; i++)
            {
                sum += Sums[i];
            }

            return sum;
        }

        public int mul()
        {
            int mul = 1;
            for (int i = 0; i < Muls.Length; i++)
            {
                mul *= Muls[i];
            }

            return mul;
        }

        public decimal[] sort()
        {
            decimal[] accum = new decimal[Sums.Length + Muls.Length];

            Array.ConvertAll(Muls, x => (decimal) x).CopyTo(accum, 0);
            Sums.CopyTo(accum, Muls.Length);

            Array.Sort(accum);

            return accum;
        }
    }
}
