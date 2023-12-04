using Application.Queries;
using HospitalVisits.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HospitalVisits.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HospitalController : ControllerBase
    {

        private readonly ILogger<HospitalController> _logger;
        private readonly IMediator _mediator;

        public HospitalController(ILogger<HospitalController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            // TODO: Consider Authorization
            // TODO: Consider caching with Redis

            var result = await _mediator.Send(new GetHospitalsQuery());
            if(result?.Count == 0)
            {
                _logger.LogInformation("Get hospitals - No content");
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost("{hospitalId}/visits")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([Required] string hospitalId, [FromBody] VisitSearchModel searchModel)
        {
            // TODO: Consider using FluentValidation
            // TODO: Consider Authorization
            // TODO: Consider Pagination / lazy loading
            // TODO: More search parameters or replace search text with specific parameters like patient name, date, etc.

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Get patient visits - Invalid model state");
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(new GetPatientVisitsQuery(hospitalId, searchModel.SearchText));

            if (result?.Count == 0)
            {
                _logger.LogInformation("Get patient visits - No content");
                return NoContent();
            }


            return Ok(result);
        }
    }
}