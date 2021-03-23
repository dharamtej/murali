using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace practice.MiddleWare
{

    public class CustomizeMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomizeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("My Custom MiddleWare\n");
        }
    }
}
