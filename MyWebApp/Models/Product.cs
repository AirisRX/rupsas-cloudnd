using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        public required string Name { get; set; }
        
        public decimal Price { get; set; }
    }
}