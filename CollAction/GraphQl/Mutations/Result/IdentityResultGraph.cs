﻿using GraphQL.Types;
using Microsoft.AspNetCore.Identity;

namespace CollAction.GraphQl.Mutations
{
    public sealed class IdentityResultGraph : ObjectGraphType<IdentityResult>
    {
        public IdentityResultGraph()
        {
            Field(x => x.Succeeded);
            Field(x => x.Errors);
        }
    }
}
