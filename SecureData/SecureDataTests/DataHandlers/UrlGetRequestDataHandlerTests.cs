using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData.DataHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureData.DataHandlers.Tests
{
    [TestClass()]
    public class UrlGetRequestDataHandlerTests
    {
        [TestMethod()]
        public void UrlGetRequestDataHandler_GetSecuredData_EmptySecuredProps_NonChangedResult()
        {
            //ARRANGE
            IDataHandler handler = new UrlGetRequestDataHandler();
            handler.properties = new string[] { };

            //ACT
            var result = handler.GetSecuredData("http://test.com?user=max&pass=123456");

            //ASSERT
            Assert.AreEqual("http://test.com?user=max&pass=123456", result);
        }

        [TestMethod()]
        public void UrlGetRequestDataHandler_GetSecuredData_NonEmptySecuredProps_ParametresSecured()
        {
            //ARRANGE
            IDataHandler handler = new UrlGetRequestDataHandler();
            handler.properties = new string[] { "user", "pass" };

            //ACT
            var result = handler.GetSecuredData("http://test.com?user=max&pass=123456");

            //ASSERT
            Assert.AreEqual("http://test.com?user=XXX&pass=XXXXXX", result);
        }

        [TestMethod()]
        public void UrlGetRequestDataHandler_GetSecuredData_SecuredPropsNotInRequest_NonChangedResult()
        {
            //ARRANGE
            IDataHandler handler = new UrlGetRequestDataHandler();
            handler.properties = new string[] { "first_name", "second_name" };

            //ACT
            var result = handler.GetSecuredData("http://test.com?user=max&pass=123456");

            //ASSERT
            Assert.AreEqual("http://test.com?user=max&pass=123456", result);
        }

        [TestMethod()]
        public void UrlGetRequestDataHandler_GetSecuredData_SomePropsNotInRequest_ListedParametresSecured()
        {
            //ARRANGE
            IDataHandler handler = new UrlGetRequestDataHandler();
            handler.properties = new string[] { "user", "first_name" };

            //ACT
            var result = handler.GetSecuredData("http://test.com?user=max&pass=123456");

            //ASSERT
            Assert.AreEqual("http://test.com?user=XXX&pass=123456", result);
        }
    }
}