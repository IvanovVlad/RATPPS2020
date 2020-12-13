using Microsoft.VisualStudio.TestTools.UnitTesting;
using HTTPClient;
using SerHTTPClientializer;

namespace Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestPing()
        {
            var client = new Client();
            Assert.AreEqual(true, client.Ping("https://tolltech.ru/study/Ping"));
        }

        [TestMethod]
        public void TestGetInputData()
        {
            var client = new Client();
            Assert.AreEqual("{\"K\":10,\"Sums\":[1.01,2.02],\"Muls\":[1,4]}",
                client.GetInputData("https://tolltech.ru/study/GetInputData"));
        }

        [TestMethod]
        public void TestWriteAnswer()
        {
            var serializer = new JSONSerializer();
            var client = new Client();

            var input = new Input
            {
                K = 10,
                Sums = new decimal[] { 1.01M, 2.02M },
                Muls = new int[] { 1, 4 }
            };

            var output = new Output
            {
                SumResult = input.Summ(),
                MulResult = input.Mul(),
                SortedInputs = input.Sort()
            };

            var str = serializer.Serialize<Output>(output);

            Assert.AreEqual(true, client.WriteAnswer("https://tolltech.ru/study/Create", str));
        }
    }
}
