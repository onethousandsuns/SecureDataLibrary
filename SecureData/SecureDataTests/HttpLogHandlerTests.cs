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
    public class HttpLogHandlerTests
    {
        [TestMethod()]
        public void HttpLogHandler_Process_BookingcomHttpResultObjectProcess_ClearSecureData()
        {
            //ARRANGE
            IHttpResult bookingcomHttpHandler = new BookingcomHttpResult();
            HttpLogHandler httpLogHandler = new HttpLogHandler(bookingcomHttpHandler);

            var data = new HttpResult
            {
                Url = "http://test.com/user/max/info?pass=123456",
                RequestBody = "http://test.com?user=max&pass=123456",
                ResponseBody = "http://test.com?user=max&pass=123456"
            };

            //ACT
            httpLogHandler.Process(data);

            //ASSERT
            var expectedResult = new HttpResult
            {
                Url = "http://test.com/user/XXX/info?pass=XXXXXX",
                RequestBody = "http://test.com?user=XXX&pass=XXXXXX",
                ResponseBody = "http://test.com?user=XXX&pass=XXXXXX"
            };

            Assert.AreEqual(expectedResult, httpLogHandler.GetCurrentLog());
        }

        [TestMethod()]
        public void HttpLogHandler_Process_BookingcomHttpResultParametersProcess_ClearSecureData()
        {
            //ARRANGE
            IHttpResult bookingcomHttpHandler = new BookingcomHttpResult();
            HttpLogHandler httpLogHandler = new HttpLogHandler(bookingcomHttpHandler);

            var data = new HttpResult
            {
                Url = "http://test.com/user/max/info?pass=123456",
                RequestBody = "http://test.com?user=max&pass=123456",
                ResponseBody = "http://test.com?user=max&pass=123456"
            };

            //ACT
            httpLogHandler.Process(data.Url, data.RequestBody, data.ResponseBody);

            //ASSERT
            var expectedResult = new HttpResult
            {
                Url = "http://test.com/user/XXX/info?pass=XXXXXX",
                RequestBody = "http://test.com?user=XXX&pass=XXXXXX",
                ResponseBody = "http://test.com?user=XXX&pass=XXXXXX"
            };

            Assert.AreEqual(expectedResult, httpLogHandler.GetCurrentLog());
        }
    }
}