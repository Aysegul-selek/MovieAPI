﻿using MediatR;
using MovieAPI.Application.Features.MediatorDesignPattern.Results.CastResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.MediatorDesignPattern.Queries
{
    public class GetCastQuery:IRequest<List<GetCastQueryResult>>
    {
        
    }
}
