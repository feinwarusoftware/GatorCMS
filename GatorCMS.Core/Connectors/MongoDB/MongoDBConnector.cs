using GatorCMS.Core.Models.Pages;
using GatorCMS.Core.Wrappers.DB;
using MongoDB.Driver;

namespace GatorCMS.Core.Connectors.MongoDB {

    public class MongoDBConnector : IMongoDBConnector {

        private readonly IDBCredentials _dbCredentials;
        public MongoDBConnector (IDBCredentials dbCredentials) {
            _dbCredentials = dbCredentials;
        }

        public IMongoCollection<T> GetGatorPagesCollection<T> () {

            var database = GetGatorDatabase ();

            var gatorPagesCollection = database.GetCollection<T> (_dbCredentials.GatorPagesCollection);

            return gatorPagesCollection;
        }

        public IMongoDatabase GetGatorDatabase () {
            var client = new MongoClient (_dbCredentials.ConnectionString);
            var database = client.GetDatabase (_dbCredentials.DatabaseName);

            return database;
        }
    }
}