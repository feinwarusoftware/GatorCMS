using GatorCMS.Core.Models;
using MongoDB.Driver;

namespace GatorCMS.Core.Connectors.MongoDB
{
    public interface IMongoDBConnector
    {
         IMongoCollection<Lemon> GetLemonCollection();
    }
}
