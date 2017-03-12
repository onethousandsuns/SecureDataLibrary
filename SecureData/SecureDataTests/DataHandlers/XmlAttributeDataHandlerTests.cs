using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData.DataHandlers;

namespace SecureDataTests.DataHandlers
{
    [TestClass()]
    public class XmlAttributeDataHandlerTests
    {
        [TestMethod()]
        public void XmlAttributeDataHandler_GetSecuredData_EmptySecuredProps_NonChangedResult()
        {
            //ARRANGE
            AbstractDataHandler handler = new XmlAttributeDataHandler();
            handler.Properties = new string[] { };

            //ACT
            var result = handler.GetSecuredData("<auth user=\"max\" pass=\"123456\">");

            //ASSERT
            Assert.AreEqual("<auth user=\"max\" pass=\"123456\">", result);
        }

        [TestMethod()]
        public void XmlAttributeDataHandler_GetSecuredData_NonEmptySecuredProps_ParametresSecured()
        {
            //ARRANGE
            AbstractDataHandler handler = new XmlAttributeDataHandler();
            handler.Properties = new string[] { "user", "pass" };

            //ACT
            var result = handler.GetSecuredData("<auth user=\"max\" pass=\"123456\">");

            //ASSERT
            Assert.AreEqual("<auth user=\"XXX\" pass=\"XXXXXX\">", result);
        }


        [TestMethod()]
        public void XmlAttributeDataHandler_GetSecuredData_SecuredPropsNotInRequest_NonChangedResult()
        {
            //ARRANGE
            AbstractDataHandler handler = new XmlAttributeDataHandler();
            handler.Properties = new string[] { "first_name", "second_name" };

            //ACT
            var result = handler.GetSecuredData("<auth user=\"max\" pass=\"123456\">");

            //ASSERT
            Assert.AreEqual("<auth user=\"max\" pass=\"123456\">", result);
        }

        [TestMethod()]
        public void XmlAttributeDataHandler_GetSecuredData_SomePropsNotInRequest_ListedParametresSecured()
        {
            //ARRANGE
            AbstractDataHandler handler = new XmlAttributeDataHandler();
            handler.Properties = new string[] { "user", "first_name" };

            //ACT
            var result = handler.GetSecuredData("<auth user=\"max\" pass=\"123456\">");

            //ASSERT
            Assert.AreEqual("<auth user=\"XXX\" pass=\"123456\">", result);
        }
    }
}