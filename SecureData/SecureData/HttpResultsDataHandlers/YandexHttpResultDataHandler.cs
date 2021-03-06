﻿using System.Collections.Generic;

namespace SecureData.HttpResultsDataHandlers
{
    public class YandexHttpResultDataHandler: AbstractHttpResultDataHandler
    {
        protected override void InitProperties()
        {
            InitProperties(
                new Dictionary<string, string> { { "user", "URL_GET" }, { "pass", "URL_GET" } },
                new Dictionary<string, string> { { "user", "XML_ELEM" }, { "pass", "XML_ELEM" } },
                new Dictionary<string, string> { { "user", "XML_ATTR" }, { "pass", "XML_ATTR" } });
        }
    }
}
