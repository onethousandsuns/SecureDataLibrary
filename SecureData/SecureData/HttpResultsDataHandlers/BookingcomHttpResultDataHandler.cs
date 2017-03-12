using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureData.DataHandlers;


namespace SecureData.HttpResultsDataHandlers
{
    public class BookingcomHttpResultDataHandler : IHttpResultDataHandler
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
