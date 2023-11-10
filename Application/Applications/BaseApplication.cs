using Application.Interfaces;
using Application.View;
using Application.View.CreateView;
using Application.View.UpdateView;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces.IServices;


namespace Application.Applications
{
    public abstract class BaseApplication<Entity, View, CreateView, UpdateView> : IGenericApplication<Entity, View, CreateView, UpdateView>
        where Entity : BaseEntity
        where View : BaseView
        where CreateView : BaseCreateView
        where UpdateView : BaseUpdateView
    {
        private readonly IBaseService<Entity> _service;
        private readonly IMapper _mapper;

        public BaseApplication(IBaseService<Entity> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task Add(CreateView view)
        {
            var source = _mapper.Map<Entity>(view);
            await _service.Add(source); 
        }

        public async virtual Task Delete(Guid Id)
        {
            await _service.Delete(Id);
        }

        public async Task<List<View>> GetAll()
        {
            var sourceList = await _service.GetAll();
            var resultList = _mapper.Map<List<View>>(sourceList);
            return resultList;
        }

        public async Task<View> GetById(Guid Id)
        {
            var source = await _service.GetById(Id);
            var result = _mapper.Map<View>(source);
            return result;
        }

        public async Task Update(UpdateView view)
        {
            var source = _mapper.Map<Entity>(view);
            await _service.Update(source);
        }
    }
}
