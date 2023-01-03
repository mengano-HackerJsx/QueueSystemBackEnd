using Application.Person.DTO;
using Application.QueueLine.DTO;
using AutoMapper;
using Domain.Enums;

namespace Application.QueueLine.Mapping
{
    public class QueueLineMapping : Profile
    {
        public QueueLineMapping()
        {
            CreateMap<QueueLinePostDto, Domain.Entities.QueueLine>();

            CreateMap<Domain.Entities.QueueLine, QueueLineDto>();

            CreateMap<Domain.Entities.QueueLine, QueueLinePerson>()
                .ForMember(queueLineDto => queueLineDto.Persons, op => op.MapFrom(MapPersons));
        }

        private List<PersonQueueDto> MapPersons(Domain.Entities.QueueLine queueLine,
                                                QueueLineDto queueLineDto)
        {
            var result = new List<PersonQueueDto>();

            if (queueLine.QueuePerson == null) return result;

            foreach (var queuePerson in queueLine.QueuePerson)
            {
                var status = (Status)queuePerson.Status;
                var condition = (Conditions)queuePerson.ConditionId;

                result.Add(new PersonQueueDto()
                {
                    Id = queuePerson.Person.Id,
                    DNI = queuePerson.Person.DNI,
                    Name = queuePerson.Person.Name,
                    Lastname = queuePerson.Person.Lastname,
                    Age = queuePerson.Person.Age,
                    Condition = condition.ToString(),
                    Status = status.ToString()
                });
            }

            return result;
        }
    }
}
