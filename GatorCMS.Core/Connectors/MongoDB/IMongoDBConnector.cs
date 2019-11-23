using GatorCMS.Core.Models.Pages;
using MongoDB.Driver;

namespace GatorCMS.Core.Connectors.MongoDB {
    public interface IMongoDBConnector {
        IMongoCollection<BasePage> GetGatorPagesCollection ();
    }
}