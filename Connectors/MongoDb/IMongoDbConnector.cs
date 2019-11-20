using GatorCms.Models;
using MongoDB.Driver;

namespace GatorCMS.Connectors.MongoDb {
    public interface IMongoDbConnector {
        IMongoCollection<GatorBoii> GetGatorBoiiCollection ();
    }
}