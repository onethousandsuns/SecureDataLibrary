﻿using System.Text.RegularExpressions;

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
