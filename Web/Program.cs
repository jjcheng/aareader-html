using AAReader.Web.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.WebHost.UseUrls("http://*:9000");

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseMiddleware<RequestMiddleware>();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    //app.UseHttpsRedirection();
}
else
{
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseResponseCaching();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

try
{
    Log.Information("AAReader.Web starting...");
    app.Run();
    Log.Information("AAReader.Web shutting down...");
}
catch (Exception ex)
{
    Log.Fatal(ex, "AAReader.Web host terminated unexpectedly: {excepption}", ex);
}
finally
{
    Log.CloseAndFlush();
}
