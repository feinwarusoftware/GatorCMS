using System.Collections.Generic;
using GatorCMS.Core.Connectors.MongoDB;
using GatorCMS.Core.Models.Pages;
using MongoDB.Driver;

namespace GatorCMS.Core.Services.GatorPagesService {
    public class GatorPagesService : IGatorPagesService {

        private readonly IMongoDBConnector _mongoDBConnector;
        public GatorPagesService (IMongoDBConnector mongoDBConnector) {
            _mongoDBConnector = mongoDBConnector;
        }
        public List<BasePage> GetAllPages () {
            var collection = _mongoDBConnector.GetGatorPagesCollection ();

            var gatorPagesList = collection.Find(basePage => true)
                .ToList();
            
            return gatorPagesList;
        }
    }
}