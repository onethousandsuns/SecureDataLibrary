using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData.DataHandlers.KeyValueDataHandlers;

namespace SecureDataTests.DataHandlers.KeyValueDataHandlers
{
    [TestClass()]
    public class RestUrlKeyValueDataHandlerTests
    {
        [TestMethod()]
        public void RestUrlKeyValueDataHandler_GetSecuredData_EmptySecuredProps_NonChangedResult()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new RestUrlKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>();

            //ACT
            var result = handler.GetSecuredData("http://test.com/user/max/pass/123456");

            //ASSERT
            Assert.AreEqual("http://test.com/user/max/pass/123456", result);
        }

        [TestMethod()]
        public void RestUrlKeyValueDataHandler_GetSecuredData_NonEmptySecuredProps_ParametresSecured()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new RestUrlKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>
            {
                { "user", "max"},
                { "pass", "123456"}
            };

            //ACT
            var result = handler.GetSecuredData("http://test.com/user/max/pass/123456");

            //ASSERT
            Assert.AreEqual("http://test.com/user/XXX/pass/XXXXXX", result);
        }

        [TestMethod()]
        public void RestUrlKeyValueDataHandler_GetSecuredData_SecuredPropsNotInRequest_NonChangedResult()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new RestUrlKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>
            {
                { "username", "max"},
                { "password", "123456"}
            };

            //ACT
            var result = handler.GetSecuredData("http://test.com/user/max/pass/123456");

            //ASSERT
            Assert.AreEqual("http://test.com/user/max/pass/123456", result);
        }

        [TestMethod()]
        public void RestUrlKeyValueDataHandler_GetSecuredData_SomePropsNotInRequest_ListedParametresSecured()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new RestUrlKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>
            {
                { "user", "max"},
                { "password", "123456"}
            };

            //ACT
            var result = handler.GetSecuredData("http://test.com/user/max/pass/123456");

            //ASSERT
            Assert.AreEqual("http://test.com/user/XXX/pass/123456", result);
        }
    }
}