using Microsoft.EntityFrameworkCore; // For AddDbContext
using MyWebApp.Models; // Adjust this based on the namespace where ApplicationDbContext is defined
using Microsoft.OpenApi.Models; // Add this line at the top of the file
using Microsoft.AspNetCore.Mvc;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers();

// Update to use PostgreSQL instead of SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Set the Swagger UI at the app's root
    });
}

app.UseHttpsRedirection();
app.UseRouting(); // Move this line here
app.UseAuthorization(); // Place this after UseRouting

app.MapControllers();

app.Run();