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
        public void UrlGetRequestDataHandlerTests_GetSecuredDataTest_Process_EmptySecuredProps_NonChangedResult()
        {
            IDataHandler handler = new UrlGetRequestDataHandler();
            handler.properties = new string[] { };

            Assert.AreEqual("http://test.com?user=max&pass=123456", handler.GetSecuredData("http://test.com?user=max&pass=123456"));
        }

        [TestMethod()]
        public void UrlGetRequestDataHandlerTests_GetSecuredDataTest_Process_NonEmptySecuredProps_ParametresSecured()
        {
            IDataHandler handler = new UrlGetRequestDataHandler();
            handler.properties = new string[] { "user", "pass" };

            Assert.AreEqual("http://test.com?user=XXX&pass=XXXXXX", handler.GetSecuredData("http://test.com?user=max&pass=123456"));
        }

        [TestMethod()]
        public void UrlGetRequestDataHandlerTests_GetSecuredDataTest_Process_SecuredPropsNotInRequest_NonChangedResult()
        {
            IDataHandler handler = new UrlGetRequestDataHandler();
            handler.properties = new string[] { "first_name", "second_name" };

            Assert.AreEqual("http://test.com?user=max&pass=123456", handler.GetSecuredData("http://test.com?user=max&pass=123456"));
        }

        [TestMethod()]
        public void UrlGetRequestDataHandlerTests_GetSecuredDataTest_Process_SomePropsNotInRequest_ListedParametresSecured()
        {
            IDataHandler handler = new UrlGetRequestDataHandler();
            handler.properties = new string[] { "user", "first_name" };

            Assert.AreEqual("http://test.com?user=XXX&pass=123456", handler.GetSecuredData("http://test.com?user=max&pass=123456"));
        }
    }
}