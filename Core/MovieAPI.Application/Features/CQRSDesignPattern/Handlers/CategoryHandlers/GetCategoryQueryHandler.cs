using Microsoft.EntityFrameworkCore;
using MovieAPI.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using Persistance.Context;

namespace MovieAPI.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly MovieContext _context;

        public GetCategoryQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _context.Categories.ToListAsync();
            return values.Select(c => new GetCategoryQueryResult
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
            }).ToList();
        }
    }
}
