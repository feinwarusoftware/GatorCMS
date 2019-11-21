namespace GatorCMS.Core.Wrappers.DBSettings {
    public interface IGatorDBSettings {
        string BooksCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}