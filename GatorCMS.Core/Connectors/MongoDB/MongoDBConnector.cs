using GatorCMS.Core.Models;
using GatorCMS.Core.Wrappers.DBSettings;
using MongoDB.Driver;

namespace GatorCMS.Core.Connectors.MongoDB {
    public class MongoDBConnector : IMongoDBConnector {
        private readonly IGatorDBSettings _gatorDatabaseSettings;

        public MongoDBConnector (IGatorDBSettings gatorDatabaseSettings) {
            _gatorDatabaseSettings = gatorDatabaseSettings;
        }

        public IMongoCollection<GatorBoii> GetGatorBoiiCollection () {
            var client = new MongoClient (_gatorDatabaseSettings.ConnectionString);
            var database = client.GetDatabase (_gatorDatabaseSettings.DatabaseName);

            var books = database.GetCollection<GatorBoii> (_gatorDatabaseSettings.BooksCollectionName);

            return books;
        }
    }
}