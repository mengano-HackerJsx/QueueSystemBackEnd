using Application.Common.Interfaces;

namespace Application.Interfaces
{
    public interface IPersonService : IBaseCrudService<Domain.Entities.Person>
    {
    }
}
