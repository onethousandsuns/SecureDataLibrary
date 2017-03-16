using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData.DataHandlers.KeyValueDataHandlers;

namespace SecureDataTests.DataHandlers.KeyValueDataHandlers
{
    [TestClass()]
    public class XmlElementKeyValueDataHandlerTests
    {
        [TestMethod()]
        public void XmlElementKeyValueDataHandler_GetSecuredData_EmptySecuredProps_NonChangedResult()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new XmlElementKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>();

            //ACT
            var result = handler.GetSecuredData("<auth><user>max</user><pass>123456</pass></auth>");

            //ASSERT
            Assert.AreEqual("<auth><user>max</user><pass>123456</pass></auth>", result);
        }

        [TestMethod()]
        public void XmlElementKeyValueDataHandler_GetSecuredData_NonEmptySecuredProps_ParametresSecured()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new XmlElementKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>
            {
                { "user", "max"},
                { "pass", "123456"}
            };

            //ACT
            var result = handler.GetSecuredData("<auth><user>max</user><pass>123456</pass></auth>");

            //ASSERT
            Assert.AreEqual("<auth><user>XXX</user><pass>XXXXXX</pass></auth>", result);
        }

        [TestMethod()]
        public void XmlElementKeyValueDataHandler_GetSecuredData_SecuredPropsNotInRequest_NonChangedResult()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new XmlElementKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>
            {
                { "username", "max"},
                { "password", "123456"}
            };

            //ACT
            var result = handler.GetSecuredData("<auth><user>max</user><pass>123456</pass></auth>");

            //ASSERT
            Assert.AreEqual("<auth><user>max</user><pass>123456</pass></auth>", result);
        }

        [TestMethod()]
        public void XmlElementKeyValueDataHandler_GetSecuredData_SomePropsNotInRequest_ListedParametresSecured()
        {
            //ARRANGE
            AbstractKeyValueDataHandler handler = new XmlElementKeyValueDataHandler();
            handler.Properties = new Dictionary<string, string>
            {
                { "user", "max"},
                { "password", "123456"}
            };

            //ACT
            var result = handler.GetSecuredData("<auth><user>max</user><pass>123456</pass></auth>");

            //ASSERT
            Assert.AreEqual("<auth><user>XXX</user><pass>123456</pass></auth>", result);
        }
    }
}