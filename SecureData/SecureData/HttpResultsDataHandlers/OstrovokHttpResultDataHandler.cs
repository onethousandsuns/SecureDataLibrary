using System.Collections.Generic;

namespace SecureData.HttpResultsDataHandlers
{
    public class OstrovokHttpResultDataHandler : AbstractHttpResultDataHandler
    {
        protected override void InitProperties()
        {
            InitProperties(
                new Dictionary<string, string> { { "user", "URL_REST" }, { "pass", "URL_REST" } },
                new Dictionary<string, string> { { "user", "JSON_DATA" }, { "pass", "JSON_DATA" } },
                new Dictionary<string, string> { { "user", "JSON_ELEM" }, { "pass", "JSON_ELEM" } });
        }
    }
}
