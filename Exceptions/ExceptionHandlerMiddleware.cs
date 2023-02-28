using System.Net.Mime;

namespace UstamOgretiyorBize.Exceptions;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        httpContext.Response.ContentType = MediaTypeNames.Application.Json;

        try
        {
            Console.WriteLine("Fokin exception middleware here");
            await _next(httpContext);
        }
        catch (HttpException e)
        {
            httpContext.Response.StatusCode = e.StatusCode;
            await httpContext.Response.WriteAsync(new ErrorDetail { Message = e.Message, StatusCode = e.StatusCode }
                .ToString());
        }
    }
}