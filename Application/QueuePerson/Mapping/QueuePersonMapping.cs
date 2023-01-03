using Application.Person.DTO;
using Application.QueuePerson.DTO;
using AutoMapper;

namespace Application.QueuePerson.Mapping
{
    public class QueuePersonMapping : Profile
    {
        public QueuePersonMapping()
        {
            CreateMap<QueuePersonPostDto, Domain.Entities.QueuePerson>();

            CreateMap<Domain.Entities.QueuePerson, QueuePersonDto>();

            CreateMap<QueuePersonDto, Domain.Entities.QueuePerson>();

            CreateMap<PersonQueueDto, Domain.Entities.QueuePerson>();
        }
    }
}
