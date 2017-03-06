using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SecureData.DataHandlers
{
    public class RestUrlDataHandler : IDataHandler
    {
        public override string GetSecuredData(string data)
        {
            string[] splitedUrl = data.Split('/');
            
            foreach (string key in properties)
            {
                for (int i = 0; i < splitedUrl.Length; i++)
                {
                    if((splitedUrl[i] == key) && (i != splitedUrl.Length - 1))
                    {
                        splitedUrl[i + 1] = new String('X', splitedUrl[i + 1].Length);
                        i++;
                    }
                }
            }

            UrlDataHandler urlDataHandler = new UrlDataHandler();
            urlDataHandler.properties = this.properties;
            return urlDataHandler.GetSecuredData(String.Join("/", splitedUrl));
        }
    }
}
