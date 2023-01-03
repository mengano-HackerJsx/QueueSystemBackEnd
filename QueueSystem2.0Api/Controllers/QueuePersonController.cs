using Application.QueuePerson.DTO;
using Application.QueuePerson.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace QueueSystem2._0Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueuePersonController : ControllerBase
    {
        private readonly IQueuePersonHandler queuePersonHandler;

        public QueuePersonController(IQueuePersonHandler queuePersonHandler)
        {
            this.queuePersonHandler = queuePersonHandler;
        }

        [HttpPost]
        public async Task<ActionResult> Post(QueuePersonPostDto queuePersonPostDto)
        {
            try
            {
                var entity = await queuePersonHandler.Create(queuePersonPostDto);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
