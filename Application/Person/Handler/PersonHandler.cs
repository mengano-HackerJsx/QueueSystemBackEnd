using Application.Common.Handler;
using Application.Interfaces;
using Application.Person.DTO;
using AutoMapper;

namespace Application.Person.Handler
{
    public interface IPersonHandler
    {
        new Task<List<PersonDto>> GetAll();
        new Task<PersonDto> GetById(int id);
        new Task<PersonDto> Create(PersonPostDto personPostDto);
        new Task<PersonDto> Update(int id, PersonPostDto personPostDto);
        new Task<bool> Delete(int id);
    }

    public class PersonHandler : BaseCrudHandler<Domain.Entities.Person, PersonDto>, IPersonHandler
    {
        public PersonHandler(IPersonService personService, IMapper mapper) 
            : base(personService, mapper)
        {
        }

        public new async Task<List<PersonDto>> GetAll()
        {
            return await base.GetAll();
        }

        public new async Task<PersonDto> GetById(int id)
        {
            return await base.GetById(id);
        }

        public new async Task<PersonDto> Create(PersonPostDto personPostDto)
        {
            return await base.Create(personPostDto);
        }

        public new async Task<PersonDto> Update(int id, PersonPostDto personPostDto)
        {
            return await base.Update(id, personPostDto);
        }

        public new async Task<bool> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}
