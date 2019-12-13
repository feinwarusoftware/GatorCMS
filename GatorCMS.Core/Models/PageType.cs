using GatorCMS.Core.Models.Pages;
using GraphQL.Types;
using System;
using System.Reflection;
using GraphQL.Utilities;

namespace GatorCMS.Core.Models
{
    public class PageType<T> : ObjectGraphType<T> where T : IBasePage
    {
        public PageType()
        {
            Name = typeof(T).ToString().Split(".")[^1];

            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                var type = GraphTypeTypeRegistry.Get(prop.PropertyType);
                if (type == null)
                {
                    Console.WriteLine("GatorCMS: Could not convert '" + prop.PropertyType + "' to graph type on " + Name + ".");
                    continue;
                }

                Field(type, prop.Name);
            }
        }
    }
}
