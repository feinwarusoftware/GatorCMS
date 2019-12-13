using GatorCMS.Core.Models.Pages;
using GraphQL.Types;
using System;
using System.Reflection;
using GraphQL.Language.AST;
using TypeExtensions = GraphQL.Types.TypeExtensions;

namespace GatorCMS.Core.Models
{
    public class PageType<T> : ObjectGraphType<T> where T : IBasePage
    {
        public PageType()
        {
            Name = typeof(T).ToString().Split(".")[^1];

            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                // Console.WriteLine(TypeExtensions.GraphTypeFromType(typeof(string) as IType, null).ToString());

                if (prop.PropertyType == typeof(string))
                {
                    var fieldType = new FieldType() { Name = prop.Name, Type = typeof(StringGraphType) };
                    AddField(fieldType);

                    // Field<StringGraphType>(prop.Name);
                } else if (prop.PropertyType == typeof(bool))
                {
                    Field<BooleanGraphType>(prop.Name);
                }
            }
        }
    }
}
