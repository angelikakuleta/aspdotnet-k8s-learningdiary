using LearningDiary.API.Extensions;
using LearningDiary.Application.Commands.CreateSavePoint;
using LearningDiary.Application.Commands.DeleteSavePoint;
using LearningDiary.Application.Commands.UpdateSavePoint;
using LearningDiary.Application.Queries.GetSavePoint;
using LearningDiary.Application.Queries.GetSavePointsByAppUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LearningDiary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SavePointsController : ControllerBase
    {
        private readonly ILogger<SavePointsController> _logger;
        private readonly IMediator _mediator;

        public SavePointsController(ILogger<SavePointsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] string nickname)
        {
            var response = await _mediator.Send(new GetSavePointsByAppUserQuery() { Nickname = nickname });
            if (!response.Success)
            {
                return StatusCode(response.GetStatusCode(), response.Result);
            }

            return Ok(response.Body);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var response = await _mediator.Send(new GetSavePointQuery(){ Id = id });
            if (!response.Success)
            {
                return StatusCode(response.GetStatusCode(), response.Result);
            }

            return Ok(response.Body);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSavePointCommand command)
        {
            var response = await _mediator.Send(command);
            if (!response.Success)
            {
                return StatusCode(response.GetStatusCode(), response.Result);
            }

            return Ok(response.Body);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> Update([FromBody] UpdateSavePointCommand command)
        {
            var response = await _mediator.Send(command);
            if (!response.Success)
            {
                return StatusCode(response.GetStatusCode(), response.Result);
            }

            return Ok(response.Body);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteSavePointCommand { Id = id });
            if (!response.Success)
            {
                return StatusCode(response.GetStatusCode(), response.Result);
            }

            return NoContent();
        }
    }
}
