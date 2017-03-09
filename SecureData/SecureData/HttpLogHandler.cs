using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureData
{
    public class HttpLogHandler
    {
        protected HttpResult _currentLog;
        protected IHttpResult _handler;

        public HttpLogHandler(IHttpResult handler)
        {
            _handler = handler;
        }

        public HttpResult GetCurrentLog()
        {
            return _currentLog;
        }
        
        public void Process(HttpResult httpResult)
        {
            var securedHttpResult = new HttpResult();
            securedHttpResult = _handler.GetSecuredResult(httpResult);
            Log(securedHttpResult);
        }

        public void Process(string url, string req, string res)
        {
            var httpResult = new HttpResult
            {
                Url = url,
                RequestBody = req,
                ResponseBody = res
            };

            Process(httpResult);
        }

        protected void Log(HttpResult result)
        {
            _currentLog = new HttpResult
            {
                Url = result.Url,
                RequestBody = result.RequestBody,
                ResponseBody = result.ResponseBody
            };
        }
    }
}
