using Microsoft.EntityFrameworkCore;
using MyWebApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles(); // Enable serving static files

app.MapControllers();
app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("index.html");
});

app.Run();
