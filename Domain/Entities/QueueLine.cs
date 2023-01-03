using Domain.Entities.Common;

namespace Domain.Entities
{
    public class QueueLine : BaseEntity
    {
        public string QueueName { get; set; }
        public string Description { get; set; }
        public List<QueuePerson> QueuePerson { get; set; }
    }
}
