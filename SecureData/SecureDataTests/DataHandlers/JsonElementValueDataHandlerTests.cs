using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData.DataHandlers;

namespace SecureDataTests.DataHandlers
{
    [TestClass()]
    public class JsonElementValueDataHandlerTests
    {
        [TestMethod()]
        public void JsonElementValueDataHandler_GetSecuredData_EmptySecuredProps_NonChangedResult()
        {
            //ARRANGE
            AbstractDataHandler handler = new JsonElementValueDataHandler();
            handler.Properties = new string[] {};

            //ACT
            var result = handler.GetSecuredData("{user:{value:\"max\"}, pass: {value:\"123456\"}}");

            //ASSERT
            Assert.AreEqual("{\"user\":{\"value\":\"max\"},\"pass\":{\"value\":\"123456\"}}", result);
        }
        
        [TestMethod()]
        public void JsonElementValueDataHandler_GetSecuredData_NonEmptySecuredProps_ParametresSecured()
        {
            //ARRANGE
            AbstractDataHandler handler = new JsonElementValueDataHandler();
            handler.Properties = new string[] { "user", "pass" };

            //ACT
            var result = handler.GetSecuredData("{user:{value:\"max\"}, pass: {value:\"123456\"}}");

            //ASSERT
            Assert.AreEqual("{\"user\":{\"value\":\"XXX\"},\"pass\":{\"value\":\"XXXXXX\"}}", result);
        }

        [TestMethod()]
        public void JsonElementValueDataHandler_GetSecuredData_SecuredPropsNotInRequest_NonChangedResult()
        {
            //ARRANGE
            AbstractDataHandler handler = new JsonElementValueDataHandler();
            handler.Properties = new string[] { "username", "password" };

            //ACT
            var result = handler.GetSecuredData("{user:{value:\"max\"}, pass: {value:\"123456\"}}");

            //ASSERT
            Assert.AreEqual("{\"user\":{\"value\":\"max\"},\"pass\":{\"value\":\"123456\"}}", result);
        }

        [TestMethod()]
        public void JsonElementValueDataHandler_GetSecuredData_SomePropsNotInRequest_ListedParametresSecured()
        {
            //ARRANGE
            AbstractDataHandler handler = new JsonElementValueDataHandler();
            handler.Properties = new string[] { "user", "first_name" };

            //ACT
            var result = handler.GetSecuredData("{user:{value:\"max\"}, pass: {value:\"123456\"}}");

            //ASSERT
            Assert.AreEqual("{\"user\":{\"value\":\"XXX\"},\"pass\":{\"value\":\"123456\"}}", result);
        }
    }
}