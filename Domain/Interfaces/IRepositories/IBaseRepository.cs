
using Domain.Entity;

namespace Domain.Interfaces.IRepositories
{
    internal interface IBaseRepository<T> : IGeneric<T> where T : BaseEntity
    {
    }
}
