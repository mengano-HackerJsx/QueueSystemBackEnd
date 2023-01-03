using Application.Person.DTO;
using Application.Person.Handler;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace QueueSystem2._0Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonHandler personHandler;

        public PersonsController(IPersonHandler personHandler)
        {
            this.personHandler = personHandler;
        }

        [HttpGet]
        public async Task<List<PersonDto>> GetAll()
        {
            return await personHandler.GetAll();
        }

        [HttpGet("{id:int}", Name="GetPerson")]
        public async Task<ActionResult<PersonDto>> GetById(int id)
        {
            var entityReturn = await personHandler.GetById(id);

            if (entityReturn == null) return NotFound("El recurso buscado no existe.");

            return Ok(entityReturn);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PersonPostDto personPostDto)
        {
            try
            {
                var entityCreated = await personHandler.Create(personPostDto);

                return CreatedAtRoute("GetPerson", new { id = entityCreated.Id }, entityCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PersonDto>> Put(int id, PersonPostDto personPostDto)
        {
            return await personHandler.Update(id, personPostDto);
        }

        /*[HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<PersonPostDto> patchDocument)
        {
            if (patchDocument == null) return BadRequest();

            var personDb = await personHandler.GetById(id);

            if (personDb == null) return NotFound();


        }*/

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await personHandler.Delete(id);
            return Ok(deleted);
        }
    }
}
