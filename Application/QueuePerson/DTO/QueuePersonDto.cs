namespace Application.QueuePerson.DTO
{
    public class QueuePersonDto
    {
        public int PersonId { get; set; }
        public int QueueLineId { get; set; }
        public int ConditionId { get; set; }
        public int Status { get; set; }
        public DateTime EnqueueDate { get; set; }
    }
}
