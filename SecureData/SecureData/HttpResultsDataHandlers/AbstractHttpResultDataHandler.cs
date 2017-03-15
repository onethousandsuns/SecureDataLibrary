using System;
using System.Collections.Generic;
using System.Linq;
using SecureData.DataHandlers;

namespace SecureData
{
    using configParam = Dictionary<string, string>;

    public abstract class AbstractHttpResultDataHandler
    {
        protected Dictionary<string, AbstractDataHandler> Handlers { get; set; }
        protected Dictionary<string, configParam> Properties { get; set; }

        protected AbstractHttpResultDataHandler()
        {
            Properties = new Dictionary<string, configParam>();
            Handlers = new Dictionary<string, AbstractDataHandler>();
            InitProperties();
            InitLibraryHandlers();
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
            if (!Handlers.ContainsKey(tag))
            {
                throw new HandlerNotExistException("Handler with tag \"" + tag + "\" not exists.");
            }
            return Handlers[tag];
        }

        public Exception HandlerNotExistException { get; set; }

        protected void InitProperties(configParam urlProps, configParam requestProps, configParam responseProps)
        {
            Properties.Add("URL", urlProps);
            Properties.Add("REQ", requestProps);
            Properties.Add("RES", responseProps);
        }

        protected virtual void InitProperties(){ }

        private void InitLibraryHandlers()
        {
            Handlers.Add("JSON_DATA", new JsonDataHandler());
            Handlers.Add("JSON_ELEM", new JsonElementValueDataHandler());
            Handlers.Add("URL_REST", new RestUrlDataHandler());
            Handlers.Add("URL_GET", new UrlGetRequestDataHandler());
            Handlers.Add("XML_ATTR", new XmlAttributeDataHandler());
            Handlers.Add("XML_ELEM", new XmlElementValueDataHandler());
        }

        protected void AddUserDataHandler(string tag, AbstractDataHandler handler)
        {
            if (!Handlers.ContainsKey(tag))
            {
                throw new HandlerAlreadyExistException("Handler with tag \"" + tag + "\" already exists.");
            }
            Handlers.Add(tag, handler);
        }

    }

    public class HandlerAlreadyExistException : Exception
    {
        public HandlerAlreadyExistException(string message) : base(message)
        {
        }
    }

    public class HandlerNotExistException : Exception
    {
        public HandlerNotExistException(string message) : base(message)
        {
        }
    }
}
