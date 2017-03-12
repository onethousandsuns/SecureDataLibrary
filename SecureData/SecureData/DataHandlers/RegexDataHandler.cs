using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SecureData.DataHandlers
{
    public class RegexDataHandler: AbstractDataHandler
    {
        private string RegExpString { get; set; }

        public override string GetSecuredData(string data)
        {
            var result = data;

            foreach (var key in Properties)
            {
                var replacedValueString = RegExpString.Replace("|REPLACED_VALUE|", key);
                var elemRegex = new Regex(replacedValueString);
                result = elemRegex.Replace(result, new string('X', elemRegex.Match(result).Length));
            }
            return result;
        }

        public RegexDataHandler(string regExp, string[] properties)
        {
            Properties = properties;
            RegExpString = regExp;
        }
    }
}
