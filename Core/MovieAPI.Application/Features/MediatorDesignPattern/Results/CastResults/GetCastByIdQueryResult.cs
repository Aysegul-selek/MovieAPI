using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.MediatorDesignPattern.Results.CastResults
{
    public class GetCastByIdQueryResult
    {
        public GetCastByIdQueryResult(int castId)
        {
            CastId = castId;
        }

        public int CastId { get; set; }
    }
}
