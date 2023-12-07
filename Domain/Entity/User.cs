
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Entity
{
    public class User : BaseEntity
    {
        [Column("Name")]
        public Name Name { get; private set;}
        [Column("Email")]
        public string Email { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("ContactNumber")]
        public string ContactNumber { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
    }

    public sealed record Name
    {
        public Name(string? value)
        {
            ArgumentException.ThrowIfNullOrEmpty(value, nameof(value));

            Value = value;
        }

        public string Value { get; }
    }
}
