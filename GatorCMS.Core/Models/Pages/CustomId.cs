using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatorCMS.Core.Models.Pages
{
    public class CustomID
    {
        private CustomID()
        {

        }

        public CustomID(string objectType)
        {
            ObjectType = objectType;
            dateTimeCreated = DateTime.Now;
            pageId = Guid.NewGuid();
        }

        public DateTime dateTimeCreated { get; set; }
        public string ObjectType { get; set; }
        public Guid pageId { get; set; }
    }
}
