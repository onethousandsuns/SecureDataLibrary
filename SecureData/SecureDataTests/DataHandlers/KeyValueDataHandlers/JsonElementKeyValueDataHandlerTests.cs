using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData.DataHandlers.KeyValueDataHandlers;

namespace SecureDataTests.DataHandlers.KeyValueDataHandlers
{
    [TestClass()]
    public class JsonElementKeyValueDataHandlerTests
    {
        [TestMethod()]
        public void JsonElementKeyValueDataHandler_GetSecuredData_EmptySecuredProps_NonChangedResult()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new JsonElementKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>();

            //ACT
            var result = handler.GetSecuredData("{user: value:\"maxim\", pass: value:\"123\"}");

            //ASSERT
            Assert.AreEqual("{user: value:\"maxim\", pass: value:\"123\"}", result);
        }

        [TestMethod()]
        public void JsonElementKeyValueDataHandler_GetSecuredData_NonEmptySecuredProps_ParametresSecured()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new JsonElementKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>
            {
                { "user", "max"},
                { "pass", "123456"}
            };

            //ACT
            var result = handler.GetSecuredData("{user: value:\"max\", pass: value:\"123456\"}");

            //ASSERT
            Assert.AreEqual("{user: value:\"XXX\", pass: value:\"XXXXXX\"}", result);
        }

        [TestMethod()]
        public void JsonElementKeyValueDataHandler_GetSecuredData_SecuredPropsNotInRequest_NonChangedResult()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new JsonElementKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>
            {
                { "username", "max"},
                { "password", "123456"}
            };

            //ACT
            var result = handler.GetSecuredData("{user: value:\"max\", pass: value:\"123456\"}");

            //ASSERT
            Assert.AreEqual("{user: value:\"max\", pass: value:\"123456\"}", result);
        }

        [TestMethod()]
        public void JsonElementKeyValueDataHandler_GetSecuredData_SomePropsNotInRequest_ListedParametresSecured()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new JsonElementKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>
            {
                { "user", "max"},
                { "password", "123456"}
            };

            //ACT
            var result = handler.GetSecuredData("{user: value:\"max\", pass: value:\"123456\"}");

            //ASSERT
            Assert.AreEqual("{user: value:\"XXX\", pass: value:\"123456\"}", result);
        }
    }
}