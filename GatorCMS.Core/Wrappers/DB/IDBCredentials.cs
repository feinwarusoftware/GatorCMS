namespace GatorCMS.Core.Wrappers.DB {
    public interface IDBCredentials {
        string GatorPagesCollection { get;}
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
}