using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace SecureData.DataHandlers
{
    public class JsonDataHandler : AbstractDataHandler
    {
        public override string GetSecuredData(string data)
        {
            var serializer = new JavaScriptSerializer();
            var dataDict = serializer.Deserialize<Dictionary<string, string>>(data);

            foreach (var key in Properties)
            {
                if (dataDict.ContainsKey(key))
                {
                    var securedValue = new string('X', dataDict[key].Length);
                    dataDict[key] = securedValue;
                }
            }
            var result = serializer.Serialize(dataDict);

            return result;
        }
    }
}
