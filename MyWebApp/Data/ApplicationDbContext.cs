using Microsoft.EntityFrameworkCore;
using MyWebApp.Models; // Adjust this based on your namespace
namespace MyWebApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; } // Ensure this line exists
    public DbSet<Item> Items { get; set; }
}   

