using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieAPI.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieAPI.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace MovieAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandle _removeMovieCommandHandler;

        public MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, CreateMovieCommandHandler createMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandle removeMovieCommandHandler)
        {
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
        }
        [HttpGet]
        public  async Task<IActionResult> MovieList()
        {
            var value = await _getMovieQueryHandler.Handle();
            return Ok(value);
        }
        [HttpPost]
        public async Task <IActionResult> CreateMovie(CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handle(command);
            return Ok("film eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteMovie(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("film silindi");
        }
        [HttpGet("GetMovie")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult>UpdateMovie(UpdateMovieCommand command)
        {  
            await _updateMovieCommandHandler.Handle(command);
            return Ok("günceleme başarılı");
         }
    }
}
