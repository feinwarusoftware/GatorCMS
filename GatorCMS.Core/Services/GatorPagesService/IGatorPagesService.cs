using System.Collections.Generic;
using GatorCMS.Core.Models.Pages;

namespace GatorCMS.Core.Services.GatorPagesService {
    public interface IGatorPagesService {
        List<BasePage> GetAllPages ();
        BasePage GetPage (string id);
        BasePage CreateBasePage (BasePage page);
        void UpdateBasePage (string id, BasePage pageIn);
        void RemoveBasePage (string id);
        void RemoveBasePage (BasePage pageIn);
    }
}