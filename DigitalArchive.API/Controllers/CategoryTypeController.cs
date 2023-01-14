using DigitalArchive.Business.Abstract;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.ViewModels.CategoryTypeVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalArchive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CategoryTypeController : BaseController
    {
        private readonly ICategoryTypeAppService _categoryTypeAppService;
        public CategoryTypeController
            (
            ICategoryTypeAppService categoryTypeAppService
            )
        {
            _categoryTypeAppService = categoryTypeAppService;
        }


        [HttpGet("GetAllCategoryTypeByPage")]
        public async Task<PagedResult<GetAllCategoryTypeInfo>> GetAllCategoryTypeByPage([FromQuery]GetAllCategoryTypeInput input)
        {
            return await _categoryTypeAppService.GetAllCategoryTypeByPage(input);
        }

        [HttpGet("GetCategoryTypeList")]
        public async Task<ListResult<GetAllCategoryTypeInfo>> GetCategoryTypeList()
        {
            return await _categoryTypeAppService.GetCategoryTypeList();
        }

        [HttpPost("CreateCategoryType")]
        public async Task CreateCategoryType(CreateCategoryTypeInput input)
        {
            await _categoryTypeAppService.CreateCategoryType(input);
        }

        [HttpPost("UpdateCategoryType")]
        public async Task UpdateCategoryType(UpdateCategoryTypeInput input)
        {
            await _categoryTypeAppService.UpdateCategoryType(input);
        }
        [HttpPost("DeleteCategoryType")]
        public async Task DeleteCategoryType(int id)
        {
            await _categoryTypeAppService.DeleteCategoryType(id);
        }
    }
}
