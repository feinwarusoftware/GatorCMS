using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GatorCMS.Core.Models.Pages;
using GatorCMS.Core.Services.GatorPagesService;
using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace GatorCMS.Core.Models
{
    public class QueryType : ObjectGraphType
    {
        public QueryType(IGatorPagesService gatorPagesService) {

            Name = "Query";

            //Field<ListGraphType<PageType<GatorPage>>>(
            //    "rawrxd",
            //    resolve: context => gatorPagesService.GetPages<GatorPage>()
            //);

            var fieldType = new FieldType()
            {
                Name = "rawrxd",
                Description = "this lib broke lmao",
                DeprecationReason = null,
                Type = typeof(ListGraphType<PageType<GatorPage>>),
                Arguments = null,
                Resolver = new FuncFieldResolver<PageType<GatorPage>, object>(context => gatorPagesService.GetPages<GatorPage>())
            };

            AddField(fieldType);

            // Console.WriteLine(fieldType);
        }
    }
}
