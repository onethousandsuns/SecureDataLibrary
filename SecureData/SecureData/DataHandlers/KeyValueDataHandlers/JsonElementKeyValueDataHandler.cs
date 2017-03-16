namespace SecureData.DataHandlers.KeyValueDataHandlers
{
    public class JsonElementKeyValueDataHandler : AbstractKeyValueDataHandler
    {
        public override string GetReplaceString(string key, string value)
        {
            return (key + ": value:\"" + value + "\"");
        }
    }
}
