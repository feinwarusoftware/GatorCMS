using Microsoft.Extensions.Configuration;

namespace GatorCMS.Core.Wrappers.DB
{
    public class DBCredentials : IDBCredentials
    {
        private readonly IConfiguration _config;

        public DBCredentials (IConfiguration config) {
            _config = config;

        }
        public string GatorPagesCollection  => _config.GetSection("MongoDBSettings").GetValue<string>("GatorPagesCollection");
        public string GatorPageTypeCollection => _config.GetSection("MongoDBSettings").GetValue<string>("GatorPageTypeCollection");
        public string ConnectionString => _config.GetSection("MongoDBSettings").GetValue<string>("ConnectionString");
        public string DatabaseName => _config.GetSection("MongoDBSettings").GetValue<string>("DatabaseName");
    }
}