using Domain.Entities.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class QueuePerson : BaseEntity
    {
        public int PersonId { get; set; }
        public int QueueLineId { get; set; }
        public int ConditionId { get; set; }
        public Status Status { get; set; }
        public DateTime EnqueueDate { get; set; } = DateTime.Now;
        //---
        public Person Person { get; set; }
        public QueueLine QueueLine { get; set; }
        public Condition Condition { get; set; }
    }
}
