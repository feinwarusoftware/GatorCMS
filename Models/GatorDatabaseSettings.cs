namespace GatorCMS.Models
{
    public class GatorDatabaseSettings : IGatorDatabaseSettings
    {
        public string GatorBoiiCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IGatorDatabaseSettings
    {
        string GatorBoiiCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
