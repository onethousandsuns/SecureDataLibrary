using SecureData.DataHandlers;

namespace SecureData
{
    public abstract class AbstractHttpResultDataHandler
    {
        protected AbstractDataHandler UrlHandler { set; get; }
        protected AbstractDataHandler RequestBodyHandler { set; get; }
        protected AbstractDataHandler ResponseBodyHandler { set; get; }

        protected AbstractHttpResultDataHandler()
        {
            InitHandlers();
            InitProperties();
        }

        public HttpResult GetSecuredResult(HttpResult httpRes)
        {
            HttpResult result = new HttpResult
            {
                Url = UrlHandler.GetSecuredData(httpRes.Url),
                ResponseBody = ResponseBodyHandler.GetSecuredData(httpRes.ResponseBody),
                RequestBody = RequestBodyHandler.GetSecuredData(httpRes.RequestBody)
            };
            return result;
        }

        protected void InitProperties(string[] securedProps)
        {
            UrlHandler.Properties = securedProps;
            RequestBodyHandler.Properties = securedProps;
            ResponseBodyHandler.Properties = securedProps;
        }

        protected abstract void InitProperties();
        protected abstract void InitHandlers();
    }
}
