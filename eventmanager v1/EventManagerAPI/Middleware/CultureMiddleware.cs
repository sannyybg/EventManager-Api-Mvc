using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagerAPI.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var cultureName = "en-US";
            var contextCulture = context.Request.Headers["Accept-Language"].ToString();

            if(!string.IsNullOrWhiteSpace(contextCulture))
            {

                cultureName = contextCulture.Split(',')[0];

            }

            var culture = new CultureInfo(cultureName);

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            await _next(context);

        }
    }
}
