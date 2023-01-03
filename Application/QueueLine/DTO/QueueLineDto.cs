using Application.Common.DTO;

namespace Application.QueueLine.DTO
{
    public class QueueLineDto : BaseEntityDto
    {
        public string QueueName { get; set; }
        public string Description { get; set; }
    }
}
