namespace Domain.Interfaces.IServices
{
    internal interface IBaseService<T> : IGeneric<T> where T : class
    {
    }
}
