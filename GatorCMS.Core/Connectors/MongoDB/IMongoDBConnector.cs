using GatorCMS.Core.Models.Pages;
using MongoDB.Driver;

namespace GatorCMS.Core.Connectors.MongoDB {
    public interface IMongoDBConnector {
        IMongoCollection<T> GetGatorPagesCollection<T> ();

        IMongoDatabase GetGatorDatabase();

        IMongoCollection<T> GetGatorPageTypeCollection<T>();
    }
}