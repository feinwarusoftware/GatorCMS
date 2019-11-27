using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatorCMS.Core.Services.LemonService;
using GraphQL.Types;

namespace GatorCMS.Core.Models
{
    public class AppQuery : ObjectGraphType
    {
        //private readonly ILemonService _lemonService;

        public AppQuery(ILemonService lemonService)
        {
            //_lemonService = lemonService;

            Name = "Query";

            Field<ListGraphType<LemonType>>(
                name: "lemons",
                resolve: context => lemonService.Get()
            );
        }
    }
}
