using MediatR;
using MovieAPI.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieAPI.Application.Features.MediatorDesignPattern.Results.CastResults;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{

    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _context;

        public GetCastByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async  Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts.FindAsync(request.CastId);
            return new GetCastByIdQueryResult
            {
                Biography = values.Biography,
                CastId = values.CastId,
                ImageUrl = values.ImageUrl,
                Name = values.Name,
                Overview = values.Overview,
                Surname = values.Surname,
                Title = values.Title
            };
        }
    }
}
