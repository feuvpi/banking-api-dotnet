using banking_dotnet_api.DTO;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

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

        private string passwordSalt; // -- Store the salt

        public decimal Balance { get; set; }
        private static RandomNumberGenerator rng = RandomNumberGenerator.Create();

        // -- Navigation property for transactions where this user is the sender
        public ICollection<Transaction>? SentTransactions { get; set; }

        // -- Navigation property for transactions where this user is the receiver
        public ICollection<Transaction>? ReceivedTransactions { get; set; }

        public void SetPassword(string password)
        {
            using(var sha256 = SHA256.Create())
            {
                byte[] saltBytes = new byte[16]; // -- generate a random salt
                using(var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(saltBytes);
                }

                this.passwordSalt = Convert.ToBase64String(saltBytes);

                byte[] passwordBytes = Encoding.UTF8.GetBytes(password + this.passwordSalt);
                byte[] hashedByutes = sha256.ComputeHash(passwordBytes);
                this.Password = Convert.ToBase64String(hashedByutes);

            }
        }

        public bool VerifyPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password + this.passwordSalt);
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
                string hashedPassword = Convert.ToBase64String(hashedBytes);
                return hashedPassword.Equals(this.Password);
            }
        }

    }
}
