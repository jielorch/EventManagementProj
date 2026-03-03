using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

await using var app = builder.Build();



app.UseHttpsRedirection();

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

// app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // In Production (MonsterASP), if no API or File is found, send index.html
    app.MapFallback(async context =>
    {
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
    });
}
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
