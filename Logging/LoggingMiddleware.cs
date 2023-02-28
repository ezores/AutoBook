using System.Net.Mime;

namespace UstamOgretiyorBize.Logging;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        Console.WriteLine("Cycle anoni kitap - Logging Middleware");
        await _next(httpContext);
    }
}