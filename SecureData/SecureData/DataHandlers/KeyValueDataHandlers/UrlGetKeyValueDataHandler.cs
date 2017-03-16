namespace SecureData.DataHandlers.KeyValueDataHandlers
{
    public class UrlGetKeyValueDataHandler : AbstractKeyValueDataHandler
    {
        public override string GetReplaceString(string key, string value)
        {
            return (key + "=" + value);
        }
    }
}
