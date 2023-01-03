using Application.Interfaces;
using AutoMapper;
using Infrastructure.Context;

namespace Infrastructure.Services
{
    public class PersonConditionService : BaseCrudService<Domain.Entities.PersonCondition>,
        IPersonConditionService
    {
        public PersonConditionService(IApplicationDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
