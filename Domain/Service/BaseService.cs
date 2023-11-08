using Domain.Entity;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;

namespace Domain.Service
{
    /// <summary>
    /// A base service class for domain entities that provides common operations and functionalities.
    /// </summary>
    /// <typeparam name="T">The entity type for which the service is designed.</typeparam>
    internal class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        // Additional service methods can be defined here.
        // These methods typically build upon the common operations provided by IBaseRepository.
        // For example, you can define methods for business-specific logic or additional functionality.
        protected readonly IBaseRepository<T> _repository;

        /// <summary>
        /// Initializes a new instance of the BaseService class with the specified repository.
        /// </summary>
        /// <param name="repository">The repository to be used for data access operations.</param>
        protected BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Adds a new entity to the data store.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Add(T entity)
        {
            await _repository.Add(entity);
        }

        /// <summary>
        /// Updates an existing entity in the data store.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Update(T entity)
        {
            await _repository.Update(entity);
        }

        /// <summary>
        /// Deletes an entity from the data store.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Delete(T entity)
        {
            await _repository.Delete(entity);
        }

        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="Id">The unique identifier of the entity.</param>
        /// <returns>A task representing the asynchronous operation. The result is the entity with the specified identifier.</returns>
        public async Task<T> GetById(Guid Id)
        {
            return await _repository.GetById(Id);
        }

        /// <summary>
        /// Retrieves a list of all entities in the data store.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The result is a list of all entities.</returns>
        public async Task<List<T>> GetAll()
        {
            return await _repository.GetAll();
        }


    }
}
