using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData.DataHandlers;

namespace SecureDataTests.DataHandlers
{
    [TestClass()]
    public class RegexDataHandlerTests
    {
        [TestMethod()]
        public void RegexDataHandler_GetSecuredData_EmptySecuredProps_NonChangedResult()
        {
            //ARRANGE
            string[] props = new string[] { };
            string regExpStr = "(?<=\\(|REPLACED_VALUE|\\|).+?(?=\\||REPLACED_VALUE|\\))";

            AbstractDataHandler handler = new RegexDataHandler(regExpStr, props);

            //ACT
            var result = handler.GetSecuredData("(user|max|user)(pass|max|pass)(lang|RU|lang)");

            //ASSERT
            Assert.AreEqual("(user|max|user)(pass|max|pass)(lang|RU|lang)", result);
        }

        [TestMethod()]
        public void RegexDataHandler_GetSecuredData_NonEmptySecuredProps_ParametresSecured()
        {
            //ARRANGE
            string[] props = new string[] { "user", "pass", "lang" };
            string regExpStr = "(?<=\\(|REPLACED_VALUE|\\|).+?(?=\\||REPLACED_VALUE|\\))";

            AbstractDataHandler handler = new RegexDataHandler(regExpStr, props);

            //ACT
            var result = handler.GetSecuredData("(user|max|user)(pass|max|pass)(lang|RU|lang)");

            //ASSERT
            Assert.AreEqual("(user|XXX|user)(pass|XXX|pass)(lang|XX|lang)", result);
        }


        [TestMethod()]
        public void RegexDataHandler_GetSecuredData_SecuredPropsNotInRequest_NonChangedResult()
        {
            //ARRANGE
            string[] props = new[] { "username", "password", "language" };
            string regExpStr = "(?<=\\(|REPLACED_VALUE|\\|).+?(?=\\||REPLACED_VALUE|\\))";

            AbstractDataHandler handler = new RegexDataHandler(regExpStr, props);

            //ACT
            var result = handler.GetSecuredData("(user|max|user)(pass|max|pass)(lang|RU|lang)");

            //ASSERT
            Assert.AreEqual("(user|max|user)(pass|max|pass)(lang|RU|lang)", result);
        }

        [TestMethod()]
        public void RegexDataHandler_GetSecuredData_SomePropsNotInRequest_ListedParametresSecured()
        {
            //ARRANGE
            string[] props = new[] { "user", "password", "lang" };
            string regExpStr = "(?<=\\(|REPLACED_VALUE|\\|).+?(?=\\||REPLACED_VALUE|\\))";

            AbstractDataHandler handler = new RegexDataHandler(regExpStr, props);

            //ACT
            var result = handler.GetSecuredData("(user|max|user)(pass|max|pass)(lang|RU|lang)");

            //ASSERT
            Assert.AreEqual("(user|XXX|user)(pass|max|pass)(lang|XX|lang)", result);
        }
    }
}