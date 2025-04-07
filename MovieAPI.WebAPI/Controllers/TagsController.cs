using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieAPI.Application.Features.MediatorDesignPattern.Queries.TagQueries;

namespace MovieAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> TagList()
        {
            var value =await _mediator.Send(new GetTagQuery());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommand command)
        {
           await _mediator.Send(command);
            return Ok("ekleme başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTag(int id)
        {
           await _mediator.Send(new RemoveTagCommand(id));
            return Ok("silme başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTag(UpdateTagCommand command)
        {
           await _mediator.Send(command);
            return Ok("güncelleme başarılı");

        }
        [HttpGet("GetTagById")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var value = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok(value);
        }
    }
}
