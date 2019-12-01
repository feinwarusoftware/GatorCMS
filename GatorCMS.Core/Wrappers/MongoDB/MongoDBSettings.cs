using Microsoft.Extensions.Configuration;

namespace GatorCMS.Core.Wrappers.MongoDB
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string GatorPagesCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMongoDBSettings
    {
        string GatorPagesCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}