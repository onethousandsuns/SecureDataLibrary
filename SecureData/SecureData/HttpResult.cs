using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureData
{
    public class HttpResult
    {
        public string Url { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is HttpResult)
            {
                var that = obj as HttpResult;
                if ((Url == that.Url)
                    && (RequestBody == that.RequestBody)
                    && (ResponseBody == that.ResponseBody))
                return true;
            }
            return false;
        }
    }
}
