using Application.Common.Interfaces;

namespace Application.Interfaces
{
    public interface IQueueLineService : IBaseCrudService<Domain.Entities.QueueLine>
    {
        Task<Domain.Entities.QueueLine> GetByIdData(int id);
    }
}
