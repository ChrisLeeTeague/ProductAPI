using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Models
{
    [Table("Products")]
    public class Product
    {
        public required string Id { get; set; }

        public required string Description { get; set; }

        public required float Price { get; set; }

        public int Quantity { get; set; }
    }
}
