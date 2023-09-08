using banking_dotnet_api.DTO;
using System.ComponentModel.DataAnnotations;

namespace banking_dotnet_api.Models
{
    public class User {  
    
        public User(UserDTO user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Document = user.Document;
            Password = user.Password;
            Balance = 0;
        }

        public User()
        {

        }

        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(50)]
        public String FirstName { get; set; }

        [Required, MaxLength(50)]
        public string? LastName { get; set; }

        //[Index(IsUnique = true)]\
        [Required]
        public string? Document { get; set; }

        [Required, MaxLength(200)]
        public string? Password { get; set; }

        public decimal Balance { get; set; }


        // -- Navigation property for transactions where this user is the sender
        public ICollection<Transaction>? SentTransactions { get; set; }

        // -- Navigation property for transactions where this user is the receiver
        public ICollection<Transaction>? ReceivedTransactions { get; set; }

    }
}
