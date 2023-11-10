
namespace Domain.Entity
{
    public class Product : BaseEntity
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
