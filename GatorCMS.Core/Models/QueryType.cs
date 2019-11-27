using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatorCMS.Core.Models
{
    public class QueryType : ObjectGraphType
    {
        public QueryType()
        {
            Name = "Query";

            Field<NonNullGraphType<StringGraphType>>(
                name: "message",
                resolve: context => "he was a gator boy, she said, i am horribly addicted to opioids"
            );
        }
    }
}
