using GatorCMS.Core.Models;
using GatorCMS.Core.Wrappers.DBSettings;
using MongoDB.Driver;

namespace GatorCMS.Core.Connectors.MongoDB {
    public class MongoDBConnector : IMongoDBConnector {
        private readonly ILemonDBSettings _lemonDatabaseSettings;

        public MongoDBConnector (ILemonDBSettings lemonDatabaseSettings) {
            _lemonDatabaseSettings = lemonDatabaseSettings;
        }

        public IMongoCollection<Lemon> GetLemonCollection() {
            var client = new MongoClient(_lemonDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(_lemonDatabaseSettings.DatabaseName);

            var lemons = database.GetCollection<Lemon>(_lemonDatabaseSettings.LemonsCollectionName);

            return lemons;
        }
    }
}
