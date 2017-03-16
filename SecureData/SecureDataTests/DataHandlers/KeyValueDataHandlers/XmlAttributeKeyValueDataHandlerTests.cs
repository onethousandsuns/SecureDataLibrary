using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData.DataHandlers.KeyValueDataHandlers;

namespace SecureDataTests.DataHandlers.KeyValueDataHandlers
{
    [TestClass()]
    public class XmlAttributeKeyValueDataHandlerTests
    {
        [TestMethod()]
        public void XmlAttributeKeyValueDataHandler_GetSecuredData_EmptySecuredProps_NonChangedResult()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new XmlAttributeKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>();

            //ACT
            var result = handler.GetSecuredData("<auth user=\"max\" pass=\"123456\">");

            //ASSERT
            Assert.AreEqual("<auth user=\"max\" pass=\"123456\">", result);
        }

        [TestMethod()]
        public void XmlAttributeKeyValueDataHandler_GetSecuredData_NonEmptySecuredProps_ParametresSecured()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new XmlAttributeKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>
            {
                { "user", "max"},
                { "pass", "123456"}
            };

            //ACT
            var result = handler.GetSecuredData("<auth user=\"max\" pass=\"123456\">");

            //ASSERT
            Assert.AreEqual("<auth user=\"XXX\" pass=\"XXXXXX\">", result);
        }

        [TestMethod()]
        public void XmlAttributeKeyValueDataHandler_GetSecuredData_SecuredPropsNotInRequest_NonChangedResult()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new XmlAttributeKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>
            {
                { "username", "max"},
                { "password", "123456"}
            };

            //ACT
            var result = handler.GetSecuredData("<auth user=\"max\" pass=\"123456\">");

            //ASSERT
            Assert.AreEqual("<auth user=\"max\" pass=\"123456\">", result);
        }

        [TestMethod()]
        public void XmlAttributeKeyValueDataHandler_GetSecuredData_SomePropsNotInRequest_ListedParametresSecured()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new XmlAttributeKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>
            {
                { "user", "max"},
                { "password", "123456"}
            };

            //ACT
            var result = handler.GetSecuredData("<auth user=\"max\" pass=\"123456\">");

            //ASSERT
            Assert.AreEqual("<auth user=\"XXX\" pass=\"123456\">", result);
        }
    }
}