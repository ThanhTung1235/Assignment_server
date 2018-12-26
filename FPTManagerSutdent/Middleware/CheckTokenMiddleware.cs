using FPTManagerSutdent.Data;
using FPTManagerSutdent.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPTManagerSutdent.Middleware
{
    public static class CheckTokenMiddlewareExtensions
    {
        public static IApplicationBuilder UseCheckToken(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckTokenMiddleware>();
        }
    }

    public class CheckTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, Datacontext databaseContext)
        {
            bool isValid = false;
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var basicToken = context.Request.Headers["Authorization"].ToString();
                basicToken = basicToken.Replace("Basic ", "");
                MyCredential credential = databaseContext.MyCredentials.SingleOrDefault(c => c.AccessToken == basicToken);
                if (credential != null && credential.isValid())
                {
                    isValid = true;
                }
            }
            if (isValid)
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Forbidden");
            }
        }
    }
}
