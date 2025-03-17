using MovieAPI.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandle
    {
        private readonly MovieContext _context;

        public RemoveMovieCommandHandle(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(RemoveMovieCommand command)
        {
            var value=_context.Movies.FindAsync(command.MovieId).Result;
            _context.Movies.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
