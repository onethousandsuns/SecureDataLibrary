using System.Collections.Generic;
using System.Linq;
using SecureData.DataHandlers;

namespace SecureData
{
    using configParam = Dictionary<string, string>;

    public abstract class AbstractHttpResultDataHandler
    {
        protected Dictionary<string, configParam> Properties { get; set; }

        protected AbstractHttpResultDataHandler()
        {
            Properties = new Dictionary<string, configParam>();
            InitProperties();
        }

        public HttpResult GetSecuredResult(HttpResult httpRes)
        {
            HttpResult result = new HttpResult
            {
                Url = GetHandledValue("URL", httpRes.Url),
                ResponseBody = GetHandledValue("RES", httpRes.ResponseBody),
                RequestBody = GetHandledValue("REQ", httpRes.RequestBody)
            };

            return result;
        }
        protected string GetHandledValue(string paramType, string data)
        {
            var handlerTypes = GetHandlerTypes(paramType);
            var result = data;
            foreach (var type in handlerTypes)
            {
                var handler = GetHandlerByTag(type);
                handler.Properties = GetPropValueArrayByTag(paramType, type);
                result = handler.GetSecuredData(result);
            }
            return result;
        }
        
        protected string[] GetPropValueArrayByTag(string paramType, string handlerTag)
        {
            List<string> result = new List<string>();
            foreach (var elem in Properties[paramType])
            {
                if (elem.Value == handlerTag)
                {
                    result.Add(elem.Key);
                }
            }
            return result.ToArray();
        }

        protected List<string> GetHandlerTypes(string key)
        {
            return Properties[key].Values.ToList().Distinct().ToList();
        }

        protected AbstractDataHandler GetHandlerByTag(string tag)
        {
            switch (tag)
            {
                case "JSON_DATA":
                    return new JsonDataHandler();
                case "JSON_ELEM":
                    return new JsonElementValueDataHandler();
                    return new RestUrlDataHandler();
                case "URL_GET":
                    return new UrlGetRequestDataHandler();
                case "XML_ATTR":
                    return new XmlAttributeDataHandler();
                case "XML_ELEM":
                    return new XmlElementValueDataHandler();
            }
            return null;
        }

        protected void InitProperties(configParam urlProps, configParam requestProps, configParam responseProps)
        {
            Properties.Add("URL", urlProps);
            Properties.Add("REQ", requestProps);
            Properties.Add("RES", responseProps);
        }

        protected virtual void InitProperties(){ }
    }
}
