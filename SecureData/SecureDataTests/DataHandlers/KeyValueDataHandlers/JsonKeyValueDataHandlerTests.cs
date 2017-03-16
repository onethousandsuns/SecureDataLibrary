using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData.DataHandlers.KeyValueDataHandlers;

namespace SecureDataTests.DataHandlers.KeyValueDataHandlers
{
    [TestClass()]
    public class JsonKeyValueDataHandlerTests
    {
        [TestMethod()]
        public void JsonKeyValueDataHandler_GetSecuredData_EmptySecuredProps_NonChangedResult()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new JsonKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>(); 

            //ACT
            var result = handler.GetSecuredData("{user: \"maxim\", pass: \"123\"}");

            //ASSERT
            Assert.AreEqual("{user: \"maxim\", pass: \"123\"}", result);
        }

        [TestMethod()]
        public void JsonKeyValueDataHandler_GetSecuredData_NonEmptySecuredProps_ParametresSecured()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new JsonKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>
            {
                { "user", "max"},
                { "pass", "123456"}
            };

            //ACT
            var result = handler.GetSecuredData("{user: \"max\", pass: \"123456\"}");

            //ASSERT
            Assert.AreEqual("{user: \"XXX\", pass: \"XXXXXX\"}", result);
        }

        [TestMethod()]
        public void JsonKeyValueDataHandler_GetSecuredData_SecuredPropsNotInRequest_NonChangedResult()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new JsonKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>
            {
                { "username", "max"},
                { "password", "123456"}
            };

            //ACT
            var result = handler.GetSecuredData("{user: \"max\", pass: \"123456\"}");

            //ASSERT
            Assert.AreEqual("{user: \"max\", pass: \"123456\"}", result);
        }

        [TestMethod()]
        public void JsonKeyValueDataHandler_GetSecuredData_SomePropsNotInRequest_ListedParametresSecured()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new JsonKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>
            {
                { "user", "max"},
                { "password", "123456"}
            };

            //ACT
            var result = handler.GetSecuredData("{user: \"max\", pass: \"123456\"}");

            //ASSERT
            Assert.AreEqual("{user: \"XXX\", pass: \"123456\"}", result);
        }
    }
}