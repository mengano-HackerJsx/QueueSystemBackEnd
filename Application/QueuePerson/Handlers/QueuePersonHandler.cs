using Application.Common.Handler;
using Application.Interfaces;
using Application.QueuePerson.DTO;
using AutoMapper;
using Domain.Enums;

namespace Application.QueuePerson.Handlers
{
    public interface IQueuePersonHandler
    {
        new Task<QueuePersonDto> Create(QueuePersonPostDto queuePersonPostDto);
    }

    public class QueuePersonHandler : BaseCrudHandler<Domain.Entities.QueuePerson, QueuePersonDto>,
        IQueuePersonHandler
    {
        private readonly IQueuePersonService queuePersonService;
        private readonly IMapper mapper;
        private readonly IConditionsHandler conditionsHandler;

        public QueuePersonHandler(IQueuePersonService queuePersonService, IMapper mapper, 
                                  IConditionsHandler conditionsHandler)
            : base(queuePersonService, mapper)
        {
            this.queuePersonService = queuePersonService;
            this.mapper = mapper;
            this.conditionsHandler = conditionsHandler;
        }

        public new async Task<QueuePersonDto> Create(QueuePersonPostDto queuePersonPostDto)
        {
            queuePersonPostDto = await conditionsHandler.ConditionAssignament(queuePersonPostDto);
            queuePersonPostDto.Status = 1;
            queuePersonPostDto.ConditionId = conditionsHandler.SetCondition(queuePersonPostDto.ConditionsIds);

            return await base.Create(queuePersonPostDto);
        }
    }
}
