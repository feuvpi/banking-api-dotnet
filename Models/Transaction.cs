using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace banking_dotnet_api.Models
{
    public class Transaction
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        
        public Guid SenderId { get; set; } // Foreign key for Sender
        [Required]
        [ForeignKey("SenderId")] // Specify the foreign key name
        public User Sender { get; set; }

        
        public Guid ReceiverId { get; set; } // Foreign key for Receiver

        [Required]
        [ForeignKey("ReceiverId")] // Specify the foreign key name
        public User Receiver { get; set; }

        public DateTime Timestamp { get; set; }

    }
}
