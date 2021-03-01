using BlogMeImFamous.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMeImFamous.Helpers
{
    public class SessionMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            AttachUserToContext(context, userService);
            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, IUserService service)
        {
            if(context.Session.GetInt32("Id").HasValue)
            {
                context.Items["User"] = service.GetById(context.Session.GetInt32("Id").Value);
            }
        }
    }
}
