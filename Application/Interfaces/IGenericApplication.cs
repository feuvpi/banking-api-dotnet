using Application.View;
using Application.View.CreateView;
using Application.View.UpdateView;
using Domain.Entity;

namespace Application.Interfaces
{
    public interface IGenericApplication<Entity, View, CreateView, UpdateView> 
        where Entity : BaseEntity where View : BaseView where CreateView : BaseCreateView where UpdateView : BaseUpdateView
    {
        Task Add(CreateView view);
        Task Update(UpdateView view);
        Task Delete(Guid Id);
        Task<View> GetById(Guid Id);
        Task<List<View>> GetAll();

    }
}
