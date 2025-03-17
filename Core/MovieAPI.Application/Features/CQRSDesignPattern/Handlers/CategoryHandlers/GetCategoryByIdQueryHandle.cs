using MovieAPI.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;
using MovieAPI.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandle
    {
        private readonly MovieContext _context;

        public GetCategoryByIdQueryHandle(MovieContext context)
        {
            _context = context;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var value= await _context.Categories.FindAsync(query.CategoryId);
            return new GetCategoryByIdQueryResult
            {
                CategoryId = value.CategoryId,
                CategoryName = value.CategoryName
            };
        }
    }
}
