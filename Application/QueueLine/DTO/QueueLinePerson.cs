using Application.Person.DTO;

namespace Application.QueueLine.DTO
{
    public class QueueLinePerson : QueueLineDto
    {
        public List<PersonQueueDto> Persons { get; set; }
    }
}
