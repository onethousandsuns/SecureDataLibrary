using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData.DataHandlers;

namespace SecureDataTests.DataHandlers
{
    [TestClass()]
    public class XmlDataHandlerTests
    {
        [TestMethod()]
        public void XmlDataHandler_GetSecuredData_EmptySecuredProps_NonChangedResult()
        {
            //ARRANGE
            AbstractDataHandler handler = new XmlDataHandler();
            handler.Properties = new string[] { };

            //ACT
            var result = handler.GetSecuredData("<auth user=\"max\"><pass>123456</pass></auth>");

            //ASSERT
            Assert.AreEqual("<auth user=\"max\"><pass>123456</pass></auth>", result);
        }

        [TestMethod()]
        public void XmlDataHandler_GetSecuredData_NonEmptySecuredProps_ParametresSecured()
        {
            //ARRANGE
            AbstractDataHandler handler = new XmlDataHandler();
            handler.Properties = new string[] { "user", "pass" };

            //ACT
            var result = handler.GetSecuredData("<auth user=\"max\"><pass>123456</pass></auth>");

            //ASSERT
            Assert.AreEqual("<auth user=\"XXX\"><pass>XXXXXX</pass></auth>", result);
        }


        [TestMethod()]
        public void XmlDataHandler_GetSecuredData_SecuredPropsNotInRequest_NonChangedResult()
        {
            //ARRANGE
            AbstractDataHandler handler = new XmlDataHandler();
            handler.Properties = new string[] { "first_name", "second_name" };

            //ACT
            var result = handler.GetSecuredData("<auth user=\"max\"><pass>123456</pass></auth>");

            //ASSERT
            Assert.AreEqual("<auth user=\"max\"><pass>123456</pass></auth>", result);
        }

        [TestMethod()]
        public void XmlDataHandler_GetSecuredData_SomePropsNotInRequest_ListedParametresSecured()
        {
            //ARRANGE
            AbstractDataHandler handler = new XmlDataHandler();
            handler.Properties = new string[] { "user", "first_name" };

            //ACT
            var result = handler.GetSecuredData("<auth user=\"max\"><pass>123456</pass></auth>");

            //ASSERT
            Assert.AreEqual("<auth user=\"XXX\"><pass>123456</pass></auth>", result);
        }
    }
}