using Application.Interfaces;
using Application.QueuePerson.DTO;
using Domain.Enums;

namespace Application.QueuePerson.Validations.Custom
{
    public interface IQueuePersonValidationMethods
    {
        Task<bool> PersonExists(int id);
        Task<bool> QueueExists(int id);
        Task<bool> PersonAttending(int personId, int queueLineId);
        Task<bool> PregnantPersonIsFemale(QueuePersonPostDto queuePersonPostDto);
        bool ConditionOutOfRange(List<int> personConditions);
    }

    public class QueuePersonValidationMethods : IQueuePersonValidationMethods
    {
        private readonly IPersonService personService;
        private readonly IQueueLineService queueLineService;
        private readonly IQueuePersonService queuePersonService;

        public QueuePersonValidationMethods(IPersonService personService,
                                            IQueueLineService queueLineService,
                                            IQueuePersonService queuePersonService)
        {
            this.personService = personService;
            this.queueLineService = queueLineService;
            this.queuePersonService = queuePersonService;
        }

        public async Task<bool> PersonExists(int id)
        {
            var person = await personService.GetById(id);

            if (person == null) return false;

            return true;
        }

        public async Task<bool> QueueExists(int id)
        {
            var queue = await queueLineService.GetById(id);

            if (queue == null) return false;

            return true;
        }

        public async Task<bool> PersonAttending(int personId, int queueId)
        {
            var queuePerson = await queuePersonService.GetQueuePersonById(personId, queueId);

            if (queuePerson == null || queuePerson.Status == Status.Attending) return false;

            return true;
        }

        public async Task<bool> PregnantPersonIsFemale(QueuePersonPostDto queuePersonPostDto)
        {
            var pregnantCondition = queuePersonPostDto.ConditionsIds.Contains(1);

            if (!pregnantCondition) return true;

            var person = await personService.GetById(queuePersonPostDto.PersonId);

            if (person.Sex != Sex.Female) return false;

            return true;
        }

        public bool ConditionOutOfRange(List<int> personConditions)
        {
            foreach (var condition in personConditions)
            {
                if (condition > 2) return true;
            }

            return false;
        }

    }
}
