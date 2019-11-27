using System;
using System.Collections.Generic;

namespace GatorCMS.Core.Wrappers.DBSettings
{
    public class LemonDBSettings : ILemonDBSettings
    {
        public string LemonsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
