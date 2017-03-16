using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
