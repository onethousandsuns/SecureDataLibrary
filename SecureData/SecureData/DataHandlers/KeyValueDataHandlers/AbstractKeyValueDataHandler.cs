using System.Collections.Generic;

namespace SecureData.DataHandlers.KeyValueDataHandlers
{
    public abstract class AbstractKeyValueDataHandler
    {
        public string GetSecuredData(string data)
        {
            var result = data;
            foreach (KeyValuePair<string, string> prop in Properties)
            {
                result = result.Replace(GetReplaceString(prop.Key, prop.Value), GetReplaceString(prop.Key, GetSecuredValue(prop.Value)));
            }
            return result;
        }

        public Dictionary<string, string> Properties { get; set; }

        public abstract string GetReplaceString(string key, string value);

        public string GetSecuredValue(string value)
        {
            return new string('X', value.Length);
        }
    }
}
