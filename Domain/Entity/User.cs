
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class User : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set;}
        [Column("Email")]
        public string Email { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("ContactNumber")]
        public string ContactNumber { get; set; }
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }
    }
}
