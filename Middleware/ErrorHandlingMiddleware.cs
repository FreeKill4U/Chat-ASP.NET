using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzkolaKomunikator.Helpers.Exceptions;

namespace SzkolaKomunikator.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException e)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Not Found: " + e.Message);
            }
            catch (IncorrectDataException e)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Incorrect Data: " + e.Message);
            }
            catch (UnauthorizeException e)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("No permission: " + e.Message);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong: " + e.Message);
            }
        }
    }
}
