using System.ComponentModel.DataAnnotations;

namespace banking_dotnet_api.Models
{
    public class Transaction
    {

        [Key]
        private Guid id { get; set; }

        [Required]
        private decimal amount { get; set; }

        [Required]
        private User sender { get; set; }

        [Required]
        private User receiver { get; set; }

        private DateTime timestamp { get; set; }

    }
}
