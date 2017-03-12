using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureData.HttpResultsDataHandlers;

namespace SecureData.Tests
{
    [TestClass()]
    public class HttpLogHandlerTests
    {
        [TestMethod()]
        public void HttpLogHandler_Process_BookingcomHttpResultObjectProcess_ClearSecureData()
        {
            //ARRANGE
            IHttpResultDataHandler bookingcomHttpHandler = new BookingcomHttpResultDataHandler();
            HttpLogHandler httpLogHandler = new HttpLogHandler();

            var data = new HttpResult
            {
                Url = "http://test.com/user/max/info?pass=123456",
                RequestBody = "http://test.com?user=max&pass=123456",
                ResponseBody = "http://test.com?user=max&pass=123456"
            };

            //ACT
            httpLogHandler.Process(data, bookingcomHttpHandler);

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
            IHttpResultDataHandler bookingcomHttpHandler = new BookingcomHttpResultDataHandler();
            HttpLogHandler httpLogHandler = new HttpLogHandler();

            var data = new HttpResult
            {
                Url = "http://test.com/user/max/info?pass=123456",
                RequestBody = "http://test.com?user=max&pass=123456",
                ResponseBody = "http://test.com?user=max&pass=123456"
            };

            //ACT
            httpLogHandler.Process(data.Url, data.RequestBody, data.ResponseBody, bookingcomHttpHandler);

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