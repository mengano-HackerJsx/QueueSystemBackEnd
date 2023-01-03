using Application.Person.DTO;
using Application.Person.Handler;
using Application.QueueLine.DTO;
using Application.QueueLine.Handler;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace QueueSystem2._0Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueueLinesController : ControllerBase
    {
        private readonly IQueueLineHandler queueLineHandler;
        private readonly IEnqueueService enqueueService;

        public QueueLinesController(IQueueLineHandler queueLineHandler, IEnqueueService enqueueService)
        {
            this.queueLineHandler = queueLineHandler;
            this.enqueueService = enqueueService;
        }

        [HttpGet]
        public async Task<List<QueueLineDto>> GetAll()
        {
            return await queueLineHandler.GetAll();
        }

        [HttpGet("{id:int}", Name = "GetQueueLine")]
        public async Task<ActionResult<QueueLineDto>> GetById(int id)
        {
            var queueReturn = await queueLineHandler.GetById(id);

            if (queueReturn == null) return NotFound("El recurso buscado no existe.");

            return Ok(queueReturn);
        }

        [HttpGet("{id:int} GetPersonsInQueue")]
        public async Task<ActionResult<QueueLinePerson>> GetPersonsInQueue(int id)
        {
            var queue = await queueLineHandler.GetByIdData(id);

            if (queue == null) return NotFound();

            var personsQueue = await enqueueService.EnqueueAttendingPersons(queue.Persons);
            queue.Persons = personsQueue.ToList();
            return queue;
        }

        [HttpGet("{id:int} GetFirstPersonsInQueue")]
        public async Task<ActionResult<PersonQueueDto>> GetFirstPersonsInQueue(int id)
        {
            var queue = await queueLineHandler.GetByIdData(id);

            if (queue == null) return NotFound();

            var personsQueue = await enqueueService.EnqueueAttendingPersons(queue.Persons);
            queue.Persons = personsQueue.ToList();
            return queue.Persons[0];
        }

        [HttpGet("{id:int} GetNextPersonsInQueue")]
        public async Task<ActionResult<PersonQueueDto>> GetNextPersonsInQueue(int id)
        {
            var queue = await queueLineHandler.GetByIdData(id);

            if (queue == null) 
                return NotFound();

            var personQueue = await enqueueService.DequeuePerson(queue);

            return personQueue;
        }

        [HttpPost]
        public async Task<ActionResult> Post(QueueLinePostDto queueLinePostDto)
        {
            try
            {
                var entityDto = await queueLineHandler.Create(queueLinePostDto);

                return CreatedAtRoute("GetQueueLine", new {id = entityDto.Id}, entityDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await queueLineHandler.Delete(id);
            return Ok(deleted);
        }
    }
}
