using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureData.DataHandlers;


namespace SecureData.HttpResults
{
    public class BookingcomHttpResult : IHttpResult
    {
        protected override void InitHandlers()
        {
            UrlHandler = new RestUrlDataHandler();
            RequestBodyHandler = new UrlGetRequestDataHandler();
            ResponseBodyHandler = new UrlGetRequestDataHandler();
        }

        protected override void InitProperties()
        {
            InitProperties(
                new string[] { "user", "pass" });
        }
    }
}
