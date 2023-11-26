using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace Domain.Entity
{
    public class BaseEntity
    {
        [Column("Id")]
        public Guid Id { get; set; }
    }
}
