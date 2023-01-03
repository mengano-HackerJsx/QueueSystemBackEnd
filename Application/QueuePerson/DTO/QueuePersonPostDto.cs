namespace Application.QueuePerson.DTO
{
    public class QueuePersonPostDto : QueuePersonDto
    {
        /*public int PersonId { get; set; }
        public int QueueLineId { get; set; }*/
        public List<int> ConditionsIds { get; set; }
    }
}
