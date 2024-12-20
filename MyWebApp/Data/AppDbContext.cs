using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;

namespace MyWebApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
