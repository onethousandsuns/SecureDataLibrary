using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData.DataHandlers;

namespace SecureDataTests.DataHandlers
{
    [TestClass()]
    public class JsonDataHandlerTests
    {
        [TestMethod()]
        public void JsonDataHandler_GetSecuredData_EmptySecuredProps_NonChangedResult()
        {
            //ARRANGE
            AbstractDataHandler handler = new JsonDataHandler();
            handler.Properties = new string[] {};

            //ACT
            var result = handler.GetSecuredData("{user: \"maxim\", pass:\"123\"}");

            //ASSERT
            Assert.AreEqual("{\"user\":\"maxim\",\"pass\":\"123\"}", result);
        }

        [TestMethod()]
        public void JsonDataHandler_GetSecuredData_NonEmptySecuredProps_ParametresSecured()
        {
            //ARRANGE
            AbstractDataHandler handler = new JsonDataHandler();
            handler.Properties = new string[] { "user", "pass" };

            //ACT
            var result = handler.GetSecuredData("{user: \"maxim\", pass:\"123\"}");

            //ASSERT
            Assert.AreEqual("{\"user\":\"XXXXX\",\"pass\":\"XXX\"}", result);
        }

        [TestMethod()]
        public void JsonDataHandler_GetSecuredData_SecuredPropsNotInRequest_NonChangedResult()
        {
            //ARRANGE
            AbstractDataHandler handler = new JsonDataHandler();
            handler.Properties = new string[] { "first_name", "second_name" };

            //ACT
            var result = handler.GetSecuredData("{user: \"maxim\", pass:\"123\"}");

            //ASSERT
            Assert.AreEqual("{\"user\":\"maxim\",\"pass\":\"123\"}", result);
        }

        [TestMethod()]
        public void JsonDataHandler_GetSecuredData_SomePropsNotInRequest_ListedParametresSecured()
        {
            //ARRANGE
            AbstractDataHandler handler = new JsonDataHandler();
            handler.Properties = new string[] { "user", "first_name" };

            //ACT
            var result = handler.GetSecuredData("{user: \"maxim\", pass:\"123\"}");

            //ASSERT
            Assert.AreEqual("{\"user\":\"XXXXX\",\"pass\":\"123\"}", result);
        }

    }
}