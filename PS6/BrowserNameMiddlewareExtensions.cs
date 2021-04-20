using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS6
{
    public static class BrowserNameMiddlewareExtensions
    {
        public static IApplicationBuilder UseBrowserNameMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BrowserNameMiddleware>();
        }
    }
}
