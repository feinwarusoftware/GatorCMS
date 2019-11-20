namespace GatorCMS.Wrappers.DatabaseSettings {
    public interface IGatorDatabaseSettings {
        string BooksCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}