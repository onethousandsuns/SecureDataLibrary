namespace SecureData.DataHandlers.KeyValueDataHandlers
{
    public class XmlAttributeKeyValueDataHandler : AbstractKeyValueDataHandler
    {
        public override string GetReplaceString(string key, string value)
        {
            return (key + "=\"" + value + "\"");
        }
    }
}
