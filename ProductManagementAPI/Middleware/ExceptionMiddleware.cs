using ProductManagementAPI.Logging;

namespace ProductManagementAPI.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, LogHelper logHelper)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await logHelper.Log(e.Message, "Error");
            await HandleException(context, e);
        }
    }

    private static Task HandleException(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;

        var response = new
        {
            message = "Something Went Wrong",
            detail = ex.Message
        };

        return context.Response.WriteAsJsonAsync(response);
    }
}