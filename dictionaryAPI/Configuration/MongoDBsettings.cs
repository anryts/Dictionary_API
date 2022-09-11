namespace dictionaryAPI.Configuration
{
    public class MongoDBsettings
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public string ConnectionString 
        { get
            {
                return $"mongodb ://{Host}:{Port}";
            }
         }
    }
}
