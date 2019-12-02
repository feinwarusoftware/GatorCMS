using GatorCMS.Core.Models.Pages;
using GraphQL.Types;
using System;

namespace GatorCMS.Core.Models
{
    public class PageType<T> : ObjectGraphType<T> where T : IBasePage
    {
        public PageType()
        {
            Name = "Page";

            Type type = this.GetType();
            foreach (var f in type.GetFields())
            {
                if (f.IsPublic)
                {
                    Field(_ => f);
                }
            }
        }
    }
}
