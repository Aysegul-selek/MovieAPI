using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Application.Features.MediatorDesignPattern.Queries;
using MovieAPI.Application.Features.MediatorDesignPattern.Results.CastResults;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly MovieContext _context;

        public GetCastQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts.ToListAsync();
            return values.Select(x => new GetCastQueryResult
            { Biography = x.Biography,
            ImageUrl = x.ImageUrl,
             Name = x.Name,
              Overview=x.Overview,
              Surname=x.Surname,
               Title=x.Title,
               CastId=x.CastId
            }).ToList();
        }
    }
}
