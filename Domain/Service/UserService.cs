using Domain.Entity;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;


namespace Domain.Service
{
    /// <summary>
    /// Service class for managing users, derived from the BaseService class.
    /// </summary>
    internal class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _repository;
        /// <summary>
        /// Initializes a new instance of the UserService class with the specified product repository.
        /// </summary>
        /// <param name="repository">The repository for user data access.</param>
        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
