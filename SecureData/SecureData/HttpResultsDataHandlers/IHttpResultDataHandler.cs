using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureData.DataHandlers;

namespace SecureData
{
    public abstract class IHttpResultDataHandler
    {
        protected IDataHandler UrlHandler { set; get; }
        protected IDataHandler RequestBodyHandler { set; get; }
        protected IDataHandler ResponseBodyHandler { set; get; }

        public IHttpResultDataHandler()
        {
            InitHandlers();
            InitProperties();
        }

        public HttpResult GetSecuredResult(HttpResult httpRes)
        {
            HttpResult result = new HttpResult();
            result.Url = UrlHandler.GetSecuredData(httpRes.Url);
            result.ResponseBody = UrlHandler.GetSecuredData(httpRes.ResponseBody);
            result.RequestBody = UrlHandler.GetSecuredData(httpRes.RequestBody);
            return result;
        }

        protected void InitProperties(string[] securedProps)
        {
            UrlHandler.properties = securedProps;
            RequestBodyHandler.properties = securedProps;
            ResponseBodyHandler.properties = securedProps;
        }

        protected abstract void InitProperties();
        protected abstract void InitHandlers();
    }
}
