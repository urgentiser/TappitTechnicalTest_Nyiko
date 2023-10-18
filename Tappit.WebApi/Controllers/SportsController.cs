using Microsoft.AspNetCore.Mvc;
using Tappit.Application.Features.Sport.Commands;
using Tappit.Application.Features.Sport.Queries;
using Tappit.Application.Models.Requests;

namespace Tappit.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SportsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateSport(NewSportRequest newSport)
        {
            var response = await Sender.Send(new CreateSportCommand { SportRequest = newSport });
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePolicy(UpdateSportRequest updateSport)
        {
            var response = await Sender.Send(new UpdateSportCommand { SportRequest = updateSport });
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteSport(int Id)
        {
            var response = await Sender.Send(new DeleteSportCommand { SportId = Id });
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSport(int Id)
        {
            var response = await Sender.Send(new GetSportByIdQuery { Id = Id });
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetSports()
        {
            var response = await Sender.Send(new GetAllSportQuery());
            if (response.IsSuccessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
