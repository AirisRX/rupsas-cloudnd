using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } // Ensure this is a DbSet, not a List
    public DbSet<Item> Items { get; set; } // Change to your actual type
}
