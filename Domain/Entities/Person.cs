using Domain.Entities.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        public string DNI { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        //---
        public List<PersonCondition> PersonCondition { get; set; }
        public List<QueuePerson> QueuePerson { get; set; }
    }
}
