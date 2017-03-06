using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureData.DataHandlers;


namespace SecureData.HttpResults
{
    class BookingcomHttpResult : IHttpResult
    {
        protected override void initHandlers()
        {
            UrlHandler = new UrlDataHandler();
            RequestBodyHandler = new RestUrlDataHandler();
            ResponseBodyHandler = new RestUrlDataHandler();
        }

        protected override void initProperties()
        {
            throw new NotImplementedException();
        }
    }
}
