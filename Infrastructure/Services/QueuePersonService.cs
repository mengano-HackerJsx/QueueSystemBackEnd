using Application.Interfaces;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class QueuePersonService : BaseCrudService<Domain.Entities.QueuePerson>,
        IQueuePersonService
    {
        public QueuePersonService(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Domain.Entities.QueuePerson> GetPersonById(int id)
        {
            return await Query().FirstOrDefaultAsync(x => x.PersonId == id);
        }

        public async Task<Domain.Entities.QueuePerson> GetQueueById(int id)
        {
            return await Query().FirstOrDefaultAsync(x => x.QueueLineId == id);
        }

        public async Task<Domain.Entities.QueuePerson> GetQueuePersonById
            (int personId, int queueLineId)
        {
            return await Query()
                .FirstOrDefaultAsync(x => x.PersonId == personId && x.QueueLineId == queueLineId);
        }

        public async Task<Domain.Entities.QueuePerson> Update (Domain.Entities.QueuePerson queuePerson)
        {
            var entityExists = await dbSet
                .AnyAsync(x => x.PersonId == queuePerson.PersonId 
                && x.QueueLineId == queuePerson.QueueLineId);

            if (!entityExists) throw new Exception("Doesn't match");

            dbSet.Update(queuePerson);
            await dbContext.SaveChangesAsync();
            return queuePerson;
        }
    }
}
