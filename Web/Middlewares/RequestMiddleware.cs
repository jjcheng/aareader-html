using Serilog;
using System.Net;

namespace AAReader.Web.Middlewares;

public class RequestMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public RequestMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _requestDelegate(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        //ExceptionResponse exceptionResponse = new ExceptionResponse(ex);
        //if (!exceptionResponse.ShouldNotHandle)
        //{
        //    Log.Fatal(ex, "AAReader.Web exception {exception}", ex);
        //}
        
        //if (exceptionResponse.StatusCode == (int)HttpStatusCode.Unauthorized)
        //{
        //    context.Response.Redirect("/error/unauthorized");
        //}
        //else
        //{
        //    context.Response.Redirect("/error?code=" + exceptionResponse.StatusCode);
        //}
        context.Response.Redirect("/error?code=500");
        await Task.CompletedTask;
    }
}
