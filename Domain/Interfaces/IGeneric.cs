
namespace Domain.Interfaces
{
    /// <summary>
    /// Interface for performing CRUD operations on generic entities.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public interface IGeneric<T> where T : class
    {
        /// <summary>
        /// Adds an entity to the data store.
        /// </summary>
        /// <param name="Entity">The entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Add(T Entity);

        /// <summary>
        /// Updates an entity in the data store.
        /// </summary>
        /// <param name="Entity">The entity to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Update(T Entity);

        /// <summary>
        /// Deletes an entity from the data store.
        /// </summary>
        /// <param name="Entity">The entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Delete(Guid Id);

        /// <summary>
        /// Gets an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>A task representing the asynchronous operation. The result is the entity with the specified identifier.</returns>
        Task<T> GetById(Guid id);

        /// <summary>
        /// Gets a list of all entities in the data store.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The result is a list of all entities.</returns>
        Task<List<T>> GetAll();
    }
}
