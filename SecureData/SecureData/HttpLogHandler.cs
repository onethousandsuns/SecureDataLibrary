namespace SecureData
{
    public class HttpLogHandler
    {
        protected HttpResult CurrentLog;

        public HttpResult GetCurrentLog()
        {
            return CurrentLog;
        }
        
        public void Process(HttpResult httpResult, AbstractHttpResultDataHandler handler)
        {
            var securedHttpResult = handler.GetSecuredResult(httpResult);
            Log(securedHttpResult);
        }

        public void Process(string url, string req, string res, AbstractHttpResultDataHandler handler)
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
            CurrentLog = new HttpResult
            {
                Url = result.Url,
                RequestBody = result.RequestBody,
                ResponseBody = result.ResponseBody
            };
        }
    }
}
