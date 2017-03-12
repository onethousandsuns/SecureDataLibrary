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
        public void JsonDataHandler_GetSecuredData_EmptySecuredProps_NonChangedResult()
        {
            //ARRANGE
            IDataHandler handler = new JsonDataHandler();
            handler.properties = new string[] {};

            //ACT
            var result = handler.GetSecuredData("{user: \"maxim\", pass:\"123\"}");

            //ASSERT
            Assert.AreEqual("{\"user\":\"maxim\",\"pass\":\"123\"}", result);
        }

        [TestMethod()]
        public void JsonDataHandler_GetSecuredData_NonEmptySecuredProps_ParametresSecured()
        {
            //ARRANGE
            IDataHandler handler = new JsonDataHandler();
            handler.properties = new string[] { "user", "pass" };

            //ACT
            var result = handler.GetSecuredData("{user: \"maxim\", pass:\"123\"}");

            //ASSERT
            Assert.AreEqual("{\"user\":\"XXXXX\",\"pass\":\"XXX\"}", result);
        }

        [TestMethod()]
        public void JsonDataHandler_GetSecuredData_SecuredPropsNotInRequest_NonChangedResult()
        {
            //ARRANGE
            IDataHandler handler = new JsonDataHandler();
            handler.properties = new string[] { "first_name", "second_name" };

            //ACT
            var result = handler.GetSecuredData("{user: \"maxim\", pass:\"123\"}");

            //ASSERT
            Assert.AreEqual("{\"user\":\"maxim\",\"pass\":\"123\"}", result);
        }

        [TestMethod()]
        public void JsonDataHandler_GetSecuredData_SomePropsNotInRequest_ListedParametresSecured()
        {
            //ARRANGE
            IDataHandler handler = new JsonDataHandler();
            handler.properties = new string[] { "user", "first_name" };

            //ACT
            var result = handler.GetSecuredData("{user: \"maxim\", pass:\"123\"}");

            //ASSERT
            Assert.AreEqual("{\"user\":\"XXXXX\",\"pass\":\"123\"}", result);
        }

    }
}