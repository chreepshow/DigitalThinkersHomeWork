using DigitalThinkersHomeWork.Driver;
using DigitalThinkersHomeWork.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDriverDbContextConfig(builder.Configuration);
builder.Services.AddDriverConfig(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
