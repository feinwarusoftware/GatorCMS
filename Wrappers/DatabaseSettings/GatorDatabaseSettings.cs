using Microsoft.Extensions.Configuration;

namespace GatorCMS.Wrappers.DatabaseSettings
{
    public class GatorDatabaseSettings : IGatorDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}