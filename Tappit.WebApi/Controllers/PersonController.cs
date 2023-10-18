using Microsoft.AspNetCore.Mvc;
using Tappit.Application.Features.Person.Commands;
using Tappit.Application.Features.Person.Queries;
using Tappit.Application.Models.Requests;

namespace Tappit.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreatePerson(NewPersonRequest newPerson)
        {
            var response = await Sender.Send(new CreatePersonCommand { PersonRequest = newPerson });
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson(UpdatePersonRequest updatePerson)
        {
            var response = await Sender.Send(new UpdatePersonCommand { PersonRequest = updatePerson });
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePerson(int Id)
        {
            var response = await Sender.Send(new DeletePersonCommand { Id = Id });
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPerson(int Id)
        {
            var response = await Sender.Send(new GetPersonByIdQuery { Id = Id });
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            var response = await Sender.Send(new GetAllPersonQuery());
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
