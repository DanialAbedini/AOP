using System.Globalization;

namespace AOP.Middleware;

public class CustomeMiddleware
{
    private readonly RequestDelegate _next;

    public CustomeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("This is Middleware");
        await _next(context);
    }
}

public static class CustomeMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestCulture(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomeMiddleware>();
    }
}