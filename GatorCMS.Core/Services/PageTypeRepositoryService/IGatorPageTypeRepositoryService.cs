namespace GatorCMS.Core.Services.PageTypeRepositoryService {
    public interface IGatorPageTypeRepositoryService {
        string GetAllPageTypes ();
        string GetPageType (System.Guid id);

        void AddPageType(string pageType);
    }
}