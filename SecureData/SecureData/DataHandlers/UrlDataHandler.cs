using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SecureData.DataHandlers
{
    public class UrlGetRequestDataHandler : IDataHandler
    {
        public override string GetSecuredData(string data)
        {
            Uri uri = new Uri(data);
            var queryString = HttpUtility.ParseQueryString(uri.Query);

            foreach (string key in properties)
            {
                string param = queryString.Get(key);
                if(param != null)
                {
                    string securedValue = new String('X', param.Length);
                    queryString.Set(key, securedValue);
                }
            }
            var uriBuilder = new UriBuilder(uri);
            uriBuilder.Query = queryString.ToString();

            return uriBuilder.Uri.ToString();
        }
    }
}
