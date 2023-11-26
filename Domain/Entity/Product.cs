
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Product : BaseEntity
    {
        [Column("Title")]
        public required string Title { get; set; }
        [Column("Description")]
        public string? Description { get; set; }
        [Column("Price")]
        public decimal Price { get; set; }
    }
}
