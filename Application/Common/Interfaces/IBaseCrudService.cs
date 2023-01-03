using Domain.Entities.Common;

namespace Application.Common.Interfaces
{
    public interface IBaseCrudService<TEntity> //where TEntity : BaseEntity
    {
        IQueryable<TEntity> Query();
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(int id, TEntity entity);
        Task<bool> Delete(int id);
    }
}
