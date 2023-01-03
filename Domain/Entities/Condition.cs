using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Condition : BaseEntity
    {
        public string ConditionType { get; set; }
        public List<PersonCondition> PersonCondition { get; set; }
        public List<QueuePerson> QueuePerson { get; set; }
    }
}
