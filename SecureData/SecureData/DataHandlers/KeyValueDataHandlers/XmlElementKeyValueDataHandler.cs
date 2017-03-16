namespace SecureData.DataHandlers.KeyValueDataHandlers
{
    public class XmlElementKeyValueDataHandler : AbstractKeyValueDataHandler
    {
        public override string GetReplaceString(string key, string value)
        {
            return ("<" + key + ">"+ value + "</" + key + ">");
        }
    }
}
