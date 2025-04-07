using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.MediatorDesignPattern.Commands.TagCommands
{
    public class CreateTagCommand:IRequest
    {
        public int TagId { get; set; }
        public string Title { get; set; }
    }
}
