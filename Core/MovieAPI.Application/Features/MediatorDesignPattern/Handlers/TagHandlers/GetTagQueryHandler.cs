using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieAPI.Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MovieAPI.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieAPI.Application.Features.MediatorDesignPattern.Results.TagResults;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
    {
        private readonly MovieContext _context;

        public GetTagQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Tags.ToListAsync();
            return values.Select(x => new GetTagQueryResult
            {
                TagId = x.TagId,
                Title = x.Title
            }).ToList();
        }
    }
}
