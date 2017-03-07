using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureData.HttpResults;

namespace SecureData.Tests
{
    [TestClass()]
    public class BookingcomHttpResultTests
    {
        [TestMethod()]
        public void BookingcomHttpResult_GetSecuredDataTest_Process_EmptySecuredProps_NonChangedResult()
        {
            IHttpResult handler = new BookingcomHttpResult();

            var expectedResult = new HttpResult
            {
                Url = "http://test.com/user/XXX/info?pass=XXXXXX",
                RequestBody = "http://test.com?user=XXX&pass=XXXXXX",
                ResponseBody = "http://tet.com?user=XXX&pass=XXXXXX"
            };

            var data = new HttpResult
            {
                Url = "http://test.com/user/max/info?pass=123456",
                RequestBody = "http://test.com?user=max&pass=123456",
                ResponseBody = "http://test.com?user=max&pass=123456"
            };

            var result = handler.GetSecuredResult(data);

            Assert.ReferenceEquals(expectedResult, result);
        }
    }
}