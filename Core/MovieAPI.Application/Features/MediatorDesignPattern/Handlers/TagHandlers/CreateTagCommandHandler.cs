using MediatR;
using MovieApi.Domain.Entities;
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
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
    {
        private readonly MovieContext _movieContext;

        public CreateTagCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            _movieContext.Tags.Add(new Tag
            { Title = request.Title });
            await _movieContext.SaveChangesAsync();
        }
    }
}
