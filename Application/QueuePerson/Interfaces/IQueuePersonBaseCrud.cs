using Application.Common.Interfaces;

namespace Application.QueuePerson.Interfaces
{
    public interface IQueuePersonBaseCrud : IBaseCrudService<Domain.Entities.QueuePerson>
    {
        Task<Domain.Entities.QueuePerson> GetPersonById(int id);
        Task<Domain.Entities.QueuePerson> GetQueueById(int id);
        Task<Domain.Entities.QueuePerson> GetQueuePersonById(int personId, int queueLineId);
        Task<Domain.Entities.QueuePerson> Update(Domain.Entities.QueuePerson queuePerson);
    }
}
