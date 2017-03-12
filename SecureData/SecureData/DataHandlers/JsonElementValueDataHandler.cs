using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace SecureData.DataHandlers
{
    public class JsonElementValueDataHandler : AbstractDataHandler
    {
        public override string GetSecuredData(string data)
        {
            var serializer = new JavaScriptSerializer();
            var dataDict = serializer.Deserialize<dynamic>(data);
            foreach (var key in Properties)
            {
                if (dataDict.ContainsKey(key))
                {
                    var x = dataDict[key]["value"];
                    var securedValue = new string('X', dataDict[key]["value"].Length);
                    dataDict[key]["value"] = securedValue;
                }
            }
            var result = serializer.Serialize(dataDict);

            return result;
        }
    }
}
