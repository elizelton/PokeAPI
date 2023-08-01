using Base.Exceptions;
using Newtonsoft.Json;

namespace API.Midlewares;

public class ResponseHandlerMiddleware
{
    private readonly RequestDelegate _next;
    public ResponseHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(AppException ex)
        {
            await HandleAppExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;

        var response = new
        {
            Error = "An unexpected error occurred.",
            Message = exception.Message
        };

        var jsonResponse = JsonConvert.SerializeObject(response);

        await context.Response.WriteAsync(jsonResponse);
    }
    
    private async Task HandleAppExceptionAsync(HttpContext context, AppException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 400;

        var response = new
        {
            Error = "Invalid request.",
            Message = exception.Message
        };

        var jsonResponse = JsonConvert.SerializeObject(response);

        await context.Response.WriteAsync(jsonResponse);
    }
}