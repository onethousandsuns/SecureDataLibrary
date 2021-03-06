﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecureData;
using SecureData.HttpResultsDataHandlers;

namespace SecureDataTests
{
    [TestClass()]
    public class HttpLogHandlerTests
    {
        [TestMethod()]
        public void HttpLogHandler_Process_BookingcomHttpResultHandle_ClearSecureData()
        {
            //ARRANGE
            AbstractHttpResultDataHandler bookingcomHttpHandler = new BookingcomHttpResultDataHandler();
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
        public void HttpLogHandler_Process_YandexHttpResultHandle_ClearSecureData()
        {
            //ARRANGE
            var handler = new YandexHttpResultDataHandler();
            HttpLogHandler httpLogHandler = new HttpLogHandler();

            var data = new HttpResult
            {
                Url = "http://test.com?user=max&pass=123456",
                RequestBody = "<auth><user>max</user><pass>123456</pass></auth>",
                ResponseBody = "<auth user=\"max\" pass=\"123456\">"
            };

            //ACT
            httpLogHandler.Process(data, handler);

            //ASSERT
            var expectedResult = new HttpResult
            {
                Url = "http://test.com?user=XXX&pass=XXXXXX",
                RequestBody = "<auth><user>XXX</user><pass>XXXXXX</pass></auth>",
                ResponseBody = "<auth user=\"XXX\" pass=\"XXXXXX\">"
            };

            Assert.AreEqual(expectedResult, httpLogHandler.GetCurrentLog());
        }

        [TestMethod()]
        public void HttpLogHandler_Process_AgodaHttpResultHandle_ClearSecureData()
        {
            //ARRANGE
            var handler = new AgodaHttpResultDataHandler();
            HttpLogHandler httpLogHandler = new HttpLogHandler();

            var data = new HttpResult
            {
                Url = "http://test.com?user=max&pass=123456",
                RequestBody = @"
                <auth>
                    <user>max</user>
                    <pass>123456</pass>
                </auth>",
                ResponseBody = "<auth user=\"max\" pass=\"123456\">"
            };

            //ACT
            httpLogHandler.Process(data, handler);

            //ASSERT
            var expectedResult = new HttpResult
            {
                Url = "http://test.com?user=XXX&pass=XXXXXX",
                RequestBody = @"
                <auth>
                    <user>XXX</user>
                    <pass>XXXXXX</pass>
                </auth>",
                ResponseBody = "<auth user=\"XXX\" pass=\"XXXXXX\">"
            };

            Assert.AreEqual(expectedResult, httpLogHandler.GetCurrentLog());
        }

        [TestMethod()]
        public void HttpLogHandler_Process_OstrovokHttpResultHandle_ClearSecureData()
        {
            //ARRANGE
            var handler = new OstrovokHttpResultDataHandler();
            HttpLogHandler httpLogHandler = new HttpLogHandler();

            var data = new HttpResult
            {
                Url = "http://test.com/user/max/info",
                RequestBody = "{user:\"max\",pass:\"123456\"}",
                ResponseBody = "{user:{value:\"max\"},pass:{value:\"123456\"}}"
            };

            //ACT
            httpLogHandler.Process(data, handler);

            //ASSERT
            var expectedResult = new HttpResult
            {
                Url = "http://test.com/user/XXX/info",
                RequestBody = "{\"user\":\"XXX\",\"pass\":\"XXXXXX\"}",
                ResponseBody = "{\"user\":{\"value\":\"XXX\"},\"pass\":{\"value\":\"XXXXXX\"}}"
            };

            Assert.AreEqual(expectedResult, httpLogHandler.GetCurrentLog());
        }

        [TestMethod()]
        public void HttpLogHandler_Process_GoogleHttpResultHandle_ClearSecureData()
        {
            //ARRANGE
            var handler = new GoogleHttpResultDataHandler();
            var httpLogHandler = new HttpLogHandler();

            var data = new HttpResult
            {
                Url = "http://test.com?user=max&pass=123456",
                RequestBody = @"
                    <auth user=""max"">
                        <pass>123456</pass>
                    </auth>",
                ResponseBody = @"
                    <auth pass=""123456"">
                        <user>max</user>
                    </auth>"
            };

            //ACT
            httpLogHandler.Process(data, handler);

            //ASSERT
            var expectedResult = new HttpResult
            {
                Url = "http://test.com?user=XXX&pass=XXXXXX",
                RequestBody = @"
                    <auth user=""XXX"">
                        <pass>XXXXXX</pass>
                    </auth>",
                ResponseBody = @"
                    <auth pass=""XXXXXX"">
                        <user>XXX</user>
                    </auth>"
            };

            Assert.AreEqual(expectedResult, httpLogHandler.GetCurrentLog());
        }

        [TestMethod()]
        public void HttpLogHandler_Process_ExpediaHttpResultHandle_ClearSecureData()
        {
            //ARRANGE
            var handler = new ExpediaHttpResultDataHandler();
            HttpLogHandler httpLogHandler = new HttpLogHandler();

            var data = new HttpResult
            {
                Url = "http://test.com/user/max/info",
                RequestBody = @"
                {
                       user : ""max"",
                       pass : ""123456""
                }",
                ResponseBody = @"
                {
                       user : {
                             value : ""max""
                       },
                       pass : {
                             value : ""123456""
                       }
                }"
            };

            //ACT
            httpLogHandler.Process(data, handler);

            //ASSERT
            var expectedResult = new HttpResult
            {
                Url = "http://test.com/user/XXX/info",
                RequestBody = "{\"user\":\"XXX\",\"pass\":\"XXXXXX\"}",
                ResponseBody = "{\"user\":{\"value\":\"XXX\"},\"pass\":{\"value\":\"XXXXXX\"}}"
            };

            Assert.AreEqual(expectedResult, httpLogHandler.GetCurrentLog());
        }
    }
}