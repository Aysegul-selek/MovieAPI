using MediatR;
using MovieApi.Domain.Entities;
using MovieAPI.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
    {private readonly MovieContext _movieContext;

        public CreateCastCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            _movieContext.Casts.Add(new Cast
            {
                Biography = request.Biography,
                ImageUrl= request.ImageUrl,
                 Name = request.Name,
                  Overview= request.Overview,
                   Surname = request.Surname    ,
                    Title = request.Title
            });
            await _movieContext.SaveChangesAsync();
        }
    }
}
