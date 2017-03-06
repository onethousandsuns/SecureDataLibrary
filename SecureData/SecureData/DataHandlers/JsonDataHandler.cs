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
        public override void GetSecuredData(string data)
        {
            JavaScriptSerializer j = new JavaScriptSerializer();
            Dictionary<string, string> a = j.Deserialize<Dictionary<string, string>>(data);

            foreach (string prop in properties)
            {
                //string securedValue = new String('X', a);

            }
        }
    }
}
