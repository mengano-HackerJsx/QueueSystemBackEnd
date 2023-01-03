using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities.Common;

namespace Application.Common.Handler
{
    public class BaseCrudHandler<TEntity, TDto> : IBaseCrudHandler<TEntity, TDto>
           where TEntity : BaseEntity
    {
        private readonly IBaseCrudService<TEntity> baseCrudService;
        private readonly IMapper mapper;

        public BaseCrudHandler(IBaseCrudService<TEntity> baseCrudService, IMapper mapper)
        {
            this.baseCrudService = baseCrudService;
            this.mapper = mapper;
        }

        public virtual async Task<IQueryable<TEntity>> Query()
        {
            return await Task.FromResult(baseCrudService.Query());
        }

        public virtual async Task<List<TDto>> GetAll()
        {
            var entities = await Query();
            return mapper.Map<List<TDto>>(entities);
        }

        public virtual async Task<TDto> GetById(int id)
        {
            var entity = await baseCrudService.GetById(id);
            return mapper.Map<TDto>(entity);
        }

        public virtual async Task<TDto> Create(TDto dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            entity = await baseCrudService.Create(entity);
            return mapper.Map<TDto>(entity);
        }

        public virtual async Task<TDto> Update(int id, TDto dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            entity = await baseCrudService.Update(id, entity);
            return mapper.Map<TDto>(entity);
        }

        public virtual async Task<bool> Delete(int id)
        {
            return await baseCrudService.Delete(id);
        }
    }
}
