using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography;
using GatorCMS.Core.Connectors.MongoDB;
using GatorCMS.Core.Connectors.MongoGridFS;
using GatorCMS.Core.Models.Pages;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GatorCMS.Core.Services.GatorPagesService {
    public class GatorPagesService : IGatorPagesService {

        private readonly IMongoDBConnector _mongoDBConnector;
        private readonly IMongoGridFSConnector _mongoGridFSConnector;
        public GatorPagesService (IMongoDBConnector mongoDBConnector, IMongoGridFSConnector mongoGridFSConnector) {
            _mongoDBConnector = mongoDBConnector;
            _mongoGridFSConnector = mongoGridFSConnector;

        }

        public List<T> GetAllPages<T> () {
            var collection = _mongoDBConnector.GetGatorPagesCollection<T> ();
            var gatorPagesList = collection.Find (T => true)
                .ToList ();

            return gatorPagesList;
        }

        public List<T> GetPages<T> () where T : IBasePage {
            var collection = _mongoDBConnector.GetGatorPagesCollection<T> ();

            var gatorPagesList = collection.Find (x => x._id.ObjectType == typeof (T).FullName)
                .ToList ();

            return gatorPagesList;
        }

        public T GetPage<T> (Guid id) where T : IBasePage {
            var collection = _mongoDBConnector.GetGatorPagesCollection<T> ();
            var page = collection.Find (x => x._id.pageId == id).FirstOrDefault ();

            if (page != null) {
                return page;
            } else {
                throw new Exception ("Page not found");
            }
        }

        public T CreatePage<T> (T page) {
            var collection = _mongoDBConnector.GetGatorPagesCollection<T> ();

            collection.InsertOne (page);

             if (page is ArticlePage) {
                var articlePage = page as ArticlePage;

                if(articlePage.Image.Length > 0){
                    _mongoGridFSConnector.Upload(articlePage.Image,articlePage.ImageName,"ArticleImages");
                }
            }

            return page;

        }

        public void UpdatePage<T> (string id, T pageIn) {
            throw new NotImplementedException ();
        }

        public void RemovePage<T> (string id) {
            throw new NotImplementedException ();
        }

        public void RemovePage<T> (T pageIn) {
            throw new NotImplementedException ();
        }
    }
}