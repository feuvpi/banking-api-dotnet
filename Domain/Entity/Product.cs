
namespace Domain.Entity
{
    internal class Product : BaseEntity
    {
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
 
        public decimal Valor { get; set; }

        public string? Logo { get; set; }
        public string? Chamada { get; set; }
    }
}
