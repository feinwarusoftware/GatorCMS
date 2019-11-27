namespace GatorCMS.Core.Wrappers.DBSettings
{
    public interface ILemonDBSettings
    {
        string LemonsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
