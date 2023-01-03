using Application.Interfaces;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class QueueLineService : BaseCrudService<Domain.Entities.QueueLine>, IQueueLineService
    {
        public QueueLineService(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Domain.Entities.QueueLine> GetByIdData(int id)
        {
            return await Query().Include(x => x.QueuePerson)
                .ThenInclude(x => x.Person).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
