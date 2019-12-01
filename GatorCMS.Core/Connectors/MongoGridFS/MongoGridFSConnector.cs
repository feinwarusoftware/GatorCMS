using System.IO;
using System.Threading.Tasks;
using GatorCMS.Core.Connectors.MongoDB;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace GatorCMS.Core.Connectors.MongoGridFS {
    public class MongoGridFSConnector : IMongoGridFSConnector {

        private readonly IMongoDBConnector _mongoDBConnector;

        public MongoGridFSConnector (IMongoDBConnector mongoDBConnector) {
            _mongoDBConnector = mongoDBConnector;
        }

        public ObjectId Upload (byte[] image, string imageName, string bucketName) {
            var database = _mongoDBConnector.GetGatorDatabase ();
            var bucket = GetBucket (database, bucketName);

            var options = new GridFSUploadOptions {
                ChunkSizeBytes = 64512, // 63KB
                Metadata = new BsonDocument { { "resolution", "1080P" }, { "copyrighted", true }
                }
            };

            var id = bucket.UploadFromBytes (imageName, image, options);

            return id;

        }

        private GridFSBucket GetBucket (IMongoDatabase database, string bucketName) {
            var bucket = new GridFSBucket (database, new GridFSBucketOptions {
                BucketName = bucketName,
                    ChunkSizeBytes = 2097152, //2mb
                    WriteConcern = WriteConcern.WMajority,
                    ReadPreference = ReadPreference.Secondary
            });

            return bucket;
        }
    }
}