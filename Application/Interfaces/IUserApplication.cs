using Application.View;
using Application.View.CreateView;
using Application.View.UpdateView;
using Domain.Entity;

namespace Application.Interfaces
{
    public interface IUserApplication : IGenericApplication<User, UserView, UserCreateView, UserUpdateView>
    {
    }
}
