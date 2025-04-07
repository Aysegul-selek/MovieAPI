using MediatR;
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
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
    {
        private readonly MovieContext _context;

        public GetTagByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        { var value=await _context.Tags.FindAsync(request.TagId, cancellationToken);
            return new GetTagByIdQueryResult
            {
                TagId = value.TagId,
                Title = value.Title
            };

        }
    }
}
