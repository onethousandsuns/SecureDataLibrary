using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SecureData.DataHandlers
{
    public class JsonDataHandler : IDataHandler
    {
        public override string GetSecuredData(string data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, string> dataDict = serializer.Deserialize<Dictionary<string, string>>(data);

            foreach (string key in properties)
            {
                if (dataDict.ContainsKey(key))
                {
                    string securedValue = new String('X', dataDict[key].Length);
                    dataDict[key] = securedValue;
                }
            }
            string result = serializer.Serialize(dataDict);

            return result;
        }
    }
}
