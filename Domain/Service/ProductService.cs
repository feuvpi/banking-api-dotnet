using Domain.Entity;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;


namespace Domain.Service
{
    /// <summary>
    /// Service class for managing products, derived from the BaseService class.
    /// </summary>
    internal class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _repository;
        /// <summary>
        /// Initializes a new instance of the ProductService class with the specified product repository.
        /// </summary>
        /// <param name="repository">The repository for product data access.</param>
        public ProductService(IProductRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
