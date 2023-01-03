using Application.Interfaces;
using AutoMapper;
using Infrastructure.Context;

namespace Infrastructure.Services
{
    public class PersonService : BaseCrudService<Domain.Entities.Person>, IPersonService
    {
        public PersonService(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
