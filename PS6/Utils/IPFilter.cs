using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS6.Utils
{
    public class IPFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result;
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress;
            if (result is PageResult)
            {
                var page = ((PageResult)result);
                page.ViewData["filterMessage"] = ipAddress;
            }
            await next.Invoke();
        }
    }
}
