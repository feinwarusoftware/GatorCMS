using GatorCMS.Core.Connectors.MongoDB;
using GatorCMS.Core.Models;
using MongoDB.Driver;
using NSubstitute;
using NUnit.Framework;

namespace GatorCMS.UnitTests.Connectors.MongoDBConnector
{
    [TestFixture]
    public class MongoDbConnectorTests
    {
        private  IMongoDBConnector _mongoDBConnector;

        [SetUp]
        public void Setup(){
            _mongoDBConnector = Substitute.For<IMongoDBConnector>();
        }

        [Test]
        public void GetGatorBoiiCollection_ValidRequest_ReturnsCollection(){
           
        }
        
    }
}