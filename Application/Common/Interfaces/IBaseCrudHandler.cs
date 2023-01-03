namespace Application.Common.Interfaces
{
    public interface IBaseCrudHandler<TEntity, TDto>
    {
        Task<IQueryable<TEntity>> Query();
        Task<List<TDto>> GetAll();
        Task<TDto> GetById(int id);
        Task<TDto> Create(TDto dto);
        Task<TDto> Update(int id, TDto dto);
        Task<bool> Delete(int id);
    }
}
