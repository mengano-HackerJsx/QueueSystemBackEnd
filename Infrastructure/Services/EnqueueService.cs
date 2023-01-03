using Application.Interfaces;
using Application.Person.DTO;
using Application.QueueLine.DTO;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Services
{
    public interface IEnqueueService
    {
        Task<Queue<PersonQueueDto>> EnqueueAttendingPersons(List<PersonQueueDto> persons);
        Task<PersonQueueDto> DequeuePerson(QueueLinePerson queueLinePerson);
    }

    public class EnqueueService : IEnqueueService
    {
        private readonly IQueuePersonService queuePersonService;
        private readonly IMapper mapper;

        public EnqueueService(IQueuePersonService queuePersonService, IMapper mapper)
        {
            this.queuePersonService = queuePersonService;
            this.mapper = mapper;
        }

        //Encolar personas que se estan atendiendo en la cola
        public async Task<Queue<PersonQueueDto>> EnqueueAttendingPersons(List<PersonQueueDto> persons)
        {
            var personAttending = new List<PersonQueueDto>();

            foreach (var person in persons)
            {
                var queuePerson = await queuePersonService.GetPersonById(person.Id);

                if (queuePerson.Status == Domain.Enums.Status.Attended) continue;

                personAttending.Add(person);
            }

            var personOrdered = (from person in personAttending
                                 orderby person.Condition
                                 select person).ToList();

            var personEnqueued = new Queue<PersonQueueDto>();

            foreach (var person in personOrdered)
                personEnqueued.Enqueue(person);

            return personEnqueued;
        }

        //Sacar una persona de la cola y cambiar su status
        public async Task<PersonQueueDto> DequeuePerson(QueueLinePerson queueLinePerson)
        {
            var personsEnqueued = await EnqueueAttendingPersons(queueLinePerson.Persons);

            var personDequeued = personsEnqueued.Dequeue();

            var queuePerson = await queuePersonService
                .GetQueuePersonById(personDequeued.Id, queueLinePerson.Id);

            queuePerson.Status = Domain.Enums.Status.Attended;

            queuePerson = await queuePersonService.Update(queuePerson.Id, queuePerson);

            return personsEnqueued.Peek();
        }
    }
}
