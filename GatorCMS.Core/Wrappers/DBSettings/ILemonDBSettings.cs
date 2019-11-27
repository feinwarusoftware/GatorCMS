namespace GatorCMS.Core.Wrappers.DBSettings
{
    public interface ILemonDBSettings
    {
        string LemonsCollectionName { get; }
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
}
