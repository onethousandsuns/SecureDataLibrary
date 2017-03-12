using System;
using System.Web;

namespace SecureData.DataHandlers
{
    public class UrlGetRequestDataHandler : AbstractDataHandler
    {
        public override string GetSecuredData(string data)
        {
            var uri = new Uri(data);
            var queryString = HttpUtility.ParseQueryString(uri.Query);
            if (queryString.Count != 0)
            {
                var urlPath = data.Replace(queryString.ToString(), "");

                foreach (var key in Properties)
                {
                    var param = queryString.Get(key);
                    if (param != null)
                    {
                        var securedValue = new string('X', param.Length);
                        queryString.Set(key, securedValue);
                    }
                }
                return urlPath + queryString;
            }
            return data;
        }
    }
}
