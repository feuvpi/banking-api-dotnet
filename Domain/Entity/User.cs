
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class User : BaseEntity
    {
        [Column("Name")]
        public String Name { get; private set;}
        [Column("Email")]
        public string Email { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("ContactNumber")]
        public string ContactNumber { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
    }

    //[ComplexType]
    //[Keyless]
    //public record Name
    //{
    //    public string Value { get; private set; }
    //}

    //public class Name
    //{
    //    public Name(string? value)
    //    {
    //        ArgumentException.ThrowIfNullOrEmpty(value, nameof(value));

    //        Value = value;
    //    }

    //    public string Value { get; }
    //}
}
