namespace SecureData.DataHandlers
{
    public abstract class AbstractDataHandler
    {
        public abstract string GetSecuredData(string data);

        public string[] Properties { get; set; }
    }
}
