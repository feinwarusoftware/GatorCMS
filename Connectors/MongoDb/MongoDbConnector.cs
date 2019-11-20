using GatorCms.Models;
using GatorCMS.Wrappers.DatabaseSettings;
using MongoDB.Driver;

namespace GatorCMS.Connectors.MongoDb {
    public class MongoDbConnector : IMongoDbConnector {
        private readonly IGatorDatabaseSettings _gatorDatabaseSettings;

        public MongoDbConnector (IGatorDatabaseSettings gatorDatabaseSettings) {
            _gatorDatabaseSettings = gatorDatabaseSettings;
         }

        public IMongoCollection<GatorBoii> GetGatorBoiiCollection()
        {
            var client = new MongoClient(_gatorDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(_gatorDatabaseSettings.DatabaseName);

            var books = database.GetCollection<GatorBoii>(_gatorDatabaseSettings.BooksCollectionName);

            return books;
        }
    }
}