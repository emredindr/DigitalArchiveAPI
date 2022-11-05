using DigitalArchive.Business.Abstract;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.ViewModels.CategoryVM;
using Microsoft.AspNetCore.Mvc;

namespace DigitalArchive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryAppService _categoryAppService;
        public CategoryController
            (
            ICategoryAppService categoryAppService
            )
        {
            _categoryAppService = categoryAppService;
        }
        [HttpGet("GetCategoryList")]
        public async Task<ListResult<GetAllCategoryInfo>> GetCategoryList([FromQuery] GetCategoryListInput input)
        {
            return await _categoryAppService.GetCategoryList(input);
        }

        [HttpGet("GetCategoryById")]
        public async Task<GetAllCategoryInfo> GetCategoryById(int categoryId)
        {
            return await _categoryAppService.GetCategoryById(categoryId);
        }

        [HttpGet("GetAllCategoryByPage")]
        public async Task<PagedResult<GetAllCategoryInfo>> GetAllCategoryByPage([FromQuery]GetAllCategoryInput input)
        {
            return await _categoryAppService.GetAllCategoryByPage(input);
        }

        [HttpPost("CreateCategory")]
        public async Task CreateCategory(CreateCategoryInput input)
        {
            await _categoryAppService.CreateCategory(input);
        }

        [HttpPost("UpdateCategory")]
        public async Task UpdateCategory(UpdateCategoryInput input)
        {
            await _categoryAppService.UpdateCategory(input);
        }
        [HttpDelete("DeleteCategory")]
        public async Task DeleteCategory(int id)
        {
            await _categoryAppService.DeleteCategory(id);
        }
    }
}
