using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GatorCMS.Core.Models.Pages;
using GatorCMS.Core.Services.GatorPagesService;
using GraphQL.Types;

namespace GatorCMS.Core.Models
{
    public class QueryType : ObjectGraphType
    {
        public QueryType(IGatorPagesService gatorPagesService)
        {
            Name = "Query";

            // var t = new ObjectGraphType();
            // t.Field<>;
            
            Field<ListGraphType<PageType<GatorPage>>>(
                name: "pages",
                resolve: context => gatorPagesService.GetAllPages<GatorPage>()
            );
        }
    }
}
