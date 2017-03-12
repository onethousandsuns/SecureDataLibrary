namespace SecureData.DataHandlers
{
    public class XmlDataHandler : AbstractDataHandler
    {
        public override string GetSecuredData(string data)
        {
            var xmlAttrHandler = new XmlAttributeDataHandler {Properties = Properties};
            var xmlElemValueHandler = new XmlElementValueDataHandler {Properties = Properties};

            return xmlAttrHandler.GetSecuredData(xmlElemValueHandler.GetSecuredData(data));
        }
    }
}
