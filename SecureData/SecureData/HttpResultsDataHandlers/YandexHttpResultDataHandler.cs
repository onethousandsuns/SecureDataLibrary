using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureData.DataHandlers;

namespace SecureData.HttpResultsDataHandlers
{
    public class YandexHttpResultDataHandler: AbstractHttpResultDataHandler
    {
        protected override void InitProperties()
        {
            InitProperties(new string[] { "user", "pass" });
        }

        protected override void InitHandlers()
        {
            UrlHandler = new UrlGetRequestDataHandler();
            RequestBodyHandler = new XmlElementValueDataHandler();
            ResponseBodyHandler = new XmlAttributeDataHandler();
        }
    }
}
