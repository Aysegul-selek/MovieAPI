﻿using MovieAPI.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieAPI.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieAPI.Application.Features.CQRSDesignPattern.Results.MovieResults;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task<GetMovieByIdQueryResult>Handle(GetMovieByIdQuery query)
        {
            var value=await _context.Movies.FindAsync(query.MovieId);
            return new GetMovieByIdQueryResult
            {
               MovieId=value.MovieId,
                CreatedYear=value.CreatedYear,
                CoverImageUrl=value.CoverImageUrl,
                Description=value.Description,
                Duration= value.Duration,
                Rating=value.Rating,
                ReleaseDate=value.ReleaseDate,
                Status=value.Status,
                Title=value.Title,
            };
        }
    }
}
