namespace SecureData.DataHandlers.KeyValueDataHandlers
{
    public class JsonKeyValueDataHandler : AbstractKeyValueDataHandler
    {
        public override string GetReplaceString(string key, string value)
        {
            return (key + ": \"" + value + "\"");
        }
    }
}
