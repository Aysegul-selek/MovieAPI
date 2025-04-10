﻿using MovieAPI.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public RemoveCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(RemoveCategoryCommand command)
        {
            var value=_context.Categories.FindAsync(command.CategoryId).Result;
            _context.Categories.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
