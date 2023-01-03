using Application.Person.DTO;
using AutoMapper;
using Domain.Enums;

namespace Application.Person.Mapping
{
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<PersonPostDto, Domain.Entities.Person>();

            CreateMap<Domain.Entities.Person, PersonDto>()
                .ForMember(personDto => personDto.Sex, op => op.MapFrom(MapPersonSex));
        }
         private string MapPersonSex(Domain.Entities.Person person, PersonDto personDto)
        {
            Sex personSex = (Sex)person.Sex;
            return personSex.ToString();
        }
    }
}
