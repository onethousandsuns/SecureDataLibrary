using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData.DataHandlers;

namespace SecureDataTests.DataHandlers
{
    [TestClass()]
    public class RestUrlDataHandlerTests
    {
        [TestMethod()]
        public void RestUrlDataHandler_GetSecuredData_EmptySecuredProps_NonChangedResult()
        {           
            //ARRANGE
            AbstractDataHandler handler = new RestUrlDataHandler();
            handler.Properties = new string[] { };

            //ACT
            var result = handler.GetSecuredData("http://test.com/user/max/info?pass=123456");

            //ASSERT
            Assert.AreEqual("http://test.com/user/max/info?pass=123456", result);
        }

        [TestMethod()]
        public void RestUrlDataHandler_GetSecuredData_NonEmptySecuredProps_ParametresSecured()
        {
            //ARRANGE
            AbstractDataHandler handler = new RestUrlDataHandler();
            handler.Properties = new string[] { "user", "pass" };

            //ACT
            var result = handler.GetSecuredData("http://test.com/user/max/info?pass=123456");

            //ASSERT
            Assert.AreEqual("http://test.com/user/XXX/info?pass=XXXXXX", result);
        }

        [TestMethod()]
        public void RestUrlDataHandler_GetSecuredData_SecuredPropsNotInRequest_NonChangedResult()
        {           
            //ARRANGE
            AbstractDataHandler handler = new RestUrlDataHandler();
            handler.Properties = new string[] { "first_name", "second_name" };

            //ACT
            var result = handler.GetSecuredData("http://test.com/user/max/info?pass=123456");

            //ASSERT
            Assert.AreEqual("http://test.com/user/max/info?pass=123456", result);
        }

        [TestMethod()]
        public void RestUrlDataHandler_GetSecuredData_SomePropsNotInRequest_ListedParametresSecured()
        {
            //ARRANGE
            AbstractDataHandler handler = new RestUrlDataHandler();
            handler.Properties = new string[] { "user", "first_name" };

            //ACT
            var result = handler.GetSecuredData("http://test.com/user/max/info?pass=123456");

            //ASSERT
            Assert.AreEqual("http://test.com/user/XXX/info?pass=123456", result);
        }
    }
}