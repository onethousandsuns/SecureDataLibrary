using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData.DataHandlers;
using SecureData.DataHandlers.KeyValueDataHandlers;

namespace SecureDataTests
{
    [TestClass]
    public class HandlersSpeedCompareTests
    {
        const int RepeatsNum = 50000;

        [TestMethod]
        public void HandlersSpeedComparer_GetSecuredValue_JsonDataHandlers_ClearSecureData()
        {
            //ARRANGE
            string data = "{user: \"maxim\", pass: \"123\", lang: \"rus\", credit_card: \"660666\", tel_number: \"89002223434\"}";
            var keyValueHandler = new JsonKeyValueDataHandler
            {
                Properties = new Dictionary<string, string>
                {
                    {"user", "max"},
                    {"pass", "123456"},
                    {"lang", "rus"},
                    {"credit_card", "660666"},
                    {"tel_number", "89002223434"}
                }
            };

            var commonHandler = new JsonDataHandler
            {
                Properties = new [] { "user", "pass", "lang", "credit_card", "tel_number" }
            };

            //ACT
            var keyValueHandlerWorkTime = GetKeyValueHandlerExecutionTime(keyValueHandler, RepeatsNum, data);
            var commonHandlerWorkTime = GetCommonHandlerExecutionTime(commonHandler, RepeatsNum, data);

            //ASSERT
            Assert.IsTrue(keyValueHandlerWorkTime < commonHandlerWorkTime);
        }

        [TestMethod]
        public void HandlersSpeedComparer_GetSecuredValue_XmlDataHandlers_ClearSecureData()
        {
            //ARRANGE
            string data = "<auth><user>max</user><pass>123456</pass><lang>rus</lang><credit_card>660666</credit_card><tel_number>89002223434</tel_number></auth>";
            var keyValueHandler = new XmlElementKeyValueDataHandler()
            {
                Properties = new Dictionary<string, string>
                {
                    {"user", "max"},
                    {"pass", "123456"},
                    {"lang", "rus"},
                    {"credit_card", "660666"},
                    {"tel_number", "89002223434"}
                }
            };

            var commonHandler = new XmlElementValueDataHandler()
            {
                Properties = new [] { "user", "pass", "lang", "credit_card", "tel_number" }
            };

            //ACT
            var keyValueHandlerWorkTime = GetKeyValueHandlerExecutionTime(keyValueHandler, RepeatsNum, data);
            var commonHandlerWorkTime = GetCommonHandlerExecutionTime(commonHandler, RepeatsNum, data);

            //ASSERT
            Assert.IsTrue(keyValueHandlerWorkTime < commonHandlerWorkTime);
        }

        [TestMethod]
        public void HandlersSpeedComparer_GetSecuredValue_UrlDataHandlers_ClearSecureData()
        {
            //ARRANGE
            string data = "http://test.com?user=max&pass=123456&lang=rus&credit_card=660666&tel_number=89002223434";
            var keyValueHandler = new UrlGetKeyValueDataHandler()
            {
                Properties = new Dictionary<string, string>
                {
                    {"user", "max"},
                    {"pass", "123456"},
                    {"lang", "rus"},
                    {"credit_card", "660666"},
                    {"tel_number", "89002223434"}
                }
            };

            var commonHandler = new UrlGetRequestDataHandler()
            {
                Properties = new [] { "user", "pass", "lang", "credit_card", "tel_number" }
            };

            //ACT
            var keyValueHandlerWorkTime = GetKeyValueHandlerExecutionTime(keyValueHandler, RepeatsNum, data);
            var commonHandlerWorkTime = GetCommonHandlerExecutionTime(commonHandler, RepeatsNum, data);

            //ASSERT
            Assert.IsTrue(keyValueHandlerWorkTime < commonHandlerWorkTime);
        }

        private static long GetKeyValueHandlerExecutionTime(AbstractKeyValueDataHandler handler, int repeatsNum, string data)
        {
            var resultTime = DateTime.Now.Ticks;
            for (var i = 0; i < repeatsNum; ++i)
            {
                handler.GetSecuredData(data);
            }
            resultTime = DateTime.Now.Ticks - resultTime;
            return resultTime;
        }

        private static long GetCommonHandlerExecutionTime(AbstractDataHandler handler, int repeatsNum, string data)
        {
            var resultTime = DateTime.Now.Ticks;
            for (var i = 0; i < repeatsNum; ++i)
            {
                handler.GetSecuredData(data);
            }
            resultTime = DateTime.Now.Ticks - resultTime;
            return resultTime;
        }
    }
}
