using System.Collections.Generic;
using GatorCMS.Core.Connectors.MongoDB;
using GatorCMS.Core.Models;
using MongoDB.Driver;

namespace GatorCMS.Core.Services.LemonService
{
    public class LemonService : ILemonService
    {
        private readonly IMongoDBConnector _mongoDbConnector;

        public LemonService(IMongoDBConnector mongoDbConnector) {
            _mongoDbConnector = mongoDbConnector;
        }

        public List<Lemon> Get() {
            var collection = _mongoDbConnector.GetLemonCollection();
            var lemonList = collection.Find(lemon => true).ToList();

            return lemonList;
        }

        public Lemon Get(string id) {
            var collection = _mongoDbConnector.GetLemonCollection();
            var lemon = collection.Find<Lemon> (book => book.Id == id).FirstOrDefault();

            return lemon;
        }

        public Lemon Create(Lemon lemon) {
            var collection = _mongoDbConnector.GetLemonCollection();
            collection.InsertOne(lemon);

            return lemon;
        }
        public void Update(string id, Lemon lemon) {
            var collection = _mongoDbConnector.GetLemonCollection();
            collection.ReplaceOne(lemon => lemon.Id == id, lemon);
        }

        public void Remove(string id) {
            var collection = _mongoDbConnector.GetLemonCollection();
            collection.DeleteOne(lemon => lemon.Id == id);
        }
    }
}
