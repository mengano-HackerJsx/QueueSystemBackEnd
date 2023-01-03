using Application.Common.DTO;

namespace Application.Person.DTO
{
    public class PersonQueueDto : BaseEntityDto
    {
        public string DNI { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Condition { get; set; }
        public string Status { get; set; }
    }
}
