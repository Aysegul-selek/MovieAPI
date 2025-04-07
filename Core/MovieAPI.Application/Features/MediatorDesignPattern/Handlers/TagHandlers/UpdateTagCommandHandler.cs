using MediatR;
using MovieAPI.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieAPI.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
    {
        private readonly MovieContext _movieContext;

        public UpdateTagCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var values = await _movieContext.Tags.FindAsync(request.TagId);
            values.TagId= request.TagId;
            values.Title = request.Title;
            await _movieContext.SaveChangesAsync();
        }
    }
}
