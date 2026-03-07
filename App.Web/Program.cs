using App.Application;
using App.Infrastructure;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        policy =>
        {
            // Be exact: no trailing slash
            policy.WithOrigins("http://127.0.0.1:5271",
                                "https://127.0.0.1:7247",
                                "http://localhost:5271",
                                "https://apptest.runasp.net",
                                "http://apptest.runasp.net")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.
 

builder.Services.AddControllers();

builder.Services.AddApplication()
    .AddInfrastructure(builder.Configuration);


await using var app = builder.Build();



 //app.UseHttpsRedirection(); /* USE THIS IF YOU ALREADY HAVE SSL */

var browserPath = Path.Combine(builder.Environment.WebRootPath, "browser");

app.UseDefaultFiles(new DefaultFilesOptions
{
    FileProvider = new PhysicalFileProvider(browserPath),
    RequestPath = ""
});

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(browserPath),
    RequestPath = ""
});

app.UseRouting();

app.UseCors("AllowAngularDev");

// app.UseAuthentication(); /* TEMPORARILY COMMENTED FOR DEVELOPMENT PURPOSE */
app.UseAuthorization();


app.MapControllers();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
}

// In Production (MonsterASP), if no API or File is found, send index.html

app.MapFallback(async context =>
{
    var path = context.Request.Path.Value?.Trim('/') ?? "";

    // Check for the subfolder file (e.g. wwwroot/browser/about/index.html)
    var subfolderIndex = Path.Combine(browserPath, path, "index.html");

    if (!string.IsNullOrEmpty(path) && File.Exists(subfolderIndex))
    {
        await context.Response.SendFileAsync(subfolderIndex);
    }
    else
    {
        // Fallback to the main index inside /browser/
        await context.Response.SendFileAsync(Path.Combine(browserPath, "index.html"));
    }
});
//else
//{
//    app.UseSpa(spa =>
//    {
//        spa.Options.SourcePath = "../App.Client";
//        spa.Options.StartupTimeout = TimeSpan.FromMinutes(5);
//        spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
//    });
//}



await app.RunAsync();

/**
 *  latest chat https://share.google/aimode/xI3pNQEJxIK1Nf6ZV
 * 
 */
