namespace SecureData.DataHandlers
{
    public class RestUrlDataHandler : AbstractDataHandler
    {
        public override string GetSecuredData(string data)
        {
            var splitedUrl = data.Split('/');
            
            foreach (var key in Properties)
            {
                for (var i = 0; i < splitedUrl.Length; i++)
                {
                    if((splitedUrl[i] == key) && (i != splitedUrl.Length - 1))
                    {
                        splitedUrl[i + 1] = new string('X', splitedUrl[i + 1].Length);
                        i++;
                    }
                }
            }

            var urlDataHandler = new UrlGetRequestDataHandler
            {
                Properties = this.Properties
            };
            return urlDataHandler.GetSecuredData(string.Join("/", splitedUrl));
        }
    }
}
