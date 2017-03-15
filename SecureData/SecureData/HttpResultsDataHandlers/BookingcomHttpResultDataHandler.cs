using System.Collections.Generic;

namespace SecureData.HttpResultsDataHandlers
{
    public class BookingcomHttpResultDataHandler : AbstractHttpResultDataHandler
    {
        protected override void InitProperties()
        {
            InitProperties(
                new Dictionary<string, string> { { "user", "URL_REST" }, { "pass", "URL_REST" } },
                new Dictionary<string, string> { { "user", "URL_GET" }, { "pass", "URL_GET" } },
                new Dictionary<string, string> { { "user", "URL_GET" }, { "pass", "URL_GET" } } );
        }
    }
}
