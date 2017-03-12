using System.Text.RegularExpressions;

namespace SecureData.DataHandlers
{
    public class XmlElementValueDataHandler : AbstractDataHandler
    {
        public override string GetSecuredData(string data)
        {
            var result = data;

            foreach (var key in Properties)
            {
                var xmlElemValueRegex = new Regex("(?<=<" + key + ">).+?(?=</" + key + ">)");
                result = xmlElemValueRegex.Replace(result, new string('X', xmlElemValueRegex.Match(result).Length));
            }
            return result;
        }
    }
}
