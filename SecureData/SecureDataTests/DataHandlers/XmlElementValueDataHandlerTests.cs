using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData.DataHandlers;

namespace SecureDataTests.DataHandlers
{
    [TestClass()]
    public class XmlElementValueDataHandlerTests
    {
        [TestMethod()]
        public void XmlElementValueDataHandler_GetSecuredData_EmptySecuredProps_NonChangedResult()
        {
            //ARRANGE
            AbstractDataHandler handler = new XmlElementValueDataHandler();
            handler.Properties = new string[] { };

            //ACT
            var result = handler.GetSecuredData("<auth><user>max</user><pass>123456</pass></auth>");

            //ASSERT
            Assert.AreEqual("<auth><user>max</user><pass>123456</pass></auth>", result);
        }

        [TestMethod()]
        public void XmlElementValueDataHandler_GetSecuredData_NonEmptySecuredProps_ParametresSecured()
        {
            //ARRANGE
            AbstractDataHandler handler = new XmlElementValueDataHandler();
            handler.Properties = new string[] { "user", "pass" };

            //ACT
            var result = handler.GetSecuredData("<auth><user>max</user><pass>123456</pass></auth>");

            //ASSERT
            Assert.AreEqual("<auth><user>XXX</user><pass>XXXXXX</pass></auth>", result);
        }


        [TestMethod()]
        public void XmlElementValueDataHandler_GetSecuredData_SecuredPropsNotInRequest_NonChangedResult()
        {
            //ARRANGE
            AbstractDataHandler handler = new XmlElementValueDataHandler();
            handler.Properties = new string[] { "first_name", "second_name" };

            //ACT
            var result = handler.GetSecuredData("<auth><user>max</user><pass>123456</pass></auth>");

            //ASSERT
            Assert.AreEqual("<auth><user>max</user><pass>123456</pass></auth>", result);
        }

        [TestMethod()]
        public void XmlElementValueDataHandler_GetSecuredData_SomePropsNotInRequest_ListedParametresSecured()
        {
            //ARRANGE
            AbstractDataHandler handler = new XmlElementValueDataHandler();
            handler.Properties = new string[] { "user", "first_name" };

            //ACT
            var result = handler.GetSecuredData("<auth><user>max</user><pass>123456</pass></auth>");

            //ASSERT
            Assert.AreEqual("<auth><user>XXX</user><pass>123456</pass></auth>", result);
        }
    }
}