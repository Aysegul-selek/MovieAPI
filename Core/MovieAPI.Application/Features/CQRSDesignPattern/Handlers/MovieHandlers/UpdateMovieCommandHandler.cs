using MovieAPI.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async void Handle(UpdateMovieCommand command)
        {
            var value=await _context.Movies.FindAsync(command.MovieId);
            value.Rating = command.Rating;
            value.Title = command.Title;
            value.Description = command.Description;
            value.CreatedYear = command.CreatedYear;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Duration  = command.Duration;
            value.Status = command.Status;
            value.ReleaseDate = command.ReleaseDate;
            await _context.SaveChangesAsync();
        }
    }
}
