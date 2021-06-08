using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzkolaKomunikator.Helpers.Exceptions;
using WebApi.Services;

namespace SzkolaKomunikator.Middleware
{
    public class UserExistsMiddleware : IMiddleware
    {
        private readonly IUserService _userService;

        public UserExistsMiddleware(IUserService userService)
        {
            _userService = userService;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
               if(context.Request.Headers.ContainsKey("Authorization"))
                {
                    if(!_userService.AuthFirst(context.Request.Headers["Authorization"].ToString().Substring(7)))
                    {
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync("Auth");
                    }
                }
                await next.Invoke(context);
        }
    }
}
