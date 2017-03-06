using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureData.DataHandlers;

namespace SecureData
{
    public abstract class IHttpResult
    {
        protected IDataHandler UrlHandler { set; get; }
        protected IDataHandler RequestBodyHandler { set; get; }
        protected IDataHandler ResponseBodyHandler { set; get; }
 
        public void getSecuredData()
        {

        }

        protected abstract void initProperties();

        protected abstract void initHandlers();
    }
}
