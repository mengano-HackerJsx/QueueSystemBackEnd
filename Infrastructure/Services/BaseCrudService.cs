using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class BaseCrudService<TEntity> : IBaseCrudService<TEntity>
           where TEntity : BaseEntity
    {
        protected readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        protected readonly DbSet<TEntity> dbSet;

        public BaseCrudService(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.dbSet = dbContext.GetDbSet<TEntity>();
        }

        public IQueryable<TEntity> Query()
        {
            return dbSet.AsQueryable();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await Query().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Query().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(int id, TEntity entity)
        {
            var entityExists = await dbSet.AnyAsync(x => x.Id == id);

            if (!entityExists) throw new Exception("Doesn't match");

            entity.Id = id;

            dbSet.Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null) throw new Exception("Error deleting entity");

            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
