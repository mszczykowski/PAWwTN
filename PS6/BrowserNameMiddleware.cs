using Microsoft.AspNetCore.Http;
using Shyjus.BrowserDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS6
{
    public class BrowserNameMiddleware
    {
        private readonly RequestDelegate _next;

        public BrowserNameMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, IBrowserDetector browserDetector)
        {
            var browser = browserDetector.Browser;
            if (browser.Name == BrowserNames.Edge || browser.Name == BrowserNames.EdgeChromium || browser.Name == BrowserNames.InternetExplorer)
            {
                httpContext.Response.WriteAsync("<b>Przegladarka nie jest obslugiwana</b>");
            }
            return _next(httpContext);
        }
    }
}
