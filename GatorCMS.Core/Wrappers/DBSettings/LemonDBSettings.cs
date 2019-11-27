using Microsoft.Extensions.Configuration;

namespace GatorCMS.Core.Wrappers.DBSettings
{
    public class LemonDBSettings : ILemonDBSettings
    {
        private readonly IConfiguration _config;

        public LemonDBSettings(IConfiguration config)
        {
            _config = config;
        }

        public string LemonsCollectionName => _config.GetSection("LemonDBSettings").GetValue<string>("LemonsCollectionName");
        public string ConnectionString => _config.GetSection("LemonDBSettings").GetValue<string>("ConnectionString");
        public string DatabaseName => _config.GetSection("LemonDBSettings").GetValue<string>("DatabaseName");
    }
}
