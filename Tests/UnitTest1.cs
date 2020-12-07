using Microsoft.VisualStudio.TestTools.UnitTesting;
using HTTPClient;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPing1()
        {
            var client = new Client();
            Assert.AreEqual(true, client.Ping("https://tolltech.ru/study/Ping"));
        }


        [TestMethod]
        public void TestPing2()
        {
            var client = new Client();
            Assert.AreNotEqual(true, client.Ping("https://tolltech.ru/study/Pnig"));
        }

        [TestMethod]
        public void TestGetData1()
        {
            var client = new Client();
            Assert.AreEqual("{\"K\":10,\"Sums\":[1.01,2.02],\"Muls\":[1,4]}", client.GetInputData("https://tolltech.ru/study/GetInputData"));
        }

        [TestMethod]
        public void TestGetData2()
        {
            var client = new Client();
            Assert.AreNotEqual("{\"K\":20,\"Sums\":[2.02,1.01],\"Muls\":[4,1]}", client.GetInputData("https://tolltech.ru/study/GetInputData"));
        }
    }
}
