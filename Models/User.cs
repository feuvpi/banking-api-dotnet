using System.ComponentModel.DataAnnotations;

namespace banking_dotnet_api.Models
{
    public class User
    {

        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(50)]
        private String firstName { get; set; }

        [Required, MaxLength(50)]
        private string lastName { get; set; }

        //[Index(IsUnique = true)]\
        [Required]
        private string document { get; set; }

        [Required, MaxLength(200)]
        private string password { get; set; }

        private decimal balance { get; set; }

    }
}
