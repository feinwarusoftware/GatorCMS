using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatorCMS.Core.Models
{
    public class LemonType : ObjectGraphType<Lemon>
    {
        public LemonType()
        {
            Name = "Lemon";

            Field(x => x.Name);
        }
    }
}
