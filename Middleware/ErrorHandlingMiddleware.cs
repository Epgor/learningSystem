using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using learningSystem.Exceptions;

namespace learningSystem.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {


        public ErrorHandlingMiddleware()
        {
            
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (ForbidException forbidException)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync(forbidException.Message);
            }
            catch (BadRequestException badRequestException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            
            catch (UnauthorizedAccessException)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Authorization Failed");
            }        

            catch (FormatException)
            {
                context.Response.StatusCode = 601;
                await context.Response.WriteAsync("Incorrect format exception");
            }
            catch (Exception e)
            {

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
