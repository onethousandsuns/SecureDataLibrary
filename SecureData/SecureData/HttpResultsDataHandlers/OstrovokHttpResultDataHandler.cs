﻿using SecureData.DataHandlers;

namespace SecureData.HttpResultsDataHandlers
{
    public class OstrovokHttpResultDataHandler : AbstractHttpResultDataHandler
    {
        protected override void InitProperties()
        {
            InitProperties(new string[] { "user", "pass" });
        }

        protected override void InitHandlers()
        {
            UrlHandler = new RestUrlDataHandler();
            RequestBodyHandler = new JsonDataHandler();
            ResponseBodyHandler = new JsonElementValueDataHandler();
        }
    }
}
