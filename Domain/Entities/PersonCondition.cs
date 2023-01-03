using Domain.Entities.Common;

namespace Domain.Entities
{
    public class PersonCondition : BaseEntity
    {
        public int PersonId { get; set; }
        public int ConditionId { get; set; }
        public DateTime ConditionRecordedDate { get; set; } = DateTime.Now;
        //---
        public Person Person { get; set; }
        public Condition Condition { get; set; }
    }
}
