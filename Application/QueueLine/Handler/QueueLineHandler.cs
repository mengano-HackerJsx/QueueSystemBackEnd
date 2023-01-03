using Application.Common.Handler;
using Application.Interfaces;
using Application.Person.DTO;
using Application.QueueLine.DTO;
using AutoMapper;

namespace Application.QueueLine.Handler
{
    public interface IQueueLineHandler
    {
        new Task<List<QueueLineDto>> GetAll();
        new Task<QueueLineDto> GetById(int id);
        Task<QueueLinePerson> GetByIdData(int id);
        new Task<QueueLineDto> Create(QueueLinePostDto queueLinePostDto);
        new Task<bool> Delete(int id);
    }

    public class QueueLineHandler : BaseCrudHandler<Domain.Entities.QueueLine, QueueLineDto>,
                 IQueueLineHandler
    {
        private readonly IQueueLineService queueLineService;
        private readonly IMapper mapper;

        public QueueLineHandler(IQueueLineService queueLineService, IMapper mapper) 
            : base(queueLineService, mapper)
        {
            this.queueLineService = queueLineService;
            this.mapper = mapper;
        }

        public new async Task<List<QueueLineDto>> GetAll()
        {
            return await base.GetAll();
        }

        public override async Task<QueueLineDto> GetById(int id)
        {
            return await base.GetById(id);
        }

        public async Task<QueueLinePerson> GetByIdData(int id)
        {
            var queue = await queueLineService.GetByIdData(id);
            return mapper.Map<QueueLinePerson>(queue);
        }

        public new async Task<QueueLineDto> Create(QueueLinePostDto queueLinePostDto)
        {
            return await base.Create(queueLinePostDto);
        }

        public new async Task<bool> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}
