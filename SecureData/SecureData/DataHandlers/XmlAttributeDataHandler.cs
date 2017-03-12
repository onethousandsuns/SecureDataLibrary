using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SecureData.DataHandlers
{
    public class XmlAttributeDataHandler: AbstractDataHandler
    {
        public override string GetSecuredData(string data)
        {
            var result = data;

            foreach (var key in Properties)
            {
                var xmlAttrRegex = new Regex("(?<=\\b" + key + "=\")[^\"]*");
                result = xmlAttrRegex.Replace(result, new string('X', xmlAttrRegex.Match(result).Length));
            }
            return result;
        }
    }
}
