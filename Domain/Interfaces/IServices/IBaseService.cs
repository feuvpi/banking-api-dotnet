namespace Domain.Interfaces.IServices
{
    public interface IBaseService<T> : IGeneric<T> where T : class
    {
    }
}
