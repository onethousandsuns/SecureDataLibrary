namespace SecureData.DataHandlers.KeyValueDataHandlers
{
    public class RestUrlKeyValueDataHandler : AbstractKeyValueDataHandler
    {
        public override string GetReplaceString(string key, string value)
        {
            return (key + "/" + value);
        }
    }
}
