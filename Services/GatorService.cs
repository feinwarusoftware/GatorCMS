using GatorCms.Controllers;
using GatorCMS.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace GatorCMS.Services
{
    public class GatorService
    {
        private readonly IMongoCollection<GatorBoii> _books;

        public GatorService(IGatorDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<GatorBoii>(settings.GatorBoiiCollectionName);
        }

        public List<GatorBoii> Get() =>
            _books.Find(book => true).ToList();

        public GatorBoii Get(string id) =>
            _books.Find<GatorBoii>(book => book.Id == id).FirstOrDefault();

        public GatorBoii Create(GatorBoii book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, GatorBoii bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(GatorBoii bookIn) =>
            _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) => 
            _books.DeleteOne(book => book.Id == id);
    }
}
