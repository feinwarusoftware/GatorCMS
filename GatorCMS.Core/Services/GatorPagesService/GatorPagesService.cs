using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using GatorCMS.Core.Connectors.MongoDB;
using GatorCMS.Core.Models.Pages;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GatorCMS.Core.Services.GatorPagesService {
    public class GatorPagesService : IGatorPagesService {

        private readonly IMongoDBConnector _mongoDBConnector;
        public GatorPagesService (IMongoDBConnector mongoDBConnector) {
            _mongoDBConnector = mongoDBConnector;

        }

        public List<BasePage> GetAllPages () {
            var collection = _mongoDBConnector.GetGatorPagesCollection ();

            var gatorPagesList = collection.Find (basePage => true)
                .ToList ();

            return gatorPagesList;
        }

        public BasePage GetPage (ObjectId id) {
            var collection = _mongoDBConnector.GetGatorPagesCollection();

            var page = collection.Find(x => x.Id == id).FirstOrDefault();
            return page;
        }

        public BasePage CreateBasePage (BasePage page) {
            var collection = _mongoDBConnector.GetGatorPagesCollection ();

            collection.InsertOne (page);
            return page;

        }

        public void RemoveBasePage (string id) {
            throw new System.NotImplementedException ();
        }

        public void RemoveBasePage (BasePage pageIn) {
            throw new System.NotImplementedException ();
        }

        public void UpdateBasePage (string id, BasePage pageIn) {
            throw new System.NotImplementedException ();
        }
    }
}