using Microsoft.OpenApi.Models;
using MovieAPI.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieAPI.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using Persistance.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieContext>();
// Add services to the container.
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandle>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();

builder.Services.AddScoped<GetMovieByIdQueryHandler>();
builder.Services.AddScoped<GetMovieQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>
    { c.SwaggerEndpoint("/swagger/v1/swager.json", "My Api v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
