using System;

namespace Serializer
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            var input = new Input { 
                K = 10, 
                Sums = new decimal[]{ 1.01M, 2.02M }, 
                Muls = new int[]{ 1, 4 }
            };
            ISerializer serializer;
            var type = Console.ReadLine();
            if (type == "json")
                serializer = new JSONSerializer();
            else
                serializer = new XMLSerializer();

            var str = serializer.Serialize<Input>(input);
            var deserializedInput = serializer.Deserialize<Input>(str);

            Console.WriteLine(str);
            Console.WriteLine(deserializedInput);

            var output = new Output
            {
                SumResult = deserializedInput.summ(),
                MulResult = deserializedInput.mul(),
                SortedInputs = deserializedInput.sort()
            };

            str = serializer.Serialize<Output>(output);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(str);
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
