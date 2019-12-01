using System.IO;
using MongoDB.Bson;

namespace GatorCMS.Core.Connectors.MongoGridFS {
    public interface IMongoGridFSConnector {
        ObjectId Upload (byte[] image, string imageName, string bucketName);
    }
}