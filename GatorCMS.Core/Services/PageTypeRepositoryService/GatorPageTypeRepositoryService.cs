using System;
using GatorCMS.Core.Connectors.MongoDB;

namespace GatorCMS.Core.Services.PageTypeRepositoryService
{
    public class GatorPageTypeRepositoryService : IGatorPageTypeRepositoryService
    {
        private readonly IMongoDBConnector _mongoDBConnector;

        public GatorPageTypeRepositoryService(IMongoDBConnector _mongoDBConnector){
            
        }

        public void AddPageType(string pageType)
        {
            throw new NotImplementedException();
        }

        public string GetAllPageTypes()
        {
            throw new NotImplementedException();
        }

        public string GetPageType(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}