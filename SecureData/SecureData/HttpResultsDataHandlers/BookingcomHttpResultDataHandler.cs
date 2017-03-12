using SecureData.DataHandlers;


namespace SecureData.HttpResultsDataHandlers
{
    public class BookingcomHttpResultDataHandler : AbstractHttpResultDataHandler
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
