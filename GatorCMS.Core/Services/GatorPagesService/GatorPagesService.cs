using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography;
using GatorCMS.Core.Connectors.MongoDB;
using GatorCMS.Core.Models.Pages;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GatorCMS.Core.Services.GatorPagesService
{
    public class GatorPagesService : IGatorPagesService
    {

        private readonly IMongoDBConnector _mongoDBConnector;
        public GatorPagesService(IMongoDBConnector mongoDBConnector)
        {
            _mongoDBConnector = mongoDBConnector;

        }

        public List<T> GetAllPages<T>()
        {
            var collection = _mongoDBConnector.GetGatorPagesCollection<T>();
            var gatorPagesList = collection.Find(T => true)
                .ToList();

            return gatorPagesList;
        }

        public List<T> GetPages<T>() where T : IBasePage
        {
            var collection = _mongoDBConnector.GetGatorPagesCollection<T>();

            var gatorPagesList = collection.Find(x => x._id.ObjectType == typeof(T).FullName)
                .ToList();

            return gatorPagesList;
        }

        public T GetPage<T>(Guid id) where T : IBasePage
        {

            var collection = _mongoDBConnector.GetGatorPagesCollection<T>();
            var page = collection.Find(x => x._id.pageId == id).FirstOrDefault();

            if (page != null)
            {
                return page;
            }
            else
            {
                throw new Exception("Page not found");
            }
        }

        public T CreatePage<T>(T page)
        {
            var collection = _mongoDBConnector.GetGatorPagesCollection<T>();

            collection.InsertOne(page);
            return page;

        }

        public void UpdatePage<T>(string id, T pageIn)
        {
            throw new NotImplementedException();
        }

        public void RemovePage<T>(string id)
        {
            throw new NotImplementedException();
        }

        public void RemovePage<T>(T pageIn)
        {
            throw new NotImplementedException();
        }

        private static T GetTfromString<T>(string mystring)
        {
            var foo = TypeDescriptor.GetConverter(typeof(T));
            return (T)(foo.ConvertFromInvariantString(mystring));
        }
    }
}