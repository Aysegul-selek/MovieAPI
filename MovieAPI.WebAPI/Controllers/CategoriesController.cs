using Microsoft.AspNetCore.Mvc;
using MovieAPI.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieAPI.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieAPI.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;

namespace MovieAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandle _getCategoryByIdQueryHandle;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;

        public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandle getCategoryByIdQueryHandle, RemoveCategoryCommandHandler removeCategoryCommandHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getCategoryByIdQueryHandle = getCategoryByIdQueryHandle;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
        }
        [HttpGet]
        public async Task<ActionResult> CategoryList() 
        {
            var value =await _getCategoryQueryHandler.Handle();
            return Ok(value);
         }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("silme başarılı");
        }
        [HttpPut]
        public async Task<IActionResult>UpdateCategory (UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return Ok("günceleme başarılı");
        }
        [HttpGet("GetCategory")]
        public  async  Task<IActionResult> GetCategory(int id)
        { var value = await _getCategoryByIdQueryHandle.Handle(new GetCategoryByIdQuery(id));
        return Ok(value); }
    }
}
