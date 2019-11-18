using System.Collections.Generic;
using System.Linq;
using GatorCms.Models;
using GatorCMS.Connectors.MongoDb;
using GatorCMS.Services.Interfaces;
using MongoDB.Driver;

namespace GatorCMS.Services {
    public class GatorService : IGatorService {
        private readonly IMongoDbConnector _mongoDbConnector;

        public GatorService (IMongoDbConnector mongoDbConnector) {
            _mongoDbConnector = mongoDbConnector;
        }

        public List<GatorBoii> Get () {
            var collection = _mongoDbConnector.GetGatorBoiiCollection ();
            var gatorBoiiList = collection.Find (book => true)
                .ToList ();

            return gatorBoiiList;
        }

        public GatorBoii Get (string id) {
            var collection = _mongoDbConnector.GetGatorBoiiCollection ();
            var gatorBoii = collection.Find<GatorBoii> (book => book.Id == id)
                .FirstOrDefault ();

            return gatorBoii;
        }

        public GatorBoii Create (GatorBoii book) {
            var collection = _mongoDbConnector.GetGatorBoiiCollection ();
            collection.InsertOne (book);

            return book;
        }
        public void Update (string id, GatorBoii bookIn) {
            var collection = _mongoDbConnector.GetGatorBoiiCollection ();
            collection.ReplaceOne (book => book.Id == id, bookIn);
        }

        public void Remove (GatorBoii bookIn) {
            var collection = _mongoDbConnector.GetGatorBoiiCollection ();

        }

        public void Remove (GatorBoii bookIn, string id) {
            var collection = _mongoDbConnector.GetGatorBoiiCollection ();
            collection.DeleteOne (book => book.Id == bookIn.Id);
        }

    }
}