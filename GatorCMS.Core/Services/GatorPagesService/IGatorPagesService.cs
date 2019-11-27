using System.Collections.Generic;
using GatorCMS.Core.Models.Pages;
using MongoDB.Bson;

namespace GatorCMS.Core.Services.GatorPagesService {
    public interface IGatorPagesService {
        List<BasePage> GetAllPages ();
        BasePage GetPage (ObjectId id);
        BasePage CreateBasePage (BasePage page);
        void UpdateBasePage (string id, BasePage pageIn);
        void RemoveBasePage (string id);
        void RemoveBasePage (BasePage pageIn);
    }
}