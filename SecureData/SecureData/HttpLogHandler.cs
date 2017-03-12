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

        public HttpResult GetCurrentLog()
        {
            return _currentLog;
        }
        
        public void Process(HttpResult httpResult, IHttpResultDataHandler handler)
        {
            var securedHttpResult = new HttpResult();
            securedHttpResult = handler.GetSecuredResult(httpResult);
            Log(securedHttpResult);
        }

        public void Process(string url, string req, string res, IHttpResultDataHandler handler)
        {
            var httpResult = new HttpResult
            {
                Url = url,
                RequestBody = req,
                ResponseBody = res
            };

            Process(httpResult, handler);
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
