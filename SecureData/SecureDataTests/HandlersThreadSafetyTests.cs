using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData.DataHandlers;

namespace SecureDataTests
{
    [TestClass]
    public class HandlersThreadSafetyTests
    {
        [TestMethod]
        public void HandlersThreadSafety_GetSecuredValue_JsonDataHandlers_ClearSecureData()
        {
            //ARRANGE
            var handler = new JsonDataHandler { Properties = new string[] {"user", "pass"} };
            const string data = "{user: \"maxim\", pass:\"123\"}";
            const string expected = "{\"user\":\"XXXXX\",\"pass\":\"XXX\"}";

            //ACT
            List<Thread> threads = new List<Thread>();
            string result1 = "", result2 = "", result3 = "", result4 = "";

            threads.AddRange(new List<Thread>
            {
                new Thread(() => { result1 = handler.GetSecuredData(data); }),
                new Thread(() => { result2 = handler.GetSecuredData(data); }),
                new Thread(() => { result3 = handler.GetSecuredData(data); }),
                new Thread(() => { result4 = handler.GetSecuredData(data); })
            });

            foreach (var thread in threads)
            {
                thread.Start();
                thread.Join();
            }

            //ASSERT
            Assert.AreEqual(expected, result1);
            Assert.AreEqual(expected, result2);
            Assert.AreEqual(expected, result3);
            Assert.AreEqual(expected, result4);
        }

        [TestMethod]
        public void HandlersThreadSafety_GetSecuredValue_UrlDataHandlers_ClearSecureData()
        {
            //ARRANGE
            var handler = new UrlGetRequestDataHandler { Properties = new string[] {"user", "pass"} };
            const string data = "http://test.com?user=max&pass=123456";
            const string expected = "http://test.com?user=XXX&pass=XXXXXX";

            //ACT
            List<Thread> threads = new List<Thread>();
            string result1 = "", result2 = "", result3 = "", result4 = "";

            threads.AddRange(new List<Thread>
            {
                new Thread(() => { result1 = handler.GetSecuredData(data); }),
                new Thread(() => { result2 = handler.GetSecuredData(data); }),
                new Thread(() => { result3 = handler.GetSecuredData(data); }),
                new Thread(() => { result4 = handler.GetSecuredData(data); })
            });

            foreach (var thread in threads)
            {
                thread.Start();
                thread.Join();
            }

            //ASSERT
            Assert.AreEqual(expected, result1);
            Assert.AreEqual(expected, result2);
            Assert.AreEqual(expected, result3);
            Assert.AreEqual(expected, result4);
        }

        [TestMethod]
        public void HandlersThreadSafety_GetSecuredValue_XmlDataHandlers_ClearSecureData()
        {
            //ARRANGE
            var handler = new XmlAttributeDataHandler { Properties = new string[] {"user", "pass"} };
            const string data = "<auth user=\"max\" pass=\"123456\">";
            const string expected = "<auth user=\"XXX\" pass=\"XXXXXX\">";

            //ACT
            List<Thread> threads = new List<Thread>();
            string result1 = "", result2 = "", result3 = "", result4 = "";

            threads.AddRange(new List<Thread>
            {
                new Thread(() => { result1 = handler.GetSecuredData(data); }),
                new Thread(() => { result2 = handler.GetSecuredData(data); }),
                new Thread(() => { result3 = handler.GetSecuredData(data); }),
                new Thread(() => { result4 = handler.GetSecuredData(data); })
            });

            foreach (var thread in threads)
            {
                thread.Start();
                thread.Join();
            }

            //ASSERT
            Assert.AreEqual(expected, result1);
            Assert.AreEqual(expected, result2);
            Assert.AreEqual(expected, result3);
            Assert.AreEqual(expected, result4);
        }
    }
}
