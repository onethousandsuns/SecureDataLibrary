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
    public class JsonDataHandlerTests
    {
        [TestMethod()]
        public void JsonDataHandlerTests_GetSecuredDataTest_Process_EmptySecuredProps_NonChangedResult()
        {
            IDataHandler handler = new JsonDataHandler();
            handler.properties = new string[] {};

            Assert.AreEqual("{\"user\":\"maxim\",\"pass\":\"123\"}", handler.GetSecuredData("{user: \"maxim\", pass:\"123\"}"));
        }

        [TestMethod()]
        public void JsonDataHandlerTests_GetSecuredDataTest_Process_NonEmptySecuredProps_ParametresSecured()
        {
            IDataHandler handler = new JsonDataHandler();
            handler.properties = new string[] { "user", "pass" };

            Assert.AreEqual("{\"user\":\"XXXXX\",\"pass\":\"XXX\"}", handler.GetSecuredData("{user: \"maxim\", pass:\"123\"}"));
        }

        [TestMethod()]
        public void JsonDataHandlerTests_GetSecuredDataTest_Process_SecuredPropsNotInRequest_NonChangedResult()
        {
            IDataHandler handler = new JsonDataHandler();
            handler.properties = new string[] { "first_name", "second_name" };

            Assert.AreEqual("{\"user\":\"maxim\",\"pass\":\"123\"}", handler.GetSecuredData("{user: \"maxim\", pass:\"123\"}"));
        }

        [TestMethod()]
        public void JsonDataHandlerTests_GetSecuredDataTest_Process_SomePropsNotInRequest_ListedParametresSecured()
        {
            IDataHandler handler = new JsonDataHandler();
            handler.properties = new string[] { "user", "first_name" };

            Assert.AreEqual("{\"user\":\"XXXXX\",\"pass\":\"123\"}", handler.GetSecuredData("{user: \"maxim\", pass:\"123\"}"));
        }

    }
}