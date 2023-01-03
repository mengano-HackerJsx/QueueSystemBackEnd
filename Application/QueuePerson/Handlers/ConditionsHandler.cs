using Application.Interfaces;
using Application.QueuePerson.DTO;
using Domain.Entities;

namespace Application.QueuePerson.Handlers
{
    public interface IConditionsHandler
    {
        Task<QueuePersonPostDto> ConditionAssignament(QueuePersonPostDto queuePersonPostDto);
        Task<bool> IsAdvancedAge(int personId);
        Task<bool> IsOverWeight(int personId);
        int SetCondition(List<int> personConditions);
        void AddConditions(QueuePersonPostDto queuePersonPostDto);
    }

    public class ConditionsHandler : IConditionsHandler
    {
        private readonly IPersonService personService;
        private readonly IPersonConditionService personConditionService;

        public ConditionsHandler(IPersonService personService, 
                                 IPersonConditionService personConditionService)
        {
            this.personService = personService;
            this.personConditionService = personConditionService;
        }

        public async Task<QueuePersonPostDto> ConditionAssignament(QueuePersonPostDto queuePersonPostDto)
        {

            if (await IsAdvancedAge(queuePersonPostDto.PersonId))
                queuePersonPostDto.ConditionsIds.Add(3);

            if (await IsOverWeight(queuePersonPostDto.PersonId))
                queuePersonPostDto.ConditionsIds.Add(4);

            if (queuePersonPostDto.ConditionsIds.Contains(0) 
                && queuePersonPostDto.ConditionsIds.Count == 1)
            {
                queuePersonPostDto.ConditionsIds.Remove(0);
                queuePersonPostDto.ConditionsIds.Add(5);
            }

            AddConditions(queuePersonPostDto);

            return queuePersonPostDto;
        }

        public async Task<bool> IsAdvancedAge(int personId)
        {
            var person = await personService.GetById(personId);

            if (person.Age >= 65) return true;

            return false;
        }

        public async Task<bool> IsOverWeight(int personId)
        {
            var person = await personService.GetById(personId);

            var personWeight = (double)person.Weight;
            var personHeight = (double)person.Height;

            var imc = personWeight / Math.Pow(personHeight, 2);

            if (imc >= 30) return true;

            return false;
        }

        public int SetCondition(List<int> personConditions)
        {
            personConditions.Sort();

            return personConditions[0];
        }

        public void AddConditions(QueuePersonPostDto queuePersonPostDto)
        {
            foreach (var conditionId in queuePersonPostDto.ConditionsIds.ToList())
            {
                personConditionService.Create(new PersonCondition()
                {
                    PersonId = queuePersonPostDto.PersonId,
                    ConditionId = conditionId
                });
            }
        }
    }
}
