using GatorCMS.Core.Models.Pages;
using GatorCMS.Core.Wrappers.DB;
using MongoDB.Driver;

namespace GatorCMS.Core.Connectors.MongoDB {

    public class MongoDBConnector : IMongoDBConnector {

        private readonly IDBCredentials _dbCredentials;
        public MongoDBConnector (IDBCredentials dbCredentials) {
            _dbCredentials = dbCredentials;
        }

        public IMongoCollection<BasePage> GetGatorPagesCollection () {

            var client = new MongoClient (_dbCredentials.ConnectionString);

            var database = client.GetDatabase (_dbCredentials.DatabaseName);

            var gatorPagesCollection = database.GetCollection<BasePage> (_dbCredentials.GatorPagesCollection);

            return gatorPagesCollection;
        }
    }
}