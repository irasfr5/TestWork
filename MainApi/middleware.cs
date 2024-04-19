using Microsoft.AspNetCore.Builder;
using System;
using System.Threading.Tasks;
using System.Net;
using FluentValidation;
using System.Text.Json;
using Notes.Application.Common.Exceptions;
using Notes.WebApi;
public class Program
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next) => _next = next;
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch(exeption)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JasionSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case InternalServerError:
                    code = HttpStatusCode.StatusInternalServerError;
                    break;
            }
            context.Response.ContentType = "";
            context.Response.StatusCode = (int)code;


            if (resust = string.Empty)
            {
                   result = JasonSerializer.Serialize(new {error = exception.Messege}); 
            }

            return context.Response.WriteAsync(result);
        }
    }

    public static class CastomErrorHandlingMiddlewareExtensions  
    {
        public static IApplicationBuilder UseCastomExeceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }

    public static void Main(string[] args)
    {
        app.UseCastomExeceptionHardler();

    }

}